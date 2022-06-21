using EstoqueAlarmaq.Services.Repositories;
using MaterialSkin.Controls;
using System.Windows.Forms;

namespace EstoqueAlarmaq.Desktop
{
    public partial class FormLogin : MaterialForm
    {
        public FormLogin()
        {
            InitializeComponent();
            this.Name = "Login";
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtUser.Text))
            {
                if(!string.IsNullOrEmpty(txtPassword.Text))
                {
                    var _loginRepository = new LoginRepository();

                    if(_loginRepository.Login(txtUser.Text, txtPassword.Text))
                    {
                        FormHome formHome = new FormHome();
                        formHome.ShowDialog();
                    }
                    
                }
                else
                {
                    MessageBox.Show("O Campo Senha não pode ser vazio!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("O Campo Usuario não pode ser vazio!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
