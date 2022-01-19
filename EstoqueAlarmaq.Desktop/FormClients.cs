using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstoqueAlarmaq.Desktop
{
    public partial class FormClients : Form
    {
        private readonly DataContext _context;
        public FormClients(DataContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var code = txtCode.Text;
            var name = txtName.Text;

            
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("È necessario preencher o codigo e/ou nome corretamente!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Focus();
            }
            else
            {
                Client client = new Client(Convert.ToInt32(code), name);

                try
                {
                    _context.Clients.Add(client);
                    _context.SaveChanges();

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
        }
    }
}
