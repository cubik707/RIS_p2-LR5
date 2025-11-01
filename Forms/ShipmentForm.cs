using RIS_p2_LR5.Models;
using RIS_p2_LR5.Services;
using System.Linq;

namespace RIS_p2_LR5
{
    public partial class ShipmentForm : Form
    {
        private readonly ShipmentService _shipmentService;
        private readonly CustomerService _customerService;
        private readonly MaterialService _materialService;
        private readonly Shipment? _shipment;
        private bool _isEditMode;
        private List<ShipmentDetail> _shipmentDetails;

        public ShipmentForm(ShipmentService shipmentService, CustomerService customerService, 
            MaterialService materialService, Shipment? shipment = null)
        {
            InitializeComponent();
            _shipmentService = shipmentService;
            _customerService = customerService;
            _materialService = materialService;
            _shipment = shipment;
            _isEditMode = shipment != null;
            _shipmentDetails = new List<ShipmentDetail>();
            
            if (_isEditMode)
            {
                LoadShipmentData();
                this.Text = "Редактирование отгрузки";
            }
            else
            {
                this.Text = "Создание отгрузки";
            }
        }

        private async void LoadShipmentData()
        {
            if (_shipment == null) return;

            txtShipmentNumber.Text = _shipment.ShipmentNumber;
            cmbCustomer.SelectedValue = _shipment.CustomerId;
            dtpShipmentDate.Value = _shipment.ShipmentDate;
            cmbStatus.Text = _shipment.Status;
            txtNotes.Text = _shipment.Notes;

            _shipmentDetails = await _shipmentService.GetShipmentDetailsAsync(_shipment.Id);
            UpdateDetailsGrid();
            UpdateTotalAmount();
        }

        private async void ShipmentForm_Load(object sender, EventArgs e)
        {
            await LoadCustomersAsync();
            await LoadMaterialsAsync();
            
            if (!_isEditMode)
            {
                txtShipmentNumber.Text = await _shipmentService.GenerateShipmentNumberAsync();
                dtpShipmentDate.Value = DateTime.Today;
            }
        }

