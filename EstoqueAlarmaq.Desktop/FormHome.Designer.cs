namespace EstoqueAlarmaq.Desktop
{
    partial class FormHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnOrderServices = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.dataGridOrders = new System.Windows.Forms.DataGridView();
            this.panelMDI = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrders)).BeginInit();
            this.panelMDI.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProducts
            // 
            this.btnProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProducts.Location = new System.Drawing.Point(0, 132);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(172, 44);
            this.btnProducts.TabIndex = 3;
            this.btnProducts.Text = "Produtos";
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnClients
            // 
            this.btnClients.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClients.Location = new System.Drawing.Point(0, 44);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(172, 44);
            this.btnClients.TabIndex = 1;
            this.btnClients.Text = "Clientes";
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // btnOrderServices
            // 
            this.btnOrderServices.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrderServices.Location = new System.Drawing.Point(0, 0);
            this.btnOrderServices.Name = "btnOrderServices";
            this.btnOrderServices.Size = new System.Drawing.Size(172, 44);
            this.btnOrderServices.TabIndex = 0;
            this.btnOrderServices.Text = "Ordens Serviços";
            this.btnOrderServices.UseVisualStyleBackColor = true;
            this.btnOrderServices.Click += new System.EventHandler(this.btnOrderServices_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsers.Location = new System.Drawing.Point(0, 88);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(172, 44);
            this.btnUsers.TabIndex = 2;
            this.btnUsers.Text = "Usuarios";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.btnProducts);
            this.panel1.Controls.Add(this.btnUsers);
            this.panel1.Controls.Add(this.btnClients);
            this.panel1.Controls.Add(this.btnOrderServices);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 568);
            this.panel1.TabIndex = 13;
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.Location = new System.Drawing.Point(0, 176);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(172, 44);
            this.btnHome.TabIndex = 13;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // dataGridOrders
            // 
            this.dataGridOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrders.Location = new System.Drawing.Point(6, 192);
            this.dataGridOrders.Name = "dataGridOrders";
            this.dataGridOrders.RowTemplate.Height = 25;
            this.dataGridOrders.Size = new System.Drawing.Size(830, 364);
            this.dataGridOrders.TabIndex = 14;
            this.dataGridOrders.DoubleClick += new System.EventHandler(this.dataGridOrders_DoubleClick_1);
            // 
            // panelMDI
            // 
            this.panelMDI.Controls.Add(this.dataGridOrders);
            this.panelMDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMDI.Location = new System.Drawing.Point(172, 0);
            this.panelMDI.Name = "panelMDI";
            this.panelMDI.Size = new System.Drawing.Size(1045, 568);
            this.panelMDI.TabIndex = 15;
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 568);
            this.Controls.Add(this.panelMDI);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1680, 1010);
            this.MinimumSize = new System.Drawing.Size(261, 61);
            this.Name = "FormHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DooR Estoque";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrders)).EndInit();
            this.panelMDI.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnOrderServices;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridOrders;
        private System.Windows.Forms.Panel panelMDI;
        private System.Windows.Forms.Button btnHome;
    }
}