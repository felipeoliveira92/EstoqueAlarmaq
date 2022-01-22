namespace EstoqueAlarmaq.Desktop
{
    partial class FormOrderServices
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
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTecnical = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDateCreated = new System.Windows.Forms.TextBox();
            this.txtObservation = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listViewProducts = new System.Windows.Forms.ListView();
            this.listBoxProducts = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.btnRegisterOrderService = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Location = new System.Drawing.Point(12, 12);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(75, 23);
            this.btnNewOrder.TabIndex = 0;
            this.btnNewOrder.Text = "Nova Saida";
            this.btnNewOrder.UseVisualStyleBackColor = true;
            // 
            // txtClient
            // 
            this.txtClient.Location = new System.Drawing.Point(12, 90);
            this.txtClient.Name = "txtClient";
            this.txtClient.Size = new System.Drawing.Size(323, 23);
            this.txtClient.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cliente";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(12, 190);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(323, 23);
            this.txtUser.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tecnico";
            // 
            // txtTecnical
            // 
            this.txtTecnical.Location = new System.Drawing.Point(12, 140);
            this.txtTecnical.Name = "txtTecnical";
            this.txtTecnical.Size = new System.Drawing.Size(323, 23);
            this.txtTecnical.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Data Abertura";
            // 
            // txtDateCreated
            // 
            this.txtDateCreated.Location = new System.Drawing.Point(12, 240);
            this.txtDateCreated.Name = "txtDateCreated";
            this.txtDateCreated.Size = new System.Drawing.Size(323, 23);
            this.txtDateCreated.TabIndex = 7;
            // 
            // txtObservation
            // 
            this.txtObservation.Location = new System.Drawing.Point(12, 290);
            this.txtObservation.Name = "txtObservation";
            this.txtObservation.Size = new System.Drawing.Size(323, 23);
            this.txtObservation.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Observações";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // listViewProducts
            // 
            this.listViewProducts.HideSelection = false;
            this.listViewProducts.Location = new System.Drawing.Point(341, 140);
            this.listViewProducts.Name = "listViewProducts";
            this.listViewProducts.Size = new System.Drawing.Size(404, 173);
            this.listViewProducts.TabIndex = 11;
            this.listViewProducts.UseCompatibleStateImageBehavior = false;
            // 
            // listBoxProducts
            // 
            this.listBoxProducts.FormattingEnabled = true;
            this.listBoxProducts.ItemHeight = 15;
            this.listBoxProducts.Location = new System.Drawing.Point(341, 319);
            this.listBoxProducts.Name = "listBoxProducts";
            this.listBoxProducts.Size = new System.Drawing.Size(404, 94);
            this.listBoxProducts.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(341, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Produto/Codigo";
            // 
            // txtProductCode
            // 
            this.txtProductCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtProductCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtProductCode.Location = new System.Drawing.Point(341, 111);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(323, 23);
            this.txtProductCode.TabIndex = 13;
            this.txtProductCode.TextChanged += new System.EventHandler(this.txtProduct_TextChanged);
            this.txtProductCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductCode_KeyPress);
            // 
            // btnRegisterOrderService
            // 
            this.btnRegisterOrderService.Location = new System.Drawing.Point(670, 419);
            this.btnRegisterOrderService.Name = "btnRegisterOrderService";
            this.btnRegisterOrderService.Size = new System.Drawing.Size(75, 23);
            this.btnRegisterOrderService.TabIndex = 15;
            this.btnRegisterOrderService.Text = "Registrar";
            this.btnRegisterOrderService.UseVisualStyleBackColor = true;
            this.btnRegisterOrderService.Click += new System.EventHandler(this.btnRegisterOrderService_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(670, 111);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FormOrderServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 549);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRegisterOrderService);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.listBoxProducts);
            this.Controls.Add(this.listViewProducts);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtObservation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDateCreated);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTecnical);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.btnNewOrder);
            this.Name = "FormOrderServices";
            this.Text = "FormOrderServices";
            this.Load += new System.EventHandler(this.FormOrderServices_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTecnical;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDateCreated;
        private System.Windows.Forms.TextBox txtObservation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView listViewProducts;
        private System.Windows.Forms.ListBox listBoxProducts;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Button btnRegisterOrderService;
        private System.Windows.Forms.Button btnAdd;
    }
}