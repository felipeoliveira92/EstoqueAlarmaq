﻿using EstoqueAlarmaq.Domain;
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

        List<Product> listProducts;
        OrderService orderService = new OrderService();

        public FormOrderServices(DataContext context)
        {
            InitializeComponent();
            _context = context;                        
        }

        private void autoComplete()
        {
            AutoCompleteStringCollection listProducts = new AutoCompleteStringCollection();

            var products = _context.Products.Select(x => new { x.Name }).ToList();

            //.Select(p => new { p.ProductID, p.ProductName, p.UnitsInStock, p.UnitPrice })
            //.Select(p => new ProductDTO {p.ProductID, p.ProductName, p.UnitsInStock, p.UnitPrice})

            //.Where(p => p.UnitsInStock > 0)
            //.OrderBy(p => p.ProductName)
            //.ToList()
            try
            {
                foreach (var product in _context.Products)
                {
                    Console.WriteLine("Blog: " + product.Name);
                    listProducts.Add(product.Name);
                }
                foreach (var item in products)
                {

                    listProducts.Add(products.ToString());
                    MessageBox.Show(listProducts.ToString());
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }

            txtProductCode.AutoCompleteCustomSource = listProducts;
        }


        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    var product = _context.Products.First(x => x.Code == txtProductCode.Text);

                    listBoxProducts.Items.Add(product.Name);
                    orderService.Products += product.Name + ",";
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.Message);
                }
            }
        }

        private void btnRegisterOrderService_Click(object sender, EventArgs e)
        {
            try
            {
                orderService.Client = txtClient.Text;
                orderService.User = txtUser.Text;
                orderService.Observation = txtObservation.Text;

                _context.OrderServices.Add(orderService);
                _context.SaveChanges();

            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var product = _context.Products.First(x => x.Code == txtProductCode.Text);

                if(product == null)
                {
                    MessageBox.Show("produto não encontrado");
                }
                else
                {
                    listBoxProducts.Items.Add(product.Name);
                    orderService.Products += product.Name + ",";
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }
        }




        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FormOrderServices_Load(object sender, EventArgs e)
        {

        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
