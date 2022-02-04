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
using ReaLTaiizor.Forms;

namespace EstoqueAlarmaq.Desktop
{
    public partial class FormHome : MaterialForm
    {
        private readonly DataContext _context;
        public FormHome(DataContext context)
        {
            InitializeComponent();
            _context = context;

            refreshDataGrid();
        }

        private void refreshDataGrid()
        {
            DataGridOrders.DataSource = _context.OrderServices
                .Select(x => new { x.Id, x.Client, x.DateCreatedAt, x.User, x.Observation }).ToList();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            FormProducts formProducts = new FormProducts(_context);
            formProducts.ShowDialog();
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            FormClients formClients = new FormClients(_context);
            formClients.ShowDialog();
        }

        private void btnOrderServices_Click(object sender, EventArgs e)
        {
            OrderService orderService = new OrderService();
            List<Product> listProducts = new List<Product>();

            FormOrderServices formOrderServices = new FormOrderServices(_context, orderService, listProducts);
            formOrderServices.ShowDialog();

            refreshDataGrid();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {

        }

        private void DataGridOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DataGridOrders_DoubleClick(object sender, EventArgs e)
        {
            List<Product> listProducts = new List<Product>();

            var orderClicked = DataGridOrders.CurrentRow.Cells[0].Value;
            var orderService = _context.OrderServices.First(x => x.Id == Convert.ToInt32(orderClicked));            
            //var product = _context.Products.Select(p => p.Code == orderService.Id.ToString());

            var product = _context.Products.First(x => x.OrderServices.Id == orderService.Id);

            if (product == null)
            {
                MessageBox.Show("produto não encontrado");
            }
            else
            {
                listProducts.Add(product);
            }



            FormOrderServices formOrderServices = new FormOrderServices(_context, orderService, listProducts);
            formOrderServices.ShowDialog();

            refreshDataGrid();
        }
    }
}
