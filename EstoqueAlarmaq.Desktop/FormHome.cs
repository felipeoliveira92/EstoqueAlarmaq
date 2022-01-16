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
    public partial class FormHome : Form
    {
        private readonly DataContext _context;
        public FormHome(DataContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void FormHome_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var code = txtCode.Text;
            var name = txtName.Text;
            var description = txtDescription.Text;
            var quantidade = txtQuantidade.Text;            

            do
            {
                if (txtQuantidade.Text == "")
                {
                    MessageBox.Show("O campo quantidade nunca pode ser vazio", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQuantidade.Focus();
                }
                else if (Convert.ToInt32(quantidade) <= 0)
                {
                    MessageBox.Show("O campo quantidade nunca pode ser zero ou menor!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQuantidade.Focus();
                }


                if (code == "" || name == "")
                {
                    MessageBox.Show("È necessario preencher o codigo e/ou nome corretamente!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCode.Focus();
                }

            } while (txtQuantidade.Text == "");

            Product product = new Product(code, name, description, Convert.ToInt32(quantidade), null);
            
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CleanForm();
        }

        private void CleanForm()
        {
            txtCode.Clear();
            txtName.Clear();
            txtDescription.Clear();
            txtQuantidade.Clear();
            txtCode.Focus();
        }
    }
}
