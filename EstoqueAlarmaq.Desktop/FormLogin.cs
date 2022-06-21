using EstoqueAlarmaq.Services.Repositories;
using MaterialSkin.Controls;
using System.Threading;
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
                        this.Close();
                        Thread thread = new Thread(OpenHome);
                        thread.SetApartmentState(ApartmentState.STA);
                        thread.Start();
                        
                    }
                    else
                    {
                        MessageBox.Show("Usuario ou senha invalidos!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        public void OpenHome()
        {
            Application.Run(new FormHome());
        }
    }
}
