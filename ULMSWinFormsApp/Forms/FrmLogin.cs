using ULMSWinFormsApp.Forms;

namespace ULMSWinFormsApp
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Fixed faulty validation logic
            if (username == "admin" && password == "1234")
            {
                MessageBox.Show("Login Successful!");

                FrmDashboard dashboard = new FrmDashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid login credentials.");  
            }
        }

        //btnclear
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

    }
}
