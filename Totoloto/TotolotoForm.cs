using System.Configuration;
using TotolotoRepository;
using HtmlAgilityPack;
using System.Security.Policy;
using TotolotoRepository.Models;
using System.Xml.Linq;
using Totoloto.Properties;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.LinkLabel;
using System.Windows.Forms;
using System.Data;

namespace Totoloto
{
    public partial class TotolotoForm : Form
    {
        public ITotolotoContextFactory totolotoContextFactory;
        public TotolotoContext totolotoContext;
        public List<TotolotoRepository.Models.Configuration> configurations;

        public TotolotoForm(ITotolotoContextFactory totolotoContextFactory)
        {
            this.totolotoContextFactory = totolotoContextFactory;
            totolotoContext = totolotoContextFactory.CreateDbContext();
            InitializeComponent();
            LoadConfiguraion();
        }

        private void Totoloto_Load(object sender, EventArgs e)
        {
            bool enableUpdate = false;

            if (totolotoContext.Jogos.Any())
            {
                var lastGame = totolotoContext.Jogos.OrderBy(x => x.Data).Last();
                txtInformations.Text = $"Último jogo carregado {lastGame.NumeroJogo} de {lastGame.Data.Year}, Data: {lastGame.Data.ToString("dd/MM/yyyy")}";

                if (lastGame.Data.DayOfWeek == DayOfWeek.Wednesday)
                    if (lastGame.Data.AddDays(3) < DateTime.Now)
                        enableUpdate = true;
                    else if (lastGame.Data.DayOfWeek == DayOfWeek.Saturday)
                        if (lastGame.Data.AddDays(4) < DateTime.Now)
                            enableUpdate = true;

                if (!totolotoContext.EstatisticasNumerosUltimaData.Any(x => x.Tabela == Enum.GetName(TabelaEnum.EstatisticasNumerosDoSorteio)) ||
                    !totolotoContext.EstatisticasNumerosUltimaData.Any(x => x.Tabela == Enum.GetName(TabelaEnum.EstatisticasNumerosDaSorte)) ||
                    !totolotoContext.EstatisticasNumerosUltimaData.Any(x => x.Tabela == Enum.GetName(TabelaEnum.EstatisticasLinhas)) ||
                    !totolotoContext.EstatisticasNumerosUltimaData.Any(x => x.Tabela == Enum.GetName(TabelaEnum.EstatisticasColunas)) ||
                    !totolotoContext.EstatisticasNumerosUltimaData.Any(x => x.Tabela == Enum.GetName(TabelaEnum.SequenciaNumerosDoSorteioSorte)) ||
                    !totolotoContext.EstatisticasNumerosUltimaData.Any(x => x.Tabela == Enum.GetName(TabelaEnum.EstatisticasParImpar)) ||
                     totolotoContext.EstatisticasNumerosUltimaData.Any(x => x.Data < lastGame.Data))
                    enableUpdate = true;
            }
            else
            {
                txtInformations.Text = "Nenhum jogo encontrado na base de dados";
                enableUpdate = true;
            }

            ChangeComponentsVisualization(!enableUpdate);

            btnAtualizarJogos.Visible = enableUpdate;
            btnAtualizarJogos.Enabled = enableUpdate;
        }

        private void LoadConfiguraion()
        {
            configurations = totolotoContext.Configurations.ToList();

            dataGridViewConfiguration.DataSource = configurations;
        }

        private void btnAtualizarJogos_Click(object sender, EventArgs e)
        {
            UpdateGames();

            UpdateStatistic();

            bool enableUpdate = false;
            ChangeComponentsVisualization(!enableUpdate);
            btnAtualizarJogos.Visible = enableUpdate;
            btnAtualizarJogos.Enabled = enableUpdate;
            txtInformations.Text = "Jogos atualizados";

            var lastGame = totolotoContext.Jogos.OrderBy(x => x.Data).Last();
            txtInformations.Text = $"Último jogo carregado {lastGame.NumeroJogo}, Data: {lastGame.Data.ToString("dd/MM/yyyy")}";
        }

        private void UpdateStatistic()
        {
            UpdateStatisticLuckyNumbers();
            UpdateStatisticDrawNumbers();
            UpdateStatisticLines();
            UpdateStatisticColumns();
            UpdateSequenceDrawNumbersAndLuckyNumbers();
            UpdateStatisticsEvenOdd();
        }

