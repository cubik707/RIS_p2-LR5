using RIS_p2_LR5.Models;
using RIS_p2_LR5.Services;

namespace RIS_p2_LR5
{
    public partial class MaterialForm : Form
    {
        private readonly MaterialService _materialService;
        private readonly Material? _material;
        private bool _isEditMode;

        public MaterialForm(MaterialService materialService, Material? material = null)
        {
            InitializeComponent();
            _materialService = materialService;
            _material = material;
            _isEditMode = material != null;
            
            if (_isEditMode)
            {
                LoadMaterialData();
                this.Text = "Редактирование материала";
            }
            else
            {
                this.Text = "Добавление материала";
            }
        }

        private void LoadMaterialData()
        {
            if (_material == null) return;

            txtName.Text = _material.Name;
            txtDescription.Text = _material.Description;
            txtUnit.Text = _material.Unit;
            numPrice.Value = _material.Price;
            numStockQuantity.Value = _material.StockQuantity;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                var material = new Material
                {
                    Name = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    Unit = txtUnit.Text.Trim(),
                    Price = numPrice.Value,
                    StockQuantity = (int)numStockQuantity.Value
                };

                if (_isEditMode)
                {
                    material.Id = _material!.Id;
                    var success = await _materialService.UpdateMaterialAsync(material);
                    if (success)
                    {
                        MessageBox.Show("Материал успешно обновлен.", "Успех", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить материал.", "Ошибка", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    var id = await _materialService.CreateMaterialAsync(material);
                    if (id > 0)
                    {
                        MessageBox.Show("Материал успешно создан.", "Успех", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось создать материал.", "Ошибка", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении материала: {ex.Message}", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название материала.", "Ошибка валидации", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUnit.Text))
            {
                MessageBox.Show("Введите единицу измерения.", "Ошибка валидации", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnit.Focus();
                return false;
            }

            if (numPrice.Value <= 0)
            {
                MessageBox.Show("Цена должна быть больше нуля.", "Ошибка валидации", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPrice.Focus();
                return false;
            }

            if (numStockQuantity.Value < 0)
            {
                MessageBox.Show("Количество на складе не может быть отрицательным.", "Ошибка валидации", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numStockQuantity.Focus();
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
