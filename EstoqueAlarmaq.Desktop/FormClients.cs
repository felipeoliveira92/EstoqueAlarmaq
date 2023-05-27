using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Services.Repositories;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace EstoqueAlarmaq.Desktop
{
    public partial class FormClients : MaterialForm
    {
        private readonly ClientRepository _context;
        public FormClients()
        {
            InitializeComponent();
            _context = new ClientRepository();
            refreshDataGrid();
        }

        private void FormClients_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var code = txtCode.Text;
            var name = txtName.Text;
            
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("È necessario preencher o codigo e/ou nome corretamente!", "Aviso!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Focus();
            }
            else
            {
                Client client = new Client(Convert.ToInt32(code), name);

                try
                {
                    _context.Save(client);
                    CleanForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CleanForm()
        {
            txtCode.Clear();
            txtName.Clear();

            MessageBox.Show("Cliente cadastrado com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtCode.Focus();
            refreshDataGrid();
        }

        private void refreshDataGrid()
        {
            dataGridClients.DataSource = _context.GetAllClients();
            dataGridClients.AutoResizeColumns();
            dataGridClients.AutoResizeRows();
        }        
    }
}
