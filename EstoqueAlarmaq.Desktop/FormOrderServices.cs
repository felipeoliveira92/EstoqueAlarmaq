using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.orderService = orderService;
            refreshDataGrid();
            autoComplete();
        }

        private void refreshDataGrid()
        {
            dataGridOrders.DataSource = _context.OrderServices
                .Select(x => new { x.Client, x.DateCreatedAt, x.User, x.Observation }).ToList();
        }

        private void autoComplete()
        {
            AutoCompleteStringCollection listProducts = new AutoCompleteStringCollection();

            var products = _context.Products.Select(x => new { x.Name }).ToList();

            try
            {
                foreach (var product in products)
                {
                    listProducts.Add(product.Name);
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
                    listProducts.Add(product);
                    //orderService.Products += product.Name + ",";
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
                if(orderService == null)
                {
                    orderService.Client = txtClient.Text;
                    orderService.User = txtUser.Text;
                    orderService.Observation = txtObservation.Text;
                    orderService.Products = listProducts.ToList();


                    _context.OrderServices.Update(orderService);
                    _context.SaveChanges();
                }
                else
                {
                    orderService.Client = txtClient.Text;
                    orderService.User = txtUser.Text;
                    orderService.Observation = txtObservation.Text;
                    orderService.Products = listProducts.ToList();

                    _context.OrderServices.Add(orderService);
                    _context.SaveChanges();

                    var result = MessageBox.Show("Deseja imprimir?", "Order de Serviço gerada!", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        print();
                    }
                }
                

                refreshDataGrid();

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

                if (product == null)
                {
                    MessageBox.Show("produto não encontrado");
                }
                else
                {
                    listBoxProducts.Items.Add(product.Name);
                    listProducts.Add(product);

                    //orderService.Products.Add(product);
                    //orderService.Products += product.Name + ",";
                }
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
