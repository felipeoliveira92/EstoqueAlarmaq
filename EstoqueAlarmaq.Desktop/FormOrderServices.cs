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
    public partial class FormOrderServices : Form
    {
        private readonly DataContext _context;

        public FormOrderServices(DataContext context)
        {
            InitializeComponent();
            _context = context;

            AutoCompleteStringCollection listProducts = new AutoCompleteStringCollection();

            listProducts.Add("teste");

            try
            {
                while (true)
                {
                    //string modelo = sqlDataReader["modelo"].ToString();
                    //string cor = sqlDataReader["cor"].ToString();
                    //dadosModelo.Add(modelo);
                    //dadosCor.Add(cor);
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }


            txtProduct.AutoCompleteCustomSource = listProducts;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FormOrderServices_Load(object sender, EventArgs e)
        {

        }
    }
}
