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
        }
    }
}