        private void UpdateStatisticsEvenOdd()
        {
            var statisticsEvenOdd = totolotoContext.EstatisticasNumerosUltimaData.FirstOrDefault(x => x.Tabela == Enum.GetName(TabelaEnum.EstatisticasParImpar));

            if (statisticsEvenOdd == null)
            {
                var statistic = new EstatisticasNumerosUltimaDatum { Tabela = Enum.GetName(TabelaEnum.EstatisticasParImpar), Data = new DateTime(1900, 1, 1) };
                totolotoContext.EstatisticasNumerosUltimaData.Add(statistic);
                totolotoContext.SaveChanges();
                statisticsEvenOdd = statistic;
            }

            var games = totolotoContext.Jogos.Include(x => x.Numero1Navigation)
                                             .Include(x => x.Numero2Navigation)
                                             .Include(x => x.Numero3Navigation)
                                             .Include(x => x.Numero4Navigation)
                                             .Include(x => x.Numero5Navigation)
                                             .Where(j => j.Data > statisticsEvenOdd.Data).OrderBy(x => x.Data).ToList();

            foreach (var game in games)
            {
                string parImpar = $"{GetEvenOddText(game.Numero1Navigation)}{GetEvenOddText(game.Numero2Navigation)}{GetEvenOddText(game.Numero3Navigation)}{GetEvenOddText(game.Numero4Navigation)}{GetEvenOddText(game.Numero5Navigation)}";

                var estatisticasParImpars = totolotoContext.EstatisticasParImpars.FirstOrDefault(x => x.ParImpar == parImpar);

                if (estatisticasParImpars == null)
                {
                    estatisticasParImpars = new EstatisticasParImpar { ParImpar = parImpar, Quantidade = 1 };
                    totolotoContext.EstatisticasParImpars.Add(estatisticasParImpars);
                    totolotoContext.SaveChanges();
                }
                else
                {
                    estatisticasParImpars.Quantidade += 1;
                    totolotoContext.EstatisticasParImpars.Update(estatisticasParImpars);
                    totolotoContext.SaveChanges();
                }

                statisticsEvenOdd.Data = game.Data;
                totolotoContext.EstatisticasNumerosUltimaData.Update(statisticsEvenOdd);
                totolotoContext.SaveChanges();
            }
        }

        private object GetEvenOddText(NumerosDoSorteio numerosDoSorteio)
        {
            if (numerosDoSorteio.Par)
            {
                return "P";
            }
            else if (numerosDoSorteio.Impar)
            {
                return "I";
            }
            else
            {
                throw new Exception("Número não é par nem ímpar");
            }
        }

        private void UpdateSequenceDrawNumbersAndLuckyNumbers()
        {
            var statisticLuckyNumbers = totolotoContext.EstatisticasNumerosUltimaData.FirstOrDefault(x => x.Tabela == Enum.GetName(TabelaEnum.SequenciaNumerosDoSorteioSorte));

            if (statisticLuckyNumbers == null)
            {
                var statistic = new EstatisticasNumerosUltimaDatum { Tabela = Enum.GetName(TabelaEnum.SequenciaNumerosDoSorteioSorte), Data = new DateTime(1900, 1, 1) };
                totolotoContext.EstatisticasNumerosUltimaData.Add(statistic);
                totolotoContext.SaveChanges();
                statisticLuckyNumbers = statistic;
            }

            var games = totolotoContext.Jogos.Where(j => j.Data > statisticLuckyNumbers.Data).OrderBy(x => x.Data).ToList();

            foreach (var game in games)
            {
                List<int> numbers = new List<int> { game.Numero1, game.Numero2, game.Numero3, game.Numero4, game.Numero5 };

                foreach (var number in numbers)
                {
                    var sequenciaNumerosDoSorteioSortes = totolotoContext.SequenciaNumerosDoSorteioSortes.FirstOrDefault(x => x.NumeroDoSorteio == number && x.NumeroDaSorte == game.NumeroSorte);

                    if (sequenciaNumerosDoSorteioSortes == null)
                    {
                        sequenciaNumerosDoSorteioSortes = new SequenciaNumerosDoSorteioSorte { NumeroDoSorteio = number, NumeroDaSorte = game.NumeroSorte, Quantidade = 1 };
                        totolotoContext.SequenciaNumerosDoSorteioSortes.Add(sequenciaNumerosDoSorteioSortes);
                        totolotoContext.SaveChanges();
                    }
                    else
                    {
                        sequenciaNumerosDoSorteioSortes.Quantidade += 1;
                        totolotoContext.SequenciaNumerosDoSorteioSortes.Update(sequenciaNumerosDoSorteioSortes);
                        totolotoContext.SaveChanges();
                    }
                }

                statisticLuckyNumbers.Data = game.Data;
                totolotoContext.EstatisticasNumerosUltimaData.Update(statisticLuckyNumbers);
                totolotoContext.SaveChanges();
            }
        }

