using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EstoqueAlarmaq.Desktop
{
    public partial class FormUsers : Form
    {
        private readonly DataContext _context;

        User user = new User();

        public FormUsers(DataContext context)
        {
            InitializeComponent();
            _context = context;
            refreshDataGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text == txtConfirm.Text)
            {
                var name = txtName.Text;
                var password = txtPassword.Text;
                var type = cbType.Text;

                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("O campo nome nunca pode ser vazio", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Focus();
                }
                else if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("È necessario preencher a senha corretamente!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Focus();
                }
                else
                {
                    try
                    {
                        user.Name = name;
                        user.Password = password;
                        user.Type = type;

                        if (btnSave.Text == "Editar")
                        {
                            _context.Users.Update(user);
                            _context.SaveChanges();

                            user = new User();

                            MessageBox.Show("Usuario alterado com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            _context.Users.Add(user);
                            _context.SaveChanges();

                            user = new User();

                            MessageBox.Show("Usuario cadastrado com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        CleanForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Senhas são diferentes!", this.Text);
                txtConfirm.Focus();
            }
            
        }
        private void CleanForm()
        {           
            txtName.Clear();
            txtPassword.Clear();
            txtConfirm.Clear();
            cbType.Text = "";

            refreshDataGrid();
            txtName.Focus();

            btnSave.Text = "Cadastrar";
            btnDelete.Visible = false;
        }

        private void refreshDataGrid()
        {
            dataGridProducts.DataSource = _context.Users.ToList();
        }

        private void dataGridProducts_DoubleClick(object sender, EventArgs e)
        {
            var userClicked = dataGridProducts.CurrentRow.Cells[0].Value;
            var user = _context.Users.First(u => u.Id == Convert.ToInt32(userClicked));

            if (user != null)
            {
                this.user = user;

                txtName.Text = user.Name;
                txtPassword.Text = user.Password;
                txtConfirm.Text = user.Password;
                cbType.Text = user.Type;

                btnSave.Text = "Editar";
                btnDelete.Visible = true;
            }
        }
    }
}
