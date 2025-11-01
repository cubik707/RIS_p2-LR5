namespace RIS_p2_LR5
{
    partial class ShipmentForm
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
            lblShipmentNumber = new Label();
            txtShipmentNumber = new TextBox();
            lblCustomer = new Label();
            cmbCustomer = new ComboBox();
            lblShipmentDate = new Label();
            dtpShipmentDate = new DateTimePicker();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            lblNotes = new Label();
            txtNotes = new TextBox();
            groupBoxDetails = new GroupBox();
            lblTotalAmount = new Label();
            btnRemoveDetail = new Button();
            btnAddDetail = new Button();
            numQuantity = new NumericUpDown();
            lblQuantity = new Label();
            cmbMaterial = new ComboBox();
            lblMaterial = new Label();
            dgvDetails = new DataGridView();
            btnSave = new Button();
            btnCancel = new Button();
            groupBoxDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            SuspendLayout();
            // 
            // lblShipmentNumber
            // 
            lblShipmentNumber.AutoSize = true;
            lblShipmentNumber.Location = new Point(14, 20);
            lblShipmentNumber.Name = "lblShipmentNumber";
            lblShipmentNumber.Size = new Size(130, 20);
            lblShipmentNumber.TabIndex = 0;
            lblShipmentNumber.Text = "Номер отгрузки*:";
            // 
            // txtShipmentNumber
            // 
            txtShipmentNumber.Location = new Point(14, 44);
            txtShipmentNumber.Margin = new Padding(3, 4, 3, 4);
            txtShipmentNumber.Name = "txtShipmentNumber";
            txtShipmentNumber.Size = new Size(171, 27);
            txtShipmentNumber.TabIndex = 1;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(206, 20);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(80, 20);
            lblCustomer.TabIndex = 2;
            lblCustomer.Text = "Заказчик*:";
            // 
            // cmbCustomer
            // 
            cmbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(206, 44);
            cmbCustomer.Margin = new Padding(3, 4, 3, 4);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(228, 28);
            cmbCustomer.TabIndex = 3;
            // 
            // lblShipmentDate
            // 
            lblShipmentDate.AutoSize = true;
            lblShipmentDate.Location = new Point(457, 20);
            lblShipmentDate.Name = "lblShipmentDate";
            lblShipmentDate.Size = new Size(108, 20);
            lblShipmentDate.TabIndex = 4;
            lblShipmentDate.Text = "Дата отгрузки:";
            // 
            // dtpShipmentDate
            // 
            dtpShipmentDate.Location = new Point(457, 44);
            dtpShipmentDate.Margin = new Padding(3, 4, 3, 4);
            dtpShipmentDate.Name = "dtpShipmentDate";
            dtpShipmentDate.Size = new Size(160, 27);
            dtpShipmentDate.TabIndex = 5;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(634, 20);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(55, 20);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Статус:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Pending", "Shipped", "Delivered", "Cancelled" });
            cmbStatus.Location = new Point(634, 43);
            cmbStatus.Margin = new Padding(3, 4, 3, 4);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(114, 28);
            cmbStatus.TabIndex = 7;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(14, 93);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(102, 20);
            lblNotes.TabIndex = 8;
            lblNotes.Text = "Примечания:";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(14, 117);
            txtNotes.Margin = new Padding(3, 4, 3, 4);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(717, 79);
            txtNotes.TabIndex = 9;
            // 
            // groupBoxDetails
            // 
            groupBoxDetails.Controls.Add(lblTotalAmount);
            groupBoxDetails.Controls.Add(btnRemoveDetail);
            groupBoxDetails.Controls.Add(btnAddDetail);
            groupBoxDetails.Controls.Add(numQuantity);
            groupBoxDetails.Controls.Add(lblQuantity);
            groupBoxDetails.Controls.Add(cmbMaterial);
            groupBoxDetails.Controls.Add(lblMaterial);
            groupBoxDetails.Controls.Add(dgvDetails);
            groupBoxDetails.Location = new Point(14, 213);
            groupBoxDetails.Margin = new Padding(3, 4, 3, 4);
            groupBoxDetails.Name = "groupBoxDetails";
            groupBoxDetails.Padding = new Padding(3, 4, 3, 4);
            groupBoxDetails.Size = new Size(869, 467);
            groupBoxDetails.TabIndex = 10;
            groupBoxDetails.TabStop = false;
            groupBoxDetails.Text = "Детали отгрузки";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalAmount.Location = new Point(11, 427);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(141, 20);
            lblTotalAmount.TabIndex = 7;
            lblTotalAmount.Text = "Общая сумма: 0 ₽";
            // 
            // btnRemoveDetail
            // 
            btnRemoveDetail.Location = new Point(412, 63);
            btnRemoveDetail.Margin = new Padding(3, 4, 3, 4);
            btnRemoveDetail.Name = "btnRemoveDetail";
            btnRemoveDetail.Size = new Size(114, 31);
            btnRemoveDetail.TabIndex = 6;
            btnRemoveDetail.Text = "Удалить";
            btnRemoveDetail.UseVisualStyleBackColor = true;
            btnRemoveDetail.Click += btnRemoveDetail_Click;
            // 
            // btnAddDetail
            // 
            btnAddDetail.Location = new Point(292, 64);
            btnAddDetail.Margin = new Padding(3, 4, 3, 4);
            btnAddDetail.Name = "btnAddDetail";
            btnAddDetail.Size = new Size(114, 31);
            btnAddDetail.TabIndex = 5;
            btnAddDetail.Text = "Добавить";
            btnAddDetail.UseVisualStyleBackColor = true;
            btnAddDetail.Click += btnAddDetail_Click;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(114, 67);
            numQuantity.Margin = new Padding(3, 4, 3, 4);
            numQuantity.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(158, 27);
            numQuantity.TabIndex = 4;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(11, 69);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(93, 20);
            lblQuantity.TabIndex = 3;
            lblQuantity.Text = "Количество:";
            // 
            // cmbMaterial
            // 
            cmbMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaterial.FormattingEnabled = true;
            cmbMaterial.Location = new Point(114, 28);
            cmbMaterial.Margin = new Padding(3, 4, 3, 4);
            cmbMaterial.Name = "cmbMaterial";
            cmbMaterial.Size = new Size(158, 28);
            cmbMaterial.TabIndex = 2;
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.Location = new Point(11, 32);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(81, 20);
            lblMaterial.TabIndex = 1;
            lblMaterial.Text = "Материал:";
            // 
            // dgvDetails
            // 
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.AllowUserToDeleteRows = false;
            dgvDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetails.Location = new Point(11, 107);
            dgvDetails.Margin = new Padding(3, 4, 3, 4);
            dgvDetails.Name = "dgvDetails";
            dgvDetails.ReadOnly = true;
            dgvDetails.RowHeadersWidth = 51;
            dgvDetails.RowTemplate.Height = 25;
            dgvDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetails.Size = new Size(846, 307);
            dgvDetails.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(672, 707);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(118, 40);
            btnSave.TabIndex = 11;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(797, 707);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(86, 40);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // ShipmentForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(896, 761);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(groupBoxDetails);
            Controls.Add(txtNotes);
            Controls.Add(lblNotes);
            Controls.Add(cmbStatus);
            Controls.Add(lblStatus);
            Controls.Add(dtpShipmentDate);
            Controls.Add(lblShipmentDate);
            Controls.Add(cmbCustomer);
            Controls.Add(lblCustomer);
            Controls.Add(txtShipmentNumber);
            Controls.Add(lblShipmentNumber);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ShipmentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Отгрузка";
            Load += ShipmentForm_Load;
            groupBoxDetails.ResumeLayout(false);
            groupBoxDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblShipmentNumber;
        private TextBox txtShipmentNumber;
        private Label lblCustomer;
        private ComboBox cmbCustomer;
        private Label lblShipmentDate;
        private DateTimePicker dtpShipmentDate;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Label lblNotes;
        private TextBox txtNotes;
        private GroupBox groupBoxDetails;
        private DataGridView dgvDetails;
        private Label lblMaterial;
        private ComboBox cmbMaterial;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private Button btnAddDetail;
        private Button btnRemoveDetail;
        private Label lblTotalAmount;
        private Button btnSave;
        private Button btnCancel;
    }
}