        private void UpdateStatisticLines()
        {
            var statisticLines = totolotoContext.EstatisticasNumerosUltimaData.FirstOrDefault(x => x.Tabela == Enum.GetName(TabelaEnum.EstatisticasLinhas));

            if (statisticLines == null)
            {
                var statistic = new EstatisticasNumerosUltimaDatum { Tabela = Enum.GetName(TabelaEnum.EstatisticasLinhas), Data = new DateTime(1900, 1, 1) };
                totolotoContext.EstatisticasNumerosUltimaData.Add(statistic);
                totolotoContext.SaveChanges();
                statisticLines = statistic;
            }

            var games = totolotoContext.Jogos.Include(x => x.Numero1Navigation)
                                             .Include(x => x.Numero2Navigation)
                                             .Include(x => x.Numero3Navigation)
                                             .Include(x => x.Numero4Navigation)
                                             .Include(x => x.Numero5Navigation)
                                             .Where(j => j.Data > statisticLines.Data).OrderBy(x => x.Data).ToList();

            foreach (var game in games)
            {
                string linha = $"{game.Numero1Navigation.Linha}{game.Numero2Navigation.Linha}{game.Numero3Navigation.Linha}{game.Numero4Navigation.Linha}{game.Numero5Navigation.Linha}";

                var estatisticasLinhas = totolotoContext.EstatisticasLinhas.FirstOrDefault(x => x.Linha == linha);

                if (estatisticasLinhas == null)
                {
                    estatisticasLinhas = new EstatisticasLinha { Linha = linha, Quantidade = 1 };
                    totolotoContext.EstatisticasLinhas.Add(estatisticasLinhas);
                    totolotoContext.SaveChanges();
                }
                else
                {
                    estatisticasLinhas.Quantidade += 1;
                    totolotoContext.EstatisticasLinhas.Update(estatisticasLinhas);
                    totolotoContext.SaveChanges();
                }

                statisticLines.Data = game.Data;
                totolotoContext.EstatisticasNumerosUltimaData.Update(statisticLines);
                totolotoContext.SaveChanges();
            }
        }

        private void UpdateStatisticColumns()
        {
            var statisticColumns = totolotoContext.EstatisticasNumerosUltimaData.FirstOrDefault(x => x.Tabela == Enum.GetName(TabelaEnum.EstatisticasColunas));

            if (statisticColumns == null)
            {
                var statistic = new EstatisticasNumerosUltimaDatum { Tabela = Enum.GetName(TabelaEnum.EstatisticasColunas), Data = new DateTime(1900, 1, 1) };
                totolotoContext.EstatisticasNumerosUltimaData.Add(statistic);
                totolotoContext.SaveChanges();
                statisticColumns = statistic;
            }

            var games = totolotoContext.Jogos.Include(x => x.Numero1Navigation)
                                             .Include(x => x.Numero2Navigation)
                                             .Include(x => x.Numero3Navigation)
                                             .Include(x => x.Numero4Navigation)
                                             .Include(x => x.Numero5Navigation)
                                             .Where(j => j.Data > statisticColumns.Data).OrderBy(x => x.Data).ToList();

            foreach (var game in games)
            {
                string coluna = $"{game.Numero1Navigation.Coluna}{game.Numero2Navigation.Coluna}{game.Numero3Navigation.Coluna}{game.Numero4Navigation.Coluna}{game.Numero5Navigation.Coluna}";

                var estatisticasColunas = totolotoContext.EstatisticasColunas.FirstOrDefault(x => x.Coluna == coluna);

                if (estatisticasColunas == null)
                {
                    estatisticasColunas = new EstatisticasColuna { Coluna = coluna, Quantidade = 1 };
                    totolotoContext.EstatisticasColunas.Add(estatisticasColunas);
                    totolotoContext.SaveChanges();
                }
                else
                {
                    estatisticasColunas.Quantidade += 1;
                    totolotoContext.EstatisticasColunas.Update(estatisticasColunas);
                    totolotoContext.SaveChanges();
                }

                statisticColumns.Data = game.Data;
                totolotoContext.EstatisticasNumerosUltimaData.Update(statisticColumns);
                totolotoContext.SaveChanges();
            }
        }

