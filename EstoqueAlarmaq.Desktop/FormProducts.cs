﻿using EstoqueAlarmaq.Application;
using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EstoqueAlarmaq.Desktop
{
    public partial class FormProducts : Form
    {
        private readonly DataContext _context;
        private readonly IProduct iproduct;

        Product product = new Product();

        public FormProducts(DataContext context)
        {
            InitializeComponent();
            _context = context;
            refreshDataGrid();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var code = txtCode.Text;
            var name = txtName.Text;
            var description = txtDescription.Text;
            var quantidade = txtQuantidade.Text;            

            if(string.IsNullOrEmpty(quantidade))
            {
                MessageBox.Show("O campo quantidade nunca pode ser vazio", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantidade.Focus();
            }
            else if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("È necessario preencher o codigo e/ou nome corretamente!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Focus();
            }
            else
            {
                if(Convert.ToInt32(quantidade) <= 0)
                {
                    MessageBox.Show("O campo quantidade nunca pode ser zero ou menor", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQuantidade.Focus();
                }
                else
                {
                    //try
                    {
                        product.Code = code;
                        product.Name = name;
                        product.Description = description;
                        product.Description = description;
                        product.Quantidade = Convert.ToInt32(quantidade);

                        if (btnSave.Text == "Editar")
                        {
                            _context.Products.Update(product);
                            _context.SaveChanges();

                            MessageBox.Show("Produto alterado com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            _context.Products.Add(product);
                            _context.SaveChanges();

                            
                            MessageBox.Show("Produto cadastrado com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } 

                        CleanForm();
                    }
                    //catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                    }
                }                
            }           
        }
        
        private void CleanForm()
        {
            txtCode.Clear();
            txtName.Clear();
            txtDescription.Clear();
            txtQuantidade.Clear();

            refreshDataGrid();
            txtCode.Focus();

            btnSave.Text = "Cadastrar";
            btnDelete.Visible = false;
        }

        private void refreshDataGrid()
        {
            dataGridProducts.DataSource = _context.Products.ToList();
        }

        private void dataGridProducts_DoubleClick(object sender, EventArgs e)
        {
            var productClicked = dataGridProducts.CurrentRow.Cells[0].Value;
            var product = _context.Products.First(x => x.Id == Convert.ToInt32(productClicked));
            

            if (product != null)
            {
                this.product = product;

                txtCode.Text = product.Code;
                txtName.Text = product.Name;
                txtDescription.Text = product.Description;
                txtQuantidade.Text = product.Quantidade.ToString();

                btnSave.Text = "Editar";
                btnDelete.Visible = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Exclusão!", "realmente deseja excluir?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                iproduct.Delete(product, _context);

                //_context.Products.Remove(product);
                //_context.SaveChanges();

                btnDelete.Visible = false;
                CleanForm();
            }
        }

        private void Save(Product product)
        {

        }
    }
}
