namespace RIS_p2_LR5
{
    partial class Form1
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
            tabControl1 = new TabControl();
            tabMaterials = new TabPage();
            btnDeleteMaterial = new Button();
            btnEditMaterial = new Button();
            btnAddMaterial = new Button();
            dgvMaterials = new DataGridView();
            tabCustomers = new TabPage();
            btnDeleteCustomer = new Button();
            btnEditCustomer = new Button();
            btnAddCustomer = new Button();
            dgvCustomers = new DataGridView();
            tabShipments = new TabPage();
            btnViewShipment = new Button();
            btnCreateShipment = new Button();
            dgvShipments = new DataGridView();
            btnRefresh = new Button();
            btnReports = new Button();
            panelStats = new Panel();
            lblTotalStockValue = new Label();
            lblShipmentsCount = new Label();
            lblCustomersCount = new Label();
            lblMaterialsCount = new Label();
            tabControl1.SuspendLayout();
            tabMaterials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaterials).BeginInit();
            tabCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            tabShipments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShipments).BeginInit();
            panelStats.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabMaterials);
            tabControl1.Controls.Add(tabCustomers);
            tabControl1.Controls.Add(tabShipments);
            tabControl1.Location = new Point(0, 66);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1371, 671);
            tabControl1.TabIndex = 0;
            // 
            // tabMaterials
            // 
            tabMaterials.Controls.Add(btnDeleteMaterial);
            tabMaterials.Controls.Add(btnEditMaterial);
            tabMaterials.Controls.Add(btnAddMaterial);
            tabMaterials.Controls.Add(dgvMaterials);
            tabMaterials.Location = new Point(4, 29);
            tabMaterials.Margin = new Padding(3, 4, 3, 4);
            tabMaterials.Name = "tabMaterials";
            tabMaterials.Padding = new Padding(3, 4, 3, 4);
            tabMaterials.Size = new Size(1363, 638);
            tabMaterials.TabIndex = 0;
            tabMaterials.Text = "Стройматериалы";
            tabMaterials.UseVisualStyleBackColor = true;
            // 
            // btnDeleteMaterial
            // 
            btnDeleteMaterial.Location = new Point(331, 28);
            btnDeleteMaterial.Margin = new Padding(3, 4, 3, 4);
            btnDeleteMaterial.Name = "btnDeleteMaterial";
            btnDeleteMaterial.Size = new Size(149, 47);
            btnDeleteMaterial.TabIndex = 3;
            btnDeleteMaterial.Text = "Удалить";
            btnDeleteMaterial.UseVisualStyleBackColor = true;
            btnDeleteMaterial.Click += btnDeleteMaterial_Click;
            // 
            // btnEditMaterial
            // 
            btnEditMaterial.Location = new Point(171, 28);
            btnEditMaterial.Margin = new Padding(3, 4, 3, 4);
            btnEditMaterial.Name = "btnEditMaterial";
            btnEditMaterial.Size = new Size(149, 47);
            btnEditMaterial.TabIndex = 2;
            btnEditMaterial.Text = "Редактировать";
            btnEditMaterial.UseVisualStyleBackColor = true;
            btnEditMaterial.Click += btnEditMaterial_Click;
            // 
            // btnAddMaterial
            // 
            btnAddMaterial.Location = new Point(11, 28);
            btnAddMaterial.Margin = new Padding(3, 4, 3, 4);
            btnAddMaterial.Name = "btnAddMaterial";
            btnAddMaterial.Size = new Size(149, 47);
            btnAddMaterial.TabIndex = 1;
            btnAddMaterial.Text = "Добавить";
            btnAddMaterial.UseVisualStyleBackColor = true;
            btnAddMaterial.Click += btnAddMaterial_Click;
            // 
            // dgvMaterials
            // 
            dgvMaterials.AllowUserToAddRows = false;
            dgvMaterials.AllowUserToDeleteRows = false;
            dgvMaterials.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMaterials.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMaterials.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaterials.Location = new Point(11, 87);
            dgvMaterials.Margin = new Padding(3, 4, 3, 4);
            dgvMaterials.Name = "dgvMaterials";
            dgvMaterials.ReadOnly = true;
            dgvMaterials.RowHeadersWidth = 51;
            dgvMaterials.RowTemplate.Height = 25;
            dgvMaterials.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaterials.Size = new Size(1349, 522);
            dgvMaterials.TabIndex = 0;
            // 
            // tabCustomers
            // 
            tabCustomers.Controls.Add(btnDeleteCustomer);
            tabCustomers.Controls.Add(btnEditCustomer);
            tabCustomers.Controls.Add(btnAddCustomer);
            tabCustomers.Controls.Add(dgvCustomers);
            tabCustomers.Location = new Point(4, 29);
            tabCustomers.Margin = new Padding(3, 4, 3, 4);
            tabCustomers.Name = "tabCustomers";
            tabCustomers.Padding = new Padding(3, 4, 3, 4);
            tabCustomers.Size = new Size(1363, 638);
            tabCustomers.TabIndex = 1;
            tabCustomers.Text = "Заказчики";
            tabCustomers.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.Location = new Point(331, 28);
            btnDeleteCustomer.Margin = new Padding(3, 4, 3, 4);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(149, 47);
            btnDeleteCustomer.TabIndex = 3;
            btnDeleteCustomer.Text = "Удалить";
            btnDeleteCustomer.UseVisualStyleBackColor = true;
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;
            // 
            // btnEditCustomer
            // 
            btnEditCustomer.Location = new Point(171, 28);
            btnEditCustomer.Margin = new Padding(3, 4, 3, 4);
            btnEditCustomer.Name = "btnEditCustomer";
            btnEditCustomer.Size = new Size(149, 47);
            btnEditCustomer.TabIndex = 2;
            btnEditCustomer.Text = "Редактировать";
            btnEditCustomer.UseVisualStyleBackColor = true;
            btnEditCustomer.Click += btnEditCustomer_Click;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Location = new Point(11, 28);
            btnAddCustomer.Margin = new Padding(3, 4, 3, 4);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(149, 47);
            btnAddCustomer.TabIndex = 1;
            btnAddCustomer.Text = "Добавить";
            btnAddCustomer.UseVisualStyleBackColor = true;
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(11, 87);
            dgvCustomers.Margin = new Padding(3, 4, 3, 4);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.RowTemplate.Height = 25;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(1349, 522);
            dgvCustomers.TabIndex = 0;
            // 
            // tabShipments
            // 
            tabShipments.Controls.Add(btnViewShipment);
            tabShipments.Controls.Add(btnCreateShipment);
            tabShipments.Controls.Add(dgvShipments);
            tabShipments.Location = new Point(4, 29);
            tabShipments.Margin = new Padding(3, 4, 3, 4);
            tabShipments.Name = "tabShipments";
            tabShipments.Padding = new Padding(3, 4, 3, 4);
            tabShipments.Size = new Size(1363, 638);
            tabShipments.TabIndex = 2;
            tabShipments.Text = "Отгрузки";
            tabShipments.UseVisualStyleBackColor = true;
            // 
            // btnViewShipment
            // 
            btnViewShipment.Location = new Point(206, 28);
            btnViewShipment.Margin = new Padding(3, 4, 3, 4);
            btnViewShipment.Name = "btnViewShipment";
            btnViewShipment.Size = new Size(149, 47);
            btnViewShipment.TabIndex = 2;
            btnViewShipment.Text = "Просмотр";
            btnViewShipment.UseVisualStyleBackColor = true;
            btnViewShipment.Click += btnViewShipment_Click;
            // 
            // btnCreateShipment
            // 
            btnCreateShipment.Location = new Point(11, 28);
            btnCreateShipment.Margin = new Padding(3, 4, 3, 4);
            btnCreateShipment.Name = "btnCreateShipment";
            btnCreateShipment.Size = new Size(183, 47);
            btnCreateShipment.TabIndex = 1;
            btnCreateShipment.Text = "Создать отгрузку";
            btnCreateShipment.UseVisualStyleBackColor = true;
            btnCreateShipment.Click += btnCreateShipment_Click;
            // 
            // dgvShipments
            // 
            dgvShipments.AllowUserToAddRows = false;
            dgvShipments.AllowUserToDeleteRows = false;
            dgvShipments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvShipments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvShipments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShipments.Location = new Point(11, 87);
            dgvShipments.Margin = new Padding(3, 4, 3, 4);
            dgvShipments.Name = "dgvShipments";
            dgvShipments.ReadOnly = true;
            dgvShipments.RowHeadersWidth = 51;
            dgvShipments.RowTemplate.Height = 25;
            dgvShipments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvShipments.Size = new Size(1349, 522);
            dgvShipments.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Location = new Point(1143, 13);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(103, 47);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnReports
            // 
            btnReports.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReports.Location = new Point(1257, 13);
            btnReports.Margin = new Padding(3, 4, 3, 4);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(103, 47);
            btnReports.TabIndex = 2;
            btnReports.Text = "Отчеты";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // panelStats
            // 
            panelStats.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelStats.BackColor = SystemColors.ControlLight;
            panelStats.BorderStyle = BorderStyle.FixedSingle;
            panelStats.Controls.Add(btnReports);
            panelStats.Controls.Add(lblTotalStockValue);
            panelStats.Controls.Add(lblShipmentsCount);
            panelStats.Controls.Add(lblCustomersCount);
            panelStats.Controls.Add(lblMaterialsCount);
            panelStats.Controls.Add(btnRefresh);
            panelStats.Location = new Point(0, 0);
            panelStats.Margin = new Padding(3, 4, 3, 4);
            panelStats.Name = "panelStats";
            panelStats.Size = new Size(1371, 66);
            panelStats.TabIndex = 0;
            // 
            // lblTotalStockValue
            // 
            lblTotalStockValue.AutoSize = true;
            lblTotalStockValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTotalStockValue.ForeColor = Color.DarkGreen;
            lblTotalStockValue.Location = new Point(480, 20);
            lblTotalStockValue.Name = "lblTotalStockValue";
            lblTotalStockValue.Size = new Size(222, 20);
            lblTotalStockValue.TabIndex = 3;
            lblTotalStockValue.Text = "Общая стоимость склада: 0 ₽";
            // 
            // lblShipmentsCount
            // 
            lblShipmentsCount.AutoSize = true;
            lblShipmentsCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblShipmentsCount.Location = new Point(326, 20);
            lblShipmentsCount.Name = "lblShipmentsCount";
            lblShipmentsCount.Size = new Size(91, 20);
            lblShipmentsCount.TabIndex = 2;
            lblShipmentsCount.Text = "Отгрузок: 0";
            // 
            // lblCustomersCount
            // 
            lblCustomersCount.AutoSize = true;
            lblCustomersCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCustomersCount.Location = new Point(171, 20);
            lblCustomersCount.Name = "lblCustomersCount";
            lblCustomersCount.Size = new Size(109, 20);
            lblCustomersCount.TabIndex = 1;
            lblCustomersCount.Text = "Заказчиков: 0";
            // 
            // lblMaterialsCount
            // 
            lblMaterialsCount.AutoSize = true;
            lblMaterialsCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMaterialsCount.Location = new Point(17, 20);
            lblMaterialsCount.Name = "lblMaterialsCount";
            lblMaterialsCount.Size = new Size(116, 20);
            lblMaterialsCount.TabIndex = 0;
            lblMaterialsCount.Text = "Материалов: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 737);
            Controls.Add(tabControl1);
            Controls.Add(panelStats);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(900, 584);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Учет отгрузки стройматериалов";
            WindowState = FormWindowState.Normal;
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabMaterials.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMaterials).EndInit();
            tabCustomers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            tabShipments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvShipments).EndInit();
            panelStats.ResumeLayout(false);
            panelStats.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMaterials;
        private System.Windows.Forms.TabPage tabCustomers;
        private System.Windows.Forms.TabPage tabShipments;
        private System.Windows.Forms.DataGridView dgvMaterials;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.DataGridView dgvShipments;
        private System.Windows.Forms.Button btnAddMaterial;
        private System.Windows.Forms.Button btnEditMaterial;
        private System.Windows.Forms.Button btnDeleteMaterial;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button btnEditCustomer;
        private System.Windows.Forms.Button btnDeleteCustomer;
        private System.Windows.Forms.Button btnCreateShipment;
        private System.Windows.Forms.Button btnViewShipment;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Label lblMaterialsCount;
        private System.Windows.Forms.Label lblCustomersCount;
        private System.Windows.Forms.Label lblShipmentsCount;
        private System.Windows.Forms.Label lblTotalStockValue;
    }
}