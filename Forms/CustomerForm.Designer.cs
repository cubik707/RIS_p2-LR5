namespace RIS_p2_LR5
{
    partial class CustomerForm
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
            lblCompanyName = new Label();
            txtCompanyName = new TextBox();
            lblContactPerson = new Label();
            txtContactPerson = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.Location = new Point(14, 20);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(161, 20);
            lblCompanyName.TabIndex = 0;
            lblCompanyName.Text = "Название компании*:";
            // 
            // txtCompanyName
            // 
            txtCompanyName.Location = new Point(14, 44);
            txtCompanyName.Margin = new Padding(3, 4, 3, 4);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.Size = new Size(342, 27);
            txtCompanyName.TabIndex = 1;
            // 
            // lblContactPerson
            // 
            lblContactPerson.AutoSize = true;
            lblContactPerson.Location = new Point(14, 87);
            lblContactPerson.Name = "lblContactPerson";
            lblContactPerson.Size = new Size(131, 20);
            lblContactPerson.TabIndex = 2;
            lblContactPerson.Text = "Контактное лицо:";
            // 
            // txtContactPerson
            // 
            txtContactPerson.Location = new Point(14, 111);
            txtContactPerson.Margin = new Padding(3, 4, 3, 4);
            txtContactPerson.Name = "txtContactPerson";
            txtContactPerson.Size = new Size(342, 27);
            txtContactPerson.TabIndex = 3;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(14, 153);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(72, 20);
            lblPhone.TabIndex = 4;
            lblPhone.Text = "Телефон:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(14, 177);
            txtPhone.Margin = new Padding(3, 4, 3, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(228, 27);
            txtPhone.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(14, 220);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(14, 244);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(228, 27);
            txtEmail.TabIndex = 7;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(14, 287);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(54, 20);
            lblAddress.TabIndex = 8;
            lblAddress.Text = "Адрес:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(14, 311);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(342, 79);
            txtAddress.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(149, 427);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(103, 40);
            btnSave.TabIndex = 10;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(258, 427);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(98, 40);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // CustomerForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(377, 487);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(txtContactPerson);
            Controls.Add(lblContactPerson);
            Controls.Add(txtCompanyName);
            Controls.Add(lblCompanyName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CustomerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Заказчик";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCompanyName;
        private TextBox txtCompanyName;
        private Label lblContactPerson;
        private TextBox txtContactPerson;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblAddress;
        private TextBox txtAddress;
        private Button btnSave;
        private Button btnCancel;
    }
}
