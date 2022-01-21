using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Data;
using Microsoft.EntityFrameworkCore;
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

            //string[] selectProducts = new string[_context.Products.Count()];
            //List<Product> products = new List<Product>();
            //Product[] productsArray = new Product[_context.Products.Count()];

            var users = _context.Products.Include(p => p.Name).Select(x => new { x.Name }).ToList();

            listBox1.DataSource = users;
                //.Select(x => new { x.Nome, x.Email, x.Status, x.Matricula, x.CargoId, x.FuncaoId, Cliente = x.Cliente.Select(cli => new { cli.ClienteId, cli.Cliente.Nome }).ToList() }).ToListAsync();
            //try
            //{
            //    foreach (var item in productsArray)
            //    {
            //        selectProducts = _context.Find(productsArray = productsArray);
            //        _context.Products.All();
            //        listProducts.Add();
            //    }
            //}
            //catch (Exception msg)
            //{
            //    MessageBox.Show(msg.Message);
            //}


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
