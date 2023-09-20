using System.Configuration;
using TotolotoRepository;

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
            
        }
    }
}