        private void UpdateStatisticDrawNumbers()
        {
            var statisticLuckyNumbers = totolotoContext.EstatisticasNumerosUltimaData.FirstOrDefault(x => x.Tabela == Enum.GetName(TabelaEnum.EstatisticasNumerosDoSorteio));

            if (statisticLuckyNumbers == null)
            {
                var statistic = new EstatisticasNumerosUltimaDatum { Tabela = Enum.GetName(TabelaEnum.EstatisticasNumerosDoSorteio), Data = new DateTime(1900, 1, 1) };
                totolotoContext.EstatisticasNumerosUltimaData.Add(statistic);
                totolotoContext.SaveChanges();
                statisticLuckyNumbers = statistic;
            }

            var games = totolotoContext.Jogos.Where(j => j.Data > statisticLuckyNumbers.Data).OrderBy(x => x.Data).ToList();

            List<int> lastNumbers = new List<int>();
            int sequence = 1;

            foreach (var game in games)
            {
                List<int> numbers = new List<int> { game.Numero1, game.Numero2, game.Numero3, game.Numero4, game.Numero5 };

                foreach (int number in numbers)
                {
                    var estatisticasNumerosDoSorteios = totolotoContext.EstatisticasNumerosDoSorteios.First(x => x.Numero == number);

                    if (lastNumbers.Contains(number))
                        sequence += 1;
                    else
                        sequence = 1;

                    estatisticasNumerosDoSorteios.Sorteado += 1;
                    estatisticasNumerosDoSorteios.AtrasoAtual = 0;
                    estatisticasNumerosDoSorteios.MaiorSequencia = estatisticasNumerosDoSorteios.MaiorSequencia > sequence ? estatisticasNumerosDoSorteios.MaiorSequencia : sequence;
                    estatisticasNumerosDoSorteios.SequenciaAtual = sequence;

                    totolotoContext.EstatisticasNumerosDoSorteios.Update(estatisticasNumerosDoSorteios);

                    foreach (int numberSameGame in numbers)
                    {
                        if (number != numberSameGame)
                            UpdateSequenciaNumerosDoSorteios(number, numberSameGame);
                    }
                }

                UpdateOtherDrawNumbers(numbers);

                statisticLuckyNumbers.Data = game.Data;
                totolotoContext.EstatisticasNumerosUltimaData.Update(statisticLuckyNumbers);
                totolotoContext.SaveChanges();

                lastNumbers = new List<int> { game.Numero1, game.Numero2, game.Numero3, game.Numero4, game.Numero5 };
            }
        }

        private void UpdateOtherDrawNumbers(List<int> numeros)
        {
            var estatisticasNumerosDoSorteiosList = totolotoContext.EstatisticasNumerosDoSorteios.Where(x => !numeros.Contains(x.Numero)).ToList();

            foreach (var estatisticasNumerosDoSorteios in estatisticasNumerosDoSorteiosList)
            {
                estatisticasNumerosDoSorteios.AtrasoAtual += 1;

                estatisticasNumerosDoSorteios.AtrasoMaximo = estatisticasNumerosDoSorteios.AtrasoAtual > estatisticasNumerosDoSorteios.AtrasoMaximo ? estatisticasNumerosDoSorteios.AtrasoAtual : estatisticasNumerosDoSorteios.AtrasoMaximo;

                estatisticasNumerosDoSorteios.SequenciaAtual = 0;
            }

            totolotoContext.EstatisticasNumerosDoSorteios.UpdateRange(estatisticasNumerosDoSorteiosList);
            totolotoContext.SaveChanges();
        }

