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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridOrders = new System.Windows.Forms.DataGridView();
            this.panelMDI = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProducts
            // 
            this.btnProducts.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Location = new System.Drawing.Point(0, 208);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(263, 63);
            this.btnProducts.TabIndex = 18;
            this.btnProducts.Text = "Produtos";
            this.btnProducts.UseVisualStyleBackColor = false;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnClients
            // 
            this.btnClients.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnClients.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Location = new System.Drawing.Point(0, 145);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(263, 63);
            this.btnClients.TabIndex = 1;
            this.btnClients.Text = "Clientes";
            this.btnClients.UseVisualStyleBackColor = false;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // btnOrderServices
            // 
            this.btnOrderServices.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnOrderServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderServices.Location = new System.Drawing.Point(45, 424);
            this.btnOrderServices.Name = "btnOrderServices";
            this.btnOrderServices.Size = new System.Drawing.Size(154, 44);
            this.btnOrderServices.TabIndex = 20;
            this.btnOrderServices.Text = "Ordens Serviços";
            this.btnOrderServices.UseVisualStyleBackColor = false;
            this.btnOrderServices.Click += new System.EventHandler(this.btnOrderServices_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Location = new System.Drawing.Point(0, 334);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(263, 63);
            this.btnUsers.TabIndex = 2;
            this.btnUsers.Text = "Usuarios";
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnUsers);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.btnProducts);
            this.panel1.Controls.Add(this.btnClients);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnOrderServices);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 714);
            this.panel1.TabIndex = 13;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Location = new System.Drawing.Point(0, 271);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(263, 63);
            this.btnHome.TabIndex = 20;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(263, 145);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::EstoqueAlarmaq.Desktop.Properties.Resources.logoAlarmaq_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(263, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridOrders
            // 
            this.dataGridOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridOrders.Location = new System.Drawing.Point(263, 145);
            this.dataGridOrders.Name = "dataGridOrders";
            this.dataGridOrders.RowTemplate.Height = 25;
            this.dataGridOrders.Size = new System.Drawing.Size(954, 569);
            this.dataGridOrders.TabIndex = 14;
            this.dataGridOrders.DoubleClick += new System.EventHandler(this.dataGridOrders_DoubleClick_1);
            // 
            // panelMDI
            // 
            this.panelMDI.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelMDI.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMDI.Location = new System.Drawing.Point(263, 0);
            this.panelMDI.Name = "panelMDI";
            this.panelMDI.Size = new System.Drawing.Size(954, 145);
            this.panelMDI.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(263, 145);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(954, 569);
            this.panel3.TabIndex = 16;
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 714);
            this.Controls.Add(this.dataGridOrders);
            this.Controls.Add(this.panel3);
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
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnOrderServices;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridOrders;
        private System.Windows.Forms.Panel panelMDI;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
    }
}