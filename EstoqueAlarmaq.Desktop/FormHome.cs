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

            refreshDataGrid();
        }

        private void refreshDataGrid()
        {
            dataGridOrders.DataSource = _context.OrderServices
                .Select(x => new { x.Id, x.Client, x.DateCreatedAt, x.Tecnico, x.Observation }).ToList();
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

            FormOrderServices formOrderServices = new FormOrderServices(_context, null);
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
            var orderClicked = dataGridOrders.CurrentRow.Cells[0].Value;
            var orderService = _context.OrderServices.First(x => x.Id == Convert.ToInt32(orderClicked));

            FormOrderServices formOrderServices = new FormOrderServices(_context, orderService);
            formOrderServices.ShowDialog();

            refreshDataGrid();
        }
    }
}
