namespace RIS_p2_LR5
{
    partial class ReportsForm
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
            tabControl1 = new TabControl();
            tabStock = new TabPage();
            btnExportStock = new Button();
            dgvStockReport = new DataGridView();
            tabShipments = new TabPage();
            btnExportShipments = new Button();
            dgvShipmentsReport = new DataGridView();
            tabCustomers = new TabPage();
            btnExportCustomers = new Button();
            dgvCustomersReport = new DataGridView();
            panelStats = new Panel();
            btnRefresh = new Button();
            lblTotalShipmentsValue = new Label();
            lblShipmentsCount = new Label();
            lblMaterialsCount = new Label();
            lblTotalStockValue = new Label();
            tabControl1.SuspendLayout();
            tabStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStockReport).BeginInit();
            tabShipments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShipmentsReport).BeginInit();
            tabCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomersReport).BeginInit();
            panelStats.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabStock);
            tabControl1.Controls.Add(tabShipments);
            tabControl1.Controls.Add(tabCustomers);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1143, 867);
            tabControl1.TabIndex = 0;
            // 
            // tabStock
            // 
            tabStock.Controls.Add(btnExportStock);
            tabStock.Controls.Add(dgvStockReport);
            tabStock.Location = new Point(4, 29);
            tabStock.Margin = new Padding(3, 4, 3, 4);
            tabStock.Name = "tabStock";
            tabStock.Padding = new Padding(3, 4, 3, 4);
            tabStock.Size = new Size(1135, 834);
            tabStock.TabIndex = 0;
            tabStock.Text = "Остатки на складе";
            tabStock.UseVisualStyleBackColor = true;
            // 
            // btnExportStock
            // 
            btnExportStock.Location = new Point(8, 77);
            btnExportStock.Margin = new Padding(3, 4, 3, 4);
            btnExportStock.Name = "btnExportStock";
            btnExportStock.Size = new Size(163, 31);
            btnExportStock.TabIndex = 1;
            btnExportStock.Text = "Экспорт в CSV";
            btnExportStock.UseVisualStyleBackColor = true;
            btnExportStock.Click += btnExportStock_Click;
            // 
            // dgvStockReport
            // 
            dgvStockReport.AllowUserToAddRows = false;
            dgvStockReport.AllowUserToDeleteRows = false;
            dgvStockReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStockReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStockReport.Location = new Point(7, 116);
            dgvStockReport.Margin = new Padding(3, 4, 3, 4);
            dgvStockReport.Name = "dgvStockReport";
            dgvStockReport.ReadOnly = true;
            dgvStockReport.RowHeadersWidth = 51;
            dgvStockReport.RowTemplate.Height = 25;
            dgvStockReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStockReport.Size = new Size(1120, 706);
            dgvStockReport.TabIndex = 0;
            // 
            // tabShipments
            // 
            tabShipments.Controls.Add(btnExportShipments);
            tabShipments.Controls.Add(dgvShipmentsReport);
            tabShipments.Location = new Point(4, 29);
            tabShipments.Margin = new Padding(3, 4, 3, 4);
            tabShipments.Name = "tabShipments";
            tabShipments.Padding = new Padding(3, 4, 3, 4);
            tabShipments.Size = new Size(1135, 834);
            tabShipments.TabIndex = 1;
            tabShipments.Text = "Отгрузки за месяц";
            tabShipments.UseVisualStyleBackColor = true;
            // 
            // btnExportShipments
            // 
            btnExportShipments.Location = new Point(7, 28);
            btnExportShipments.Margin = new Padding(3, 4, 3, 4);
            btnExportShipments.Name = "btnExportShipments";
            btnExportShipments.Size = new Size(114, 31);
            btnExportShipments.TabIndex = 1;
            btnExportShipments.Text = "Экспорт в CSV";
            btnExportShipments.UseVisualStyleBackColor = true;
            btnExportShipments.Click += btnExportShipments_Click;
            // 
            // dgvShipmentsReport
            // 
            dgvShipmentsReport.AllowUserToAddRows = false;
            dgvShipmentsReport.AllowUserToDeleteRows = false;
            dgvShipmentsReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvShipmentsReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShipmentsReport.Location = new Point(7, 67);
            dgvShipmentsReport.Margin = new Padding(3, 4, 3, 4);
            dgvShipmentsReport.Name = "dgvShipmentsReport";
            dgvShipmentsReport.ReadOnly = true;
            dgvShipmentsReport.RowHeadersWidth = 51;
            dgvShipmentsReport.RowTemplate.Height = 25;
            dgvShipmentsReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvShipmentsReport.Size = new Size(1120, 688);
            dgvShipmentsReport.TabIndex = 0;
            // 
            // tabCustomers
            // 
            tabCustomers.Controls.Add(btnExportCustomers);
            tabCustomers.Controls.Add(dgvCustomersReport);
            tabCustomers.Location = new Point(4, 29);
            tabCustomers.Margin = new Padding(3, 4, 3, 4);
            tabCustomers.Name = "tabCustomers";
            tabCustomers.Padding = new Padding(3, 4, 3, 4);
            tabCustomers.Size = new Size(1135, 834);
            tabCustomers.TabIndex = 2;
            tabCustomers.Text = "Отчет по заказчикам";
            tabCustomers.UseVisualStyleBackColor = true;
            // 
            // btnExportCustomers
            // 
            btnExportCustomers.Location = new Point(7, 28);
            btnExportCustomers.Margin = new Padding(3, 4, 3, 4);
            btnExportCustomers.Name = "btnExportCustomers";
            btnExportCustomers.Size = new Size(114, 31);
            btnExportCustomers.TabIndex = 1;
            btnExportCustomers.Text = "Экспорт в CSV";
            btnExportCustomers.UseVisualStyleBackColor = true;
            btnExportCustomers.Click += btnExportCustomers_Click;
            // 
            // dgvCustomersReport
            // 
            dgvCustomersReport.AllowUserToAddRows = false;
            dgvCustomersReport.AllowUserToDeleteRows = false;
            dgvCustomersReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomersReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomersReport.Location = new Point(7, 67);
            dgvCustomersReport.Margin = new Padding(3, 4, 3, 4);
            dgvCustomersReport.Name = "dgvCustomersReport";
            dgvCustomersReport.ReadOnly = true;
            dgvCustomersReport.RowHeadersWidth = 51;
            dgvCustomersReport.RowTemplate.Height = 25;
            dgvCustomersReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomersReport.Size = new Size(1120, 688);
            dgvCustomersReport.TabIndex = 0;
            // 
            // panelStats
            // 
            panelStats.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelStats.Controls.Add(btnRefresh);
            panelStats.Controls.Add(lblTotalShipmentsValue);
            panelStats.Controls.Add(lblShipmentsCount);
            panelStats.Controls.Add(lblMaterialsCount);
            panelStats.Controls.Add(lblTotalStockValue);
            panelStats.Location = new Point(0, 0);
            panelStats.Margin = new Padding(3, 4, 3, 4);
            panelStats.Name = "panelStats";
            panelStats.Size = new Size(1143, 98);
            panelStats.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Location = new Point(1029, 13);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(103, 40);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblTotalShipmentsValue
            // 
            lblTotalShipmentsValue.AutoSize = true;
            lblTotalShipmentsValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalShipmentsValue.Location = new Point(12, 60);
            lblTotalShipmentsValue.Name = "lblTotalShipmentsValue";
            lblTotalShipmentsValue.Size = new Size(277, 20);
            lblTotalShipmentsValue.TabIndex = 3;
            lblTotalShipmentsValue.Text = "Общая сумма отгрузок за месяц: 0 ₽";
            // 
            // lblShipmentsCount
            // 
            lblShipmentsCount.AutoSize = true;
            lblShipmentsCount.Location = new Point(484, 23);
            lblShipmentsCount.Name = "lblShipmentsCount";
            lblShipmentsCount.Size = new Size(152, 20);
            lblShipmentsCount.TabIndex = 2;
            lblShipmentsCount.Text = "Отгрузок за месяц: 0";
            // 
            // lblMaterialsCount
            // 
            lblMaterialsCount.AutoSize = true;
            lblMaterialsCount.Location = new Point(484, 60);
            lblMaterialsCount.Name = "lblMaterialsCount";
            lblMaterialsCount.Size = new Size(181, 20);
            lblMaterialsCount.TabIndex = 1;
            lblMaterialsCount.Text = "Материалов на складе: 0";
            // 
            // lblTotalStockValue
            // 
            lblTotalStockValue.AutoSize = true;
            lblTotalStockValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalStockValue.Location = new Point(11, 20);
            lblTotalStockValue.Name = "lblTotalStockValue";
            lblTotalStockValue.Size = new Size(222, 20);
            lblTotalStockValue.TabIndex = 0;
            lblTotalStockValue.Text = "Общая стоимость склада: 0 ₽";
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 867);
            Controls.Add(panelStats);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(912, 784);
            Name = "ReportsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Отчеты";
            Load += ReportsForm_Load;
            tabControl1.ResumeLayout(false);
            tabStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStockReport).EndInit();
            tabShipments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvShipmentsReport).EndInit();
            tabCustomers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCustomersReport).EndInit();
            panelStats.ResumeLayout(false);
            panelStats.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabStock;
        private TabPage tabShipments;
        private TabPage tabCustomers;
        private DataGridView dgvStockReport;
        private DataGridView dgvShipmentsReport;
        private DataGridView dgvCustomersReport;
        private Button btnExportStock;
        private Button btnExportShipments;
        private Button btnExportCustomers;
        private Panel panelStats;
        private Label lblTotalStockValue;
        private Label lblMaterialsCount;
        private Label lblShipmentsCount;
        private Label lblTotalShipmentsValue;
        private Button btnRefresh;
    }
}