        private void UpdateSequenciaNumerosDoSorteios(int number, int numberSameGame)
        {
            var sequenciaNumerosDoSorteios = totolotoContext.SequenciaNumerosDoSorteios.FirstOrDefault(x => x.Numero == number && x.NumeroMesmoJogo == numberSameGame);

            if (sequenciaNumerosDoSorteios == null)
            {
                sequenciaNumerosDoSorteios = new SequenciaNumerosDoSorteio { Numero = number, NumeroMesmoJogo = numberSameGame, Quantidade = 1 };
                totolotoContext.SequenciaNumerosDoSorteios.Add(sequenciaNumerosDoSorteios);
            }
            else
            {
                sequenciaNumerosDoSorteios.Quantidade += 1;
                totolotoContext.SequenciaNumerosDoSorteios.Update(sequenciaNumerosDoSorteios);
            }

            totolotoContext.SaveChanges();
        }

        private void UpdateStatisticLuckyNumbers()
        {
            var statisticLuckyNumbers = totolotoContext.EstatisticasNumerosUltimaData.FirstOrDefault(x => x.Tabela == Enum.GetName(TabelaEnum.EstatisticasNumerosDaSorte));

            if (statisticLuckyNumbers == null)
            {
                var statistic = new EstatisticasNumerosUltimaDatum { Tabela = Enum.GetName(TabelaEnum.EstatisticasNumerosDaSorte), Data = new DateTime(1900, 1, 1) };
                totolotoContext.EstatisticasNumerosUltimaData.Add(statistic);
                totolotoContext.SaveChanges();
                statisticLuckyNumbers = statistic;
            }

            var games = totolotoContext.Jogos.Where(j => j.Data > statisticLuckyNumbers.Data).OrderBy(x => x.Data).ToList();

            Jogo Lastgame = new Jogo();
            int sequence = 1;

            foreach (var game in games)
            {
                var estatisticasNumerosDaSorte = totolotoContext.EstatisticasNumerosDaSortes.First(x => x.Numero == game.NumeroSorte);

                if (Lastgame.NumeroSorte == game.NumeroSorte)
                    sequence += 1;
                else
                    sequence = 1;

                if (Lastgame.NumeroSorte > 0)
                {
                    var sequenciaNumeroDaSortes = totolotoContext.SequenciaNumerosDaSortes.FirstOrDefault(x => x.Numero == game.NumeroSorte && x.NumeroAnterior == Lastgame.NumeroSorte);

                    if (sequenciaNumeroDaSortes == null)
                    {
                        sequenciaNumeroDaSortes = new SequenciaNumerosDaSorte { Numero = game.NumeroSorte, NumeroAnterior = Lastgame.NumeroSorte, Quantidade = 1 };
                        totolotoContext.SequenciaNumerosDaSortes.Add(sequenciaNumeroDaSortes);
                    }
                    else
                    {
                        sequenciaNumeroDaSortes.Quantidade += 1;
                        totolotoContext.SequenciaNumerosDaSortes.Update(sequenciaNumeroDaSortes);
                    }

                    totolotoContext.SaveChanges();
                }

                estatisticasNumerosDaSorte.AtrasoAtual = 0;
                estatisticasNumerosDaSorte.MaiorSequencia = estatisticasNumerosDaSorte.MaiorSequencia > sequence ? estatisticasNumerosDaSorte.MaiorSequencia : sequence;
                estatisticasNumerosDaSorte.SequenciaAtual = sequence;
                estatisticasNumerosDaSorte.Sorteado += 1;

                totolotoContext.EstatisticasNumerosDaSortes.Update(estatisticasNumerosDaSorte);

                UpdateOtherLuckyNumbers(game.NumeroSorte);

                statisticLuckyNumbers.Data = game.Data;
                totolotoContext.EstatisticasNumerosUltimaData.Update(statisticLuckyNumbers);
                totolotoContext.SaveChanges();

                Lastgame = game;
            }
        }

        private void UpdateOtherLuckyNumbers(int number)
        {
            var estatisticasNumerosDaSorteList = totolotoContext.EstatisticasNumerosDaSortes.Where(x => x.Numero != number).ToList();

            foreach (var estatisticasNumerosDaSorte in estatisticasNumerosDaSorteList)
            {
                estatisticasNumerosDaSorte.AtrasoAtual += 1;

                estatisticasNumerosDaSorte.AtrasoMaximo = estatisticasNumerosDaSorte.AtrasoAtual > estatisticasNumerosDaSorte.AtrasoMaximo ? estatisticasNumerosDaSorte.AtrasoAtual : estatisticasNumerosDaSorte.AtrasoMaximo;

                estatisticasNumerosDaSorte.SequenciaAtual = 0;
            }

            totolotoContext.EstatisticasNumerosDaSortes.UpdateRange(estatisticasNumerosDaSorteList);
            totolotoContext.SaveChanges();
        }

        private void UpdateGames()
        {
            List<Jogo> jogos = new List<Jogo>();
            var baseUrl = ConfigurationManager.AppSettings.Get("UrlByDate");

            List<DateTime> dates = GetGameDates();

            foreach (var date in dates.OrderBy(x => x))
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync($"{baseUrl}{date.ToString("yyyy-MM-dd")}").ConfigureAwait(false).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        var html = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();

                        var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                        htmlDoc.LoadHtml(html);

                        var spanNodes = htmlDoc.DocumentNode.Descendants(0).Where(x => x.HasClass("label") && x.HasClass("label-estr"))?.ToArray();

                        if (spanNodes != null && spanNodes.Count() >= 6)
                        {
                            try
                            {
                                Jogo jogo = new Jogo();

                                var h3Nodes = htmlDoc.DocumentNode.Descendants(0).Where(x => x.HasClass("subjuego"))?.ToList().FirstOrDefault();

                                if (h3Nodes != null)
                                {
                                    string numeroJogo = h3Nodes.InnerText.Replace("Resultado", "").Replace("concurso", "").Replace("Totoloto", "").Replace("Premiação", "").Replace("Ganhadores", "").Replace("-", "").Trim();
                                    jogo.NumeroJogo = int.Parse(numeroJogo);
                                }
                                else
                                {
                                    throw new Exception(htmlDoc.DocumentNode.InnerHtml);
                                }

                                jogo.Data = date;
                                jogo.Numero1 = int.Parse(spanNodes[0].InnerText);
                                jogo.Numero2 = int.Parse(spanNodes[1].InnerText);
                                jogo.Numero3 = int.Parse(spanNodes[2].InnerText);
                                jogo.Numero4 = int.Parse(spanNodes[3].InnerText);
                                jogo.Numero5 = int.Parse(spanNodes[4].InnerText);
                                jogo.NumeroSorte = int.Parse(spanNodes[5].InnerText);

                                jogos.Add(jogo);
                            }
                            catch (Exception exc)
                            {
                                throw new Exception(htmlDoc.DocumentNode.InnerHtml, exc);
                            }
                        }
                        else
                            throw new Exception(htmlDoc.DocumentNode.InnerHtml);
                    }
                }
            }

            totolotoContext.Jogos.AddRange(jogos);
            totolotoContext.SaveChanges();
            totolotoContextFactory.GenerateScripts();
        }

        private List<DateTime> GetGameDates()
        {
            var result = new List<DateTime>();
            DateTime lastGameDate = totolotoContext.Jogos.OrderBy(x => x.Data).Last().Data;

            while (lastGameDate < DateTime.Now)
            {
                if (lastGameDate.DayOfWeek == DayOfWeek.Wednesday)
                    lastGameDate = lastGameDate.AddDays(3);
                else if (lastGameDate.DayOfWeek == DayOfWeek.Saturday)
                    lastGameDate = lastGameDate.AddDays(4);

                if (lastGameDate < DateTime.Now)
                    result.Add(lastGameDate);
            }

            return result;
        }

        private List<Jogo> GetJogosIniciais()
        {
            List<Jogo> jogos = new List<Jogo>();
            var baseUrl = ConfigurationManager.AppSettings.Get("BaseUrl");
            var pages = ConfigurationManager.AppSettings.Get("Pages")?.Split("|").ToList();

            foreach (var page in pages)
            {
                var handler = new HttpClientHandler();
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                handler.ServerCertificateCustomValidationCallback =
                    (httpRequestMessage, cert, cetChain, policyErrors) =>
                    {
                        return true;
                    };

                using (var client = new HttpClient(handler))
                {
                    var response = client.GetAsync($"{baseUrl}{page}").ConfigureAwait(false).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        var html = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();

                        var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                        htmlDoc.LoadHtml(html);

                        HtmlNode divElement2 = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='article']/div/nav");
                        htmlDoc.LoadHtml(divElement2.InnerHtml);

                        HtmlNodeCollection liNodes = htmlDoc.DocumentNode.SelectNodes("//li");
                        if (liNodes != null)
                        {
                            foreach (var liNode in liNodes)
                            {
                                Jogo jogo = new Jogo();
                                var htmlLiNode = new HtmlAgilityPack.HtmlDocument();
                                htmlLiNode.LoadHtml(liNode.InnerHtml);
                                HtmlNodeCollection spanNodes = htmlLiNode.DocumentNode.SelectNodes("//span");

                                try
                                {
                                    if (spanNodes != null && spanNodes.Count == 7)
                                    {
                                        jogo.NumeroJogo = int.Parse(spanNodes[0].InnerText);

                                        HtmlNode aNode = htmlLiNode.DocumentNode.SelectSingleNode("//a");
                                        if (aNode != null)
                                        {
                                            string data = aNode.InnerText.Split(" ")[1];

                                            if (data.Length >= 10)
                                                data = data.Substring(0, 10);
                                            else if (data.Length == 9)
                                                data = $"0{data}";
                                            else
                                                throw new Exception(aNode.InnerText);

                                            if (DateTime.TryParse(data, out DateTime result))
                                                jogo.Data = result;
                                            else
                                                throw new Exception(aNode.InnerText);
                                        }

                                        if (jogo.NumeroJogo == 13 && jogo.Data == new DateTime(2017, 2, 15) && spanNodes[5].InnerText == "??")
                                        {
                                            jogo.Numero1 = int.Parse(spanNodes[1].InnerText);
                                            jogo.Numero2 = int.Parse(spanNodes[2].InnerText);
                                            jogo.Numero3 = 17;
                                            jogo.Numero4 = int.Parse(spanNodes[3].InnerText);
                                            jogo.Numero5 = int.Parse(spanNodes[4].InnerText);
                                        }
                                        else
                                        {
                                            jogo.Numero1 = int.Parse(spanNodes[1].InnerText);
                                            jogo.Numero2 = int.Parse(spanNodes[2].InnerText);
                                            jogo.Numero3 = int.Parse(spanNodes[3].InnerText);
                                            jogo.Numero4 = int.Parse(spanNodes[4].InnerText);
                                            jogo.Numero5 = int.Parse(spanNodes[5].InnerText);
                                        }

                                        jogo.NumeroSorte = int.Parse(spanNodes[6].InnerText);

                                        if (jogo.Data == DateTime.MinValue)
                                            throw new Exception(aNode.InnerText);

                                        jogos.Add(jogo);
                                    }
                                }
                                catch (Exception exc)
                                {
                                    txtInformations.Text = $"{txtInformations.Text}|{liNode.InnerHtml}:{exc.Message}";
                                }
                            }
                        }
                    }
                }
            }

            return jogos;
        }

        private void ChangeComponentsVisualization(bool enabled)
        {
            foreach (var btn in this.Controls.OfType<Button>())
            {
                if (btn != null)
                {
                    btn.Enabled = enabled;
                    btn.Visible = enabled;
                }
            }

            foreach (var tab in this.Controls.OfType<TabControl>())
            {
                if (tab != null)
                {
                    tab.Enabled = enabled;
                    tab.Visible = enabled;
                }
            }
        }

        private void btnGenerateGame_Click(object sender, EventArgs e)
        {
        }

        private void btnAddNewRow_Click(object sender, EventArgs e)
        {
            configurations.Add(new TotolotoRepository.Models.Configuration());
            dataGridViewConfiguration.DataSource = null;
            dataGridViewConfiguration.DataSource = configurations;
        }

        private void btnSaveRows_Click(object sender, EventArgs e)
        {
            foreach (var configuration in configurations)
            {
                if (!string.IsNullOrWhiteSpace(configuration.ConfigurationKey) && !string.IsNullOrWhiteSpace(configuration.ConfigurationValue))
                {
                    if (configuration.ConfigurationId > 0)
                    {
                        totolotoContext.Configurations.Update(configuration);
                        totolotoContext.SaveChanges();
                    }
                    else
                    {
                        totolotoContext.Configurations.Add(configuration);
                        totolotoContext.SaveChanges();
                    }
                }
            }

            configurations = totolotoContext.Configurations.ToList();
            dataGridViewConfiguration.DataSource = null;
            dataGridViewConfiguration.DataSource = configurations;
        }
    }
}