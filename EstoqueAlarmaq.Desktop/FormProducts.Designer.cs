
namespace EstoqueAlarmaq.Desktop
{
    partial class FormProducts
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridProducts = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(87, 6);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(175, 23);
            this.txtCode.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtName.Location = new System.Drawing.Point(87, 41);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(175, 23);
            this.txtName.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(87, 76);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(175, 49);
            this.txtDescription.TabIndex = 2;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(87, 137);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(78, 23);
            this.txtQuantidade.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Descrição";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Quantidade";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(87, 182);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Cadastrar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridProducts
            // 
            this.dataGridProducts.AllowUserToAddRows = false;
            this.dataGridProducts.AllowUserToDeleteRows = false;
            this.dataGridProducts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProducts.Location = new System.Drawing.Point(12, 211);
            this.dataGridProducts.Name = "dataGridProducts";
            this.dataGridProducts.ReadOnly = true;
            this.dataGridProducts.RowHeadersVisible = false;
            this.dataGridProducts.RowTemplate.Height = 25;
            this.dataGridProducts.Size = new System.Drawing.Size(776, 181);
            this.dataGridProducts.TabIndex = 10;
            this.dataGridProducts.DoubleClick += new System.EventHandler(this.dataGridProducts_DoubleClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(168, 182);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Deletar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FormProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 404);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridProducts);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Name = "FormProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dataGridProducts;
        private System.Windows.Forms.Button btnDelete;
    }
}

