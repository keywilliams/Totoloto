using System.Configuration;
using TotolotoRepository;
using HtmlAgilityPack;
using System.Security.Policy;
using TotolotoRepository.Models;
using System.Xml.Linq;

namespace Totoloto
{
    public partial class TotolotoForm : Form
    {
        public ITotolotoContextFactory totolotoContextFactory;
        public TotolotoContext totolotoContext;
        public TotolotoForm(ITotolotoContextFactory totolotoContextFactory)
        {
            this.totolotoContextFactory = totolotoContextFactory;
            totolotoContext = totolotoContextFactory.CreateDbContext();
            InitializeComponent();
        }

        private void Totoloto_Load(object sender, EventArgs e)
        {
            bool update = false;

            if (totolotoContext.Jogos.Any())
            {
                var lastGame = totolotoContext.Jogos.OrderBy(x => x.Data).Last();
                txtInformations.Text = $"Último jogo carregado {lastGame.Jogo}, Data: {lastGame.Data.ToString("dd/MM/yyyy")}";

                if (lastGame.Data.DayOfWeek == DayOfWeek.Wednesday)
                    if(lastGame.Data.AddDays(3) < DateTime.Now)
                        update = true;
                else if (lastGame.Data.DayOfWeek == DayOfWeek.Saturday)
                    if (lastGame.Data.AddDays(4) < DateTime.Now)
                        update = true;
            }
            else
            {
                txtInformations.Text = "Nenhum jogo encontrado na base de dados";
                update = true;
            }

            btnAtualizarJogos.Visible = update;
            btnAtualizarJogos.Enabled = update;

        }

        private void btnAtualizarJogos_Click(object sender, EventArgs e)
        {
            List<Jogos> jogos = GetGamesByDate();


            totolotoContext.Jogos.AddRange(jogos);
            totolotoContext.SaveChanges();


            totolotoContextFactory.GenerateScripts();

            btnAtualizarJogos.Visible = false;
            btnAtualizarJogos.Enabled = false;
            txtInformations.Text = "Jogos atualizados";

            var lastGame = totolotoContext.Jogos.OrderBy(x => x.Data).Last();
            txtInformations.Text = $"Último jogo carregado {lastGame.Jogo}, Data: {lastGame.Data.ToString("dd/MM/yyyy")}";
        }

        private List<Jogos> GetGamesByDate()
        {
            List<Jogos> jogos = new List<Jogos>();
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
                                Jogos jogo = new Jogos();

                                var h3Nodes = htmlDoc.DocumentNode.Descendants(0).Where(x => x.HasClass("subjuego"))?.ToList().FirstOrDefault();

                                if (h3Nodes != null)
                                {
                                    string numeroJogo = h3Nodes.InnerText.Replace("Resultado", "").Replace("concurso", "").Replace("Totoloto", "").Replace("Premiação", "").Replace("Ganhadores", "").Replace("-", "").Trim();
                                    jogo.Jogo = int.Parse(numeroJogo);
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

            return jogos;
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

        private List<Jogos> GetJogosIniciais()
        {
            List<Jogos> jogos = new List<Jogos>();
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
                                Jogos jogo = new Jogos();
                                var htmlLiNode = new HtmlAgilityPack.HtmlDocument();
                                htmlLiNode.LoadHtml(liNode.InnerHtml);
                                HtmlNodeCollection spanNodes = htmlLiNode.DocumentNode.SelectNodes("//span");

                                try
                                {
                                    if (spanNodes != null && spanNodes.Count == 7)
                                    {
                                        jogo.Jogo = int.Parse(spanNodes[0].InnerText);

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

                                        if (jogo.Jogo == 13 && jogo.Data == new DateTime(2017, 2, 15) && spanNodes[5].InnerText == "??")
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
    }
}