namespace Bai05
{
    public partial class Init : Form
    {
        public Init()
        {
            InitializeComponent();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            Server f = new Server();
            f.Show();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            Client f = new Client();
            f.Show();
        }
    }
}
