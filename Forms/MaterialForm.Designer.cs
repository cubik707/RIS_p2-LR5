namespace RIS_p2_LR5
{
    partial class MaterialForm
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
            lblName = new Label();
            txtName = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblUnit = new Label();
            txtUnit = new TextBox();
            lblPrice = new Label();
            numPrice = new NumericUpDown();
            lblStockQuantity = new Label();
            numStockQuantity = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockQuantity).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(14, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(86, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Название*:";
            // 
            // txtName
            // 
            txtName.Location = new Point(14, 44);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.Size = new Size(342, 27);
            txtName.TabIndex = 1;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(14, 87);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(82, 20);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Описание:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(14, 111);
            txtDescription.Margin = new Padding(3, 4, 3, 4);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(342, 79);
            txtDescription.TabIndex = 3;
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Location = new Point(14, 207);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(160, 20);
            lblUnit.TabIndex = 4;
            lblUnit.Text = "Единица измерения*:";
            // 
            // txtUnit
            // 
            txtUnit.Location = new Point(14, 231);
            txtUnit.Margin = new Padding(3, 4, 3, 4);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(114, 27);
            txtUnit.TabIndex = 5;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(14, 273);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(54, 20);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "Цена*:";
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(14, 297);
            numPrice.Margin = new Padding(3, 4, 3, 4);
            numPrice.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(114, 27);
            numPrice.TabIndex = 7;
            // 
            // lblStockQuantity
            // 
            lblStockQuantity.AutoSize = true;
            lblStockQuantity.Location = new Point(14, 340);
            lblStockQuantity.Name = "lblStockQuantity";
            lblStockQuantity.Size = new Size(164, 20);
            lblStockQuantity.TabIndex = 8;
            lblStockQuantity.Text = "Количество на складе:";
            // 
            // numStockQuantity
            // 
            numStockQuantity.Location = new Point(14, 364);
            numStockQuantity.Margin = new Padding(3, 4, 3, 4);
            numStockQuantity.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numStockQuantity.Name = "numStockQuantity";
            numStockQuantity.Size = new Size(114, 27);
            numStockQuantity.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(143, 427);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(101, 40);
            btnSave.TabIndex = 10;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(250, 427);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(107, 40);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // MaterialForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(377, 487);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(numStockQuantity);
            Controls.Add(lblStockQuantity);
            Controls.Add(numPrice);
            Controls.Add(lblPrice);
            Controls.Add(txtUnit);
            Controls.Add(lblUnit);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(txtName);
            Controls.Add(lblName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MaterialForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Материал";
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblUnit;
        private TextBox txtUnit;
        private Label lblPrice;
        private NumericUpDown numPrice;
        private Label lblStockQuantity;
        private NumericUpDown numStockQuantity;
        private Button btnSave;
        private Button btnCancel;
    }
}
