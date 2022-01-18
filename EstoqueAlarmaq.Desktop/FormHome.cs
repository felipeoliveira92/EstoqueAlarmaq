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

        private int counter;

        private void button1_Click(object sender, EventArgs e)
        {
            var code = txtCode.Text;
            var name = txtName.Text;
            var description = txtDescription.Text;
            var quantidade = txtQuantidade.Text;            

            if(string.IsNullOrEmpty(quantidade))
            {
                MessageBox.Show("O campo quantidade nunca pode ser vazio", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantidade.Focus();
            }
            else if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("È necessario preencher o codigo e/ou nome corretamente!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Focus();
            }
            else
            {
                if(Convert.ToInt32(quantidade) <= 0)
                {
                    MessageBox.Show("O campo quantidade nunca pode ser zero ou menor", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQuantidade.Focus();
                }
                else
                {
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

                    counter = 0;
                    timer1.Interval = 5000;
                    timer1.Enabled = true;
                    
                    this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
                }                
            }           
        }
        
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (counter >= 10)
            {
                // Exit loop code.  
                timer1.Enabled = false;
                counter = 0;
                label5.Text = "";
            }
            else
            {
                // Run your procedure here.  
                // Increment counter.  
                counter = counter + 1;
            }
        }

        private void CleanForm()
        {
            txtCode.Clear();
            txtName.Clear();
            txtDescription.Clear();
            txtQuantidade.Clear();
            txtCode.Focus();

            label5.Text = "produto Cadastrado com sucesso!";
        }
    }
}
