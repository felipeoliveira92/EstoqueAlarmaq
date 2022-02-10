using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EstoqueAlarmaq.Desktop
{
    public partial class FormOrderServices : Form
    {
        private readonly DataContext _context;

        OrderService orderService = new OrderService();
        List<Product> listProducts = new List<Product>();

        public FormOrderServices(DataContext context, OrderService orderService)
        {
            InitializeComponent();
            _context = context;            

            if(orderService != null)
            {
                this.orderService = orderService;

                txtClient.Text = orderService.Client;
                txtTecnical.Text = orderService.Tecnico;
                txtUser.Text = orderService.User;
                txtObservation.Text = orderService.Observation;

                var products = _context.Products
                                   .Where(p => p.OrderServicesId == orderService.Id)
                                   .ToList();

                foreach (var product in products)
                {
                    listBoxProducts.Items.Add(product.Name);
                }

                btnRegisterOrderService.Text = "Editar";
            }

            refreshDataGrid();
            autoComplete();
        }

        private void refreshDataGrid()
        {
            dataGridOrders.DataSource = _context.OrderServices
                .Select(x => new { x.Id, x.Client, x.Tecnico, x.DateCreatedAt, x.User, x.Observation }).ToList();
        }

        private void autoComplete()
        {
            var listProducts = new AutoCompleteStringCollection();
            var listClients = new AutoCompleteStringCollection();
            var listUsers = new AutoCompleteStringCollection();

            var products = _context.Products.Select(x => new { x.Code, x.Name }).ToList();
            var clients = _context.Clients.Select(x => new { x.Code,x.Name }).ToList();
            var users = _context.Users.Select(x => new {x.Name}).ToList();

            try
            {
                foreach (var product in products)
                {
                    listProducts.Add(product.Code);
                    listProducts.Add(product.Name);
                }
                foreach (var client in clients)
                {
                    listClients.Add(client.Code.ToString());
                    listClients.Add(client.Name);
                }
                foreach (var user in users)
                {
                    listUsers.Add(user.Name);
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }

            txtProductCode.AutoCompleteCustomSource = listProducts;
            txtClient.AutoCompleteCustomSource = listClients;
            txtUser.AutoCompleteCustomSource = listUsers;
            txtTecnical.AutoCompleteCustomSource = listUsers;
        }


        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    var product = _context.Products.First(x => x.Code == txtProductCode.Text);

                    if (product == null)
                    {
                        MessageBox.Show("produto não encontrado!");
                    }
                    if (product.Quantidade == 0)
                    {
                        MessageBox.Show("Impossivel adicionar, produto com quantidade 0!");
                    }
                    else
                    {
                        listBoxProducts.Items.Add(product.Name);
                        product.Quantidade -= 1;
                        listProducts.Add(product);
                    }
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.Message);
                }
            }
        }

        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    var product = _context.Products.First(x => x.Code == txtProductCode.Text);

                    if (product == null)
                    {
                        MessageBox.Show("produto não encontrado!");
                    }
                    if (product.Quantidade == 0)
                    {
                        MessageBox.Show("Impossivel adicionar, produto com quantidade 0!");
                    }
                    else
                    {
                        listBoxProducts.Items.Add(product.Name);
                        product.Quantidade -= 1;
                        listProducts.Add(product);
                    }
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var product = _context.Products.First(x => x.Code == txtProductCode.Text);

                if (product == null)
                {
                    MessageBox.Show("produto não encontrado!");
                }
                if(product.Quantidade == 0)
                {
                    MessageBox.Show("Impossivel adicionar, produto com quantidade 0!");                    
                }
                else
                {
                    listBoxProducts.Items.Add(product.Name);
                    product.Quantidade -= 1;
                    listProducts.Add(product);
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }
        }

        private void btnRegisterOrderService_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnRegisterOrderService.Text == "Editar")
                {
                    orderService.Client = txtClient.Text;
                    orderService.Tecnico = txtTecnical.Text;
                    orderService.User = txtUser.Text;
                    orderService.Observation = txtObservation.Text;
                    orderService.Products = listProducts.ToList();

                    _context.OrderServices.Update(orderService);
                    _context.SaveChanges();

                    orderService = new OrderService();

                    var result = MessageBox.Show("Deseja imprimir?", "Order de Serviço editada com sucesso!", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        print();
                    }
                }
                else
                {
                    orderService.Client = txtClient.Text;
                    orderService.Tecnico = txtTecnical.Text;
                    orderService.User = txtUser.Text;
                    orderService.Observation = txtObservation.Text;
                    orderService.Products = listProducts.ToList();

                    _context.OrderServices.Add(orderService);
                    _context.SaveChanges();

                    orderService = new OrderService();

                    var result = MessageBox.Show("Deseja imprimir?", "Order de Serviço gerada com sucesso!", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        print();
                    }
                }

                cleanForm();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }            
        }        

        private void print()
        {
            string path;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                DateTime now = DateTime.Now;

                path = folderBrowserDialog1.SelectedPath + "\\" + orderService.Client + " " +
                    string.Format("{0}-{1}-{2}-{3}-{4}", now.Day, now.Month, now.Year, now.Hour, now.Minute) + ".pdf";

                var document = new Document(PageSize.A4);
                PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

                document.Open();

                document.Add(new Paragraph("Ordem de Serviço " + orderService.Id));

                document.Close();

                System.Diagnostics.Process.Start(path);
            }   
        }

        private void cleanForm()
        {
            txtClient.Clear();
            txtTecnical.Clear();
            txtUser.Clear();
            txtObservation.Clear();
            txtProductCode.Clear();
            listBoxProducts.Dispose();

            refreshDataGrid();
            txtClient.Focus();
        }

        private void listBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeleteProduct.Visible = true;
            
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            var question = MessageBox.Show("Deseja remover este item?", "Aviso!", MessageBoxButtons.YesNo);

            if (question == DialogResult.Yes)
            {
                var product = _context.Products.First(x => x.Name == listBoxProducts.SelectedItem.ToString());
                listBoxProducts.Items.Remove(listBoxProducts.SelectedItem);
                listProducts.Remove(product);

                btnDeleteProduct.Visible = false;
            }
        }

        private void dataGridOrders_DoubleClick(object sender, EventArgs e)
        {
            listBoxProducts.Items.Clear();

            var orderClicked = dataGridOrders.CurrentRow.Cells[0].Value;
            var orderService = _context.OrderServices.First(x => x.Id == Convert.ToInt32(orderClicked));

            if (orderService != null)
            {
                this.orderService = orderService;

                txtClient.Text = orderService.Client;
                txtTecnical.Text = orderService.Tecnico;
                txtUser.Text = orderService.User;
                txtObservation.Text = orderService.Observation;

                var products = _context.Products
                                   .Where(p => p.OrderServicesId == orderService.Id)
                                   .ToList();

                foreach (var product in products)
                {
                    listBoxProducts.Items.Add(product.Name);
                }

                btnRegisterOrderService.Text = "Editar";
            }

            refreshDataGrid();
            autoComplete();
        }
    }
}