        private async Task LoadCustomersAsync()
        {
            try
            {
                var customers = await _customerService.GetAllCustomersAsync();
                cmbCustomer.DataSource = customers;
                cmbCustomer.DisplayMember = "CompanyName";
                cmbCustomer.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке заказчиков: {ex.Message}", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadMaterialsAsync()
        {
            try
            {
                var materials = await _materialService.GetAllMaterialsAsync();
                cmbMaterial.DataSource = materials;
                cmbMaterial.DisplayMember = "Name";
                cmbMaterial.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке материалов: {ex.Message}", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDetailsGrid()
        {
            dgvDetails.DataSource = null;
            dgvDetails.DataSource = _shipmentDetails;
            
            if (dgvDetails.Columns.Count > 0)
            {
                dgvDetails.Columns["Id"].Visible = false;
                dgvDetails.Columns["ShipmentId"].Visible = false;
                dgvDetails.Columns["MaterialId"].Visible = false;
                dgvDetails.Columns["Material"].Visible = false;
                dgvDetails.Columns["CreatedAt"].Visible = false;
            }
        }

        private void UpdateTotalAmount()
        {
            var total = _shipmentDetails.Sum(d => d.TotalPrice);
            lblTotalAmount.Text = $"Общая сумма: {total:C}";
        }

        private async void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedValue == null)
            {
                MessageBox.Show("Выберите материал.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Введите количество больше нуля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var material = (Material)cmbMaterial.SelectedItem;
            var quantity = (int)numQuantity.Value;

            // Проверяем достаточность остатков на складе
            var currentStock = await _materialService.GetCurrentStockAsync(material.Id);
            if (currentStock < quantity)
            {
                MessageBox.Show($"Недостаточно материала на складе!\n\n" +
                    $"Материал: {material.Name}\n" +
                    $"Требуется: {quantity} {material.Unit}\n" +
                    $"Доступно: {currentStock} {material.Unit}", 
                    "Недостаточно материалов", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверяем, не превышает ли общее количество в отгрузке доступные остатки
            var totalQuantityInShipment = _shipmentDetails
                .Where(d => d.MaterialId == material.Id)
                .Sum(d => d.Quantity) + quantity;

            if (totalQuantityInShipment > currentStock)
            {
                MessageBox.Show($"Общее количество материала в отгрузке превышает остатки на складе!\n\n" +
                    $"Материал: {material.Name}\n" +
                    $"Уже в отгрузке: {totalQuantityInShipment - quantity} {material.Unit}\n" +
                    $"Добавляется: {quantity} {material.Unit}\n" +
                    $"Итого будет: {totalQuantityInShipment} {material.Unit}\n" +
                    $"Доступно: {currentStock} {material.Unit}", 
                    "Превышение остатков", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var unitPrice = material.Price;
            var totalPrice = quantity * unitPrice;

            var detail = new ShipmentDetail
            {
                MaterialId = material.Id,
                Material = material,
                Quantity = quantity,
                UnitPrice = unitPrice,
                TotalPrice = totalPrice
            };

            _shipmentDetails.Add(detail);
            UpdateDetailsGrid();
            UpdateTotalAmount();

            // Сброс полей
            cmbMaterial.SelectedIndex = -1;
            numQuantity.Value = 1;
        }

        private void btnRemoveDetail_Click(object sender, EventArgs e)
        {
            if (dgvDetails.SelectedRows.Count > 0)
            {
                var index = dgvDetails.SelectedRows[0].Index;
                _shipmentDetails.RemoveAt(index);
                UpdateDetailsGrid();
                UpdateTotalAmount();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            // Дополнительная проверка остатков перед сохранением
            if (!await ValidateStockAvailability())
                return;

            try
            {
                var shipment = new Shipment
                {
                    ShipmentNumber = txtShipmentNumber.Text.Trim(),
                    CustomerId = (int)cmbCustomer.SelectedValue,
                    ShipmentDate = dtpShipmentDate.Value.Date,
                    Status = cmbStatus.Text,
                    Notes = txtNotes.Text.Trim(),
                    TotalAmount = _shipmentDetails.Sum(d => d.TotalPrice)
                };

                if (_isEditMode)
                {
                    shipment.Id = _shipment!.Id;
                    var success = await _shipmentService.UpdateShipmentAsync(shipment);
                    if (success)
                    {
                        MessageBox.Show("Отгрузка успешно обновлена.", "Успех", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить отгрузку.", "Ошибка", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    var shipmentId = await _shipmentService.CreateShipmentAsync(shipment);
                    if (shipmentId > 0)
                    {
                        // Добавляем детали отгрузки
                        foreach (var detail in _shipmentDetails)
                        {
                            detail.ShipmentId = shipmentId;
                            await _shipmentService.AddShipmentDetailAsync(detail);
                        }

                        // Обновляем остатки на складе
                        foreach (var detail in _shipmentDetails)
                        {
                            var success = await _materialService.UpdateStockQuantityAsync(detail.MaterialId, -detail.Quantity);
                            if (!success)
                            {
                                MessageBox.Show($"Не удалось обновить остатки для материала: {detail.Material?.Name}\n" +
                                    "Возможно, остатки изменились с момента добавления материала в отгрузку.", 
                                    "Ошибка обновления остатков", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                        MessageBox.Show("Отгрузка успешно создана.", "Успех", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось создать отгрузку.", "Ошибка", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении отгрузки: {ex.Message}", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> ValidateStockAvailability()
        {
            var insufficientMaterials = new List<string>();

            foreach (var detail in _shipmentDetails)
            {
                var currentStock = await _materialService.GetCurrentStockAsync(detail.MaterialId);
                if (currentStock < detail.Quantity)
                {
                    insufficientMaterials.Add($"• {detail.Material?.Name}: требуется {detail.Quantity} {detail.Material?.Unit}, доступно {currentStock} {detail.Material?.Unit}");
                }
            }

            if (insufficientMaterials.Any())
            {
                var message = "Недостаточно материалов на складе для создания отгрузки:\n\n" +
                    string.Join("\n", insufficientMaterials) +
                    "\n\nПожалуйста, уменьшите количество или удалите материалы из отгрузки.";
                
                MessageBox.Show(message, "Недостаточно материалов", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtShipmentNumber.Text))
            {
                MessageBox.Show("Введите номер отгрузки.", "Ошибка валидации", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtShipmentNumber.Focus();
                return false;
            }

            if (cmbCustomer.SelectedValue == null)
            {
                MessageBox.Show("Выберите заказчика.", "Ошибка валидации", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCustomer.Focus();
                return false;
            }

            if (_shipmentDetails.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы один материал в отгрузку.", "Ошибка валидации", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
