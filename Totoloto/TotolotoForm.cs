using System.Configuration;
using TotolotoRepository;
using HtmlAgilityPack;
using System.Security.Policy;
using TotolotoRepository.Models;

namespace Totoloto
{
    public partial class TotolotoForm : Form
    {
        public ITotolotoContextFactory totolotoContextFactory;
        public TotolotoForm(ITotolotoContextFactory totolotoContextFactory)
        {
            this.totolotoContextFactory = totolotoContextFactory;
            InitializeComponent();
        }

        private void Totoloto_Load(object sender, EventArgs e)
        {
            var context = totolotoContextFactory.CreateDbContext();
            bool update = false;

            if (context.Jogos.Any())
            {
                var lastJogo = context.Jogos.Last();
                txtInformations.Text = "Teste";
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

                                        jogo.Numero1 = int.Parse(spanNodes[1].InnerText);
                                        jogo.Numero2 = int.Parse(spanNodes[2].InnerText);
                                        jogo.Numero3 = int.Parse(spanNodes[3].InnerText);
                                        jogo.Numero4 = int.Parse(spanNodes[4].InnerText);
                                        jogo.Numero5 = int.Parse(spanNodes[5].InnerText);

                                        jogo.NumeroSorte = int.Parse(spanNodes[6].InnerText);


                                        HtmlNode aNode = htmlLiNode.DocumentNode.SelectSingleNode("//a");
                                        if (aNode != null)
                                        {
                                            string data = aNode.InnerText.Split(" ")[1];
                                            if (DateTime.TryParse(data, out DateTime result))
                                            {
                                                jogo.Data = result;
                                            }
                                            else
                                            {
                                                throw new Exception(aNode.InnerText);
                                            }
                                        }
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

            btnAtualizarJogos.Visible = false;
            btnAtualizarJogos.Enabled = false;
            txtInformations.Text = "Jogos atualizados";
        }
    }
}