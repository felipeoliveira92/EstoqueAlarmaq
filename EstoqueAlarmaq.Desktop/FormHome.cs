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
                .Select(x => new { x.Client, x.DateCreatedAt, x.User, x.Observation }).ToList();
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

            FormOrderServices formOrderServices = new FormOrderServices(_context, orderService);
            formOrderServices.ShowDialog();

            refreshDataGrid();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {

        }
    }
}
