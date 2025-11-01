using RIS_p2_LR5.Models;
using RIS_p2_LR5.Services;

namespace RIS_p2_LR5
{
    public partial class CustomerForm : Form
    {
        private readonly CustomerService _customerService;
        private readonly Customer? _customer;
        private bool _isEditMode;

        public CustomerForm(CustomerService customerService, Customer? customer = null)
        {
            InitializeComponent();
            _customerService = customerService;
            _customer = customer;
            _isEditMode = customer != null;
            
            if (_isEditMode)
            {
                LoadCustomerData();
                this.Text = "Редактирование заказчика";
            }
            else
            {
                this.Text = "Добавление заказчика";
            }
        }

        private void LoadCustomerData()
        {
            if (_customer == null) return;

            txtCompanyName.Text = _customer.CompanyName;
            txtContactPerson.Text = _customer.ContactPerson;
            txtPhone.Text = _customer.Phone;
            txtEmail.Text = _customer.Email;
            txtAddress.Text = _customer.Address;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                var customer = new Customer
                {
                    CompanyName = txtCompanyName.Text.Trim(),
                    ContactPerson = txtContactPerson.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Address = txtAddress.Text.Trim()
                };

                if (_isEditMode)
                {
                    customer.Id = _customer!.Id;
                    var success = await _customerService.UpdateCustomerAsync(customer);
                    if (success)
                    {
                        MessageBox.Show("Заказчик успешно обновлен.", "Успех", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить заказчика.", "Ошибка", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    var id = await _customerService.CreateCustomerAsync(customer);
                    if (id > 0)
                    {
                        MessageBox.Show("Заказчик успешно создан.", "Успех", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось создать заказчика.", "Ошибка", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении заказчика: {ex.Message}", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                MessageBox.Show("Введите название компании.", "Ошибка валидации", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCompanyName.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Введите корректный email адрес.", "Ошибка валидации", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
