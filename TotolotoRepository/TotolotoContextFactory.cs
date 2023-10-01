using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotolotoRepository.Models;
using static System.Windows.Forms.LinkLabel;

namespace TotolotoRepository
{
    public class TotolotoContextFactory : ITotolotoContextFactory
    {
        public TotolotoContextFactory()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Totolotoconnectionstring"].ConnectionString;
        }

        static string? connectionString = null;

        public TotolotoContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TotolotoContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new TotolotoContext(optionsBuilder.Options);
        }

        public void GenerateScripts()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TotolotoContext>();
            optionsBuilder.UseSqlServer(connectionString);
            var totolotoContext = new TotolotoContext(optionsBuilder.Options);

            var jogos = totolotoContext.Jogos.ToList();


            string sqlPath = Path.GetDirectoryName(Application.ExecutablePath);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(sqlPath, "..\\..\\..\\..\\", "TotolotoRepository/Scripts", "02_02_Table_Jogos_Insert.sql")))
            {
                outputFile.Write(string.Empty);
                outputFile.WriteLine($"USE [Totoloto]");
                outputFile.WriteLine($"GO");
                outputFile.WriteLine($"SET IDENTITY_INSERT [dbo].[Jogos] ON ");
                outputFile.WriteLine($"GO");
                foreach (var jogo in jogos)
                {
                    outputFile.WriteLine($"INSERT [dbo].[Jogos] ([IdJogo], [NumeroJogo], [Data], [Numero1], [Numero2], [Numero3], [Numero4], [Numero5], [NumeroSorte]) VALUES ({jogo.IdJogo}, {jogo.NumeroJogo}, CAST(N'{jogo.Data.ToString("yyyy-MM-ddTHH:mm:ss.fff")}' AS DateTime), {jogo.Numero1}, {jogo.Numero2}, {jogo.Numero3}, {jogo.Numero4}, {jogo.Numero5}, {jogo.NumeroSorte})");
                    outputFile.WriteLine($"GO");
                }
                outputFile.WriteLine($"SET IDENTITY_INSERT [dbo].[Jogos] OFF");
                outputFile.WriteLine($"GO");
            }
        }
    }
}
