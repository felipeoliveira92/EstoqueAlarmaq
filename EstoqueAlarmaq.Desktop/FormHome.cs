﻿using EstoqueAlarmaq.Domain;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace EstoqueAlarmaq.Desktop
{
    public partial class FormHome : MaterialForm
    {
        public FormHome()
        {
            InitializeComponent();
            refreshDataGrid();
        }

        private void refreshDataGrid()
        {
            //dataGridOrders.DataSource = _context.OrderServices
            //    .Select(x => new { x.Id, x.Client, x.DateCreatedAt, x.Tecnico, x.Observation }).ToList();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            FormProducts formProducts = new FormProducts();
            formProducts.ShowDialog();
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            FormClients formClients = new FormClients();
            formClients.ShowDialog();
        }

        private void btnOrderServices_Click(object sender, EventArgs e)
        {            
            //OrderService orderService = new OrderService();

            //FormOrderServices formOrderServices = new FormOrderServices(_context, null);
            ////formOrderServices.Dock = DockStyle.Fill;
            ////formOrderServices.TopLevel = false;
            ////panelMDI.Controls.Add(formOrderServices);
            ////formOrderServices.Show();
            ////dataGridOrders.Visible = false;
            //formOrderServices.ShowDialog();

            //refreshDataGrid();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {

        }       

        private void dataGridOrders_DoubleClick_1(object sender, EventArgs e)
        {
            //var orderClicked = dataGridOrders.CurrentRow.Cells[0].Value;
            //var orderService = _context.OrderServices.First(x => x.Id == Convert.ToInt32(orderClicked));

            //FormOrderServices formOrderServices = new FormOrderServices(_context, orderService);
            //formOrderServices.ShowDialog();

            //refreshDataGrid();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            dataGridOrders.Visible = true;
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            //FormUsers formUsers = new FormUsers();
            //formUsers.ShowDialog();
        }

        private void panelMDI_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
