using RIS_p2_LR5.Data;
using RIS_p2_LR5.Services;
using RIS_p2_LR5.Configuration;
using Microsoft.Extensions.Configuration;

namespace RIS_p2_LR5
{
    public partial class Form1 : Form
    {
        private DatabaseConnection? _dbConnection;
        private MaterialService? _materialService;
        private CustomerService? _customerService;
        private ShipmentService? _shipmentService;

        public Form1()
        {
            InitializeComponent();
            
            // Инициализация сервисов только в режиме выполнения, не в дизайнере
            if (!this.DesignMode)
            {
                InitializeServices();
            }
        }

        private void InitializeServices()
        {
            try
            {
                // Загрузка конфигурации из appsettings.json
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                var databaseSettings = configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
                
                if (databaseSettings == null)
                {
                    MessageBox.Show("Не удалось загрузить настройки базы данных из файла appsettings.json", 
                        "Ошибка конфигурации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _dbConnection = new DatabaseConnection(databaseSettings);
                _materialService = new MaterialService(_dbConnection);
                _customerService = new CustomerService(_dbConnection);
                _shipmentService = new ShipmentService(_dbConnection);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при инициализации сервисов: {ex.Message}\n\n" +
                    "Убедитесь, что файл appsettings.json существует и содержит корректные настройки подключения.", 
                    "Ошибка инициализации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Загрузка данных только в режиме выполнения, не в дизайнере
            if (!this.DesignMode)
            {
                await LoadDataAsync();
            }
        }

        private async Task LoadDataAsync()
        {
            try
            {

                // Проверка инициализации сервисов
                if (_dbConnection == null)
                {
                    MessageBox.Show("Не удалось инициализировать подключение к базе данных. Проверьте файл appsettings.json.", 
                        "Ошибка инициализации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_materialService == null || _customerService == null || _shipmentService == null)
                {
                    MessageBox.Show("Не удалось инициализировать сервисы. Проверьте настройки подключения.", 
                        "Ошибка инициализации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Проверка подключения к базе данных
                var isConnected = await _dbConnection!.TestConnectionAsync();
                if (!isConnected)
                {
                    MessageBox.Show("Не удалось подключиться к базе данных. Проверьте настройки подключения.", 
                        "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Загрузка данных
                var materials = await _materialService!.GetAllMaterialsAsync();
                var customers = await _customerService!.GetAllCustomersAsync();
                var shipments = await _shipmentService!.GetAllShipmentsAsync();

                // Обновление интерфейса
                UpdateMaterialsGrid(materials);
                UpdateCustomersGrid(customers);
                UpdateShipmentsGrid(shipments);

                // Обновление статистики
                UpdateStatistics(materials, customers, shipments);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateMaterialsGrid(List<Models.Material> materials)
        {
            dgvMaterials.DataSource = materials;
            if (dgvMaterials.Columns.Count > 0)
            {
                if (dgvMaterials.Columns.Contains("Id"))
                    dgvMaterials.Columns["Id"].Visible = false;
                if (dgvMaterials.Columns.Contains("CreatedAt"))
                    dgvMaterials.Columns["CreatedAt"].Visible = false;
                if (dgvMaterials.Columns.Contains("UpdatedAt"))
                    dgvMaterials.Columns["UpdatedAt"].Visible = false;
                
                // Устанавливаем русские заголовки
                if (dgvMaterials.Columns.Contains("Name"))
                    dgvMaterials.Columns["Name"].HeaderText = "Название";
                if (dgvMaterials.Columns.Contains("Description"))
                    dgvMaterials.Columns["Description"].HeaderText = "Описание";
                if (dgvMaterials.Columns.Contains("Unit"))
                    dgvMaterials.Columns["Unit"].HeaderText = "Единица";
                if (dgvMaterials.Columns.Contains("Price"))
                    dgvMaterials.Columns["Price"].HeaderText = "Цена";
                if (dgvMaterials.Columns.Contains("StockQuantity"))
                    dgvMaterials.Columns["StockQuantity"].HeaderText = "Остаток";
            }
        }

        private void UpdateCustomersGrid(List<Models.Customer> customers)
        {
            dgvCustomers.DataSource = customers;
            if (dgvCustomers.Columns.Count > 0)
            {
                if (dgvCustomers.Columns.Contains("Id"))
                    dgvCustomers.Columns["Id"].Visible = false;
                if (dgvCustomers.Columns.Contains("CreatedAt"))
                    dgvCustomers.Columns["CreatedAt"].Visible = false;
                if (dgvCustomers.Columns.Contains("UpdatedAt"))
                    dgvCustomers.Columns["UpdatedAt"].Visible = false;
                
                // Устанавливаем русские заголовки
                if (dgvCustomers.Columns.Contains("CompanyName"))
                    dgvCustomers.Columns["CompanyName"].HeaderText = "Компания";
                if (dgvCustomers.Columns.Contains("ContactPerson"))
                    dgvCustomers.Columns["ContactPerson"].HeaderText = "Контактное лицо";
                if (dgvCustomers.Columns.Contains("Phone"))
                    dgvCustomers.Columns["Phone"].HeaderText = "Телефон";
                if (dgvCustomers.Columns.Contains("Email"))
                    dgvCustomers.Columns["Email"].HeaderText = "Email";
                if (dgvCustomers.Columns.Contains("Address"))
                    dgvCustomers.Columns["Address"].HeaderText = "Адрес";
            }
        }

        private void UpdateShipmentsGrid(List<Models.Shipment> shipments)
        {
            dgvShipments.DataSource = shipments;
            if (dgvShipments.Columns.Count > 0)
            {
                // Скрываем только те колонки, которые точно существуют
                if (dgvShipments.Columns.Contains("Id"))
                    dgvShipments.Columns["Id"].Visible = false;
                if (dgvShipments.Columns.Contains("CustomerId"))
                    dgvShipments.Columns["CustomerId"].Visible = false;
                if (dgvShipments.Columns.Contains("Customer"))
                    dgvShipments.Columns["Customer"].Visible = false;
                if (dgvShipments.Columns.Contains("Details"))
                    dgvShipments.Columns["Details"].Visible = false;
                if (dgvShipments.Columns.Contains("CreatedAt"))
                    dgvShipments.Columns["CreatedAt"].Visible = false;
                if (dgvShipments.Columns.Contains("UpdatedAt"))
                    dgvShipments.Columns["UpdatedAt"].Visible = false;
                
                if (dgvShipments.Columns.Contains("ShipmentNumber"))
                    dgvShipments.Columns["ShipmentNumber"].HeaderText = "Номер отгрузки";
                if (dgvShipments.Columns.Contains("ShipmentDate"))
                    dgvShipments.Columns["ShipmentDate"].HeaderText = "Дата отгрузки";
                if (dgvShipments.Columns.Contains("Status"))
                    dgvShipments.Columns["Status"].HeaderText = "Статус";
                if (dgvShipments.Columns.Contains("TotalAmount"))
                    dgvShipments.Columns["TotalAmount"].HeaderText = "Сумма";
                if (dgvShipments.Columns.Contains("Notes"))
                    dgvShipments.Columns["Notes"].HeaderText = "Примечания";
            }
        }

        private void UpdateStatistics(List<Models.Material> materials, List<Models.Customer> customers, List<Models.Shipment> shipments)
        {
            lblMaterialsCount.Text = $"Материалов: {materials.Count}";
            lblCustomersCount.Text = $"Заказчиков: {customers.Count}";
            lblShipmentsCount.Text = $"Отгрузок: {shipments.Count}";
            
            var totalValue = materials.Sum(m => m.Price * m.StockQuantity);
            lblTotalStockValue.Text = $"Общая стоимость склада: {totalValue:C}";
        }

        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            var materialForm = new MaterialForm(_materialService!);
            if (materialForm.ShowDialog() == DialogResult.OK)
            {
                LoadDataAsync();
            }
        }

        private void btnEditMaterial_Click(object sender, EventArgs e)
        {
            if (dgvMaterials.SelectedRows.Count > 0)
            {
                var material = (Models.Material)dgvMaterials.SelectedRows[0].DataBoundItem;
                var materialForm = new MaterialForm(_materialService!, material);
                if (materialForm.ShowDialog() == DialogResult.OK)
                {
                    LoadDataAsync();
                }
            }
        }

        private void btnDeleteMaterial_Click(object sender, EventArgs e)
        {
            if (dgvMaterials.SelectedRows.Count > 0)
            {
                var material = (Models.Material)dgvMaterials.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"Удалить материал '{material.Name}'?", 
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    DeleteMaterialAsync(material.Id);
                }
            }
        }

        private async void DeleteMaterialAsync(int materialId)
        {
            try
            {
                var success = await _materialService!.DeleteMaterialAsync(materialId);
                if (success)
                {
                    MessageBox.Show("Материал успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                }
                else
                {
                    MessageBox.Show("Не удалось удалить материал.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении материала: {ex.Message}", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            var customerForm = new CustomerForm(_customerService!);
            if (customerForm.ShowDialog() == DialogResult.OK)
            {
                LoadDataAsync();
            }
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                var customer = (Models.Customer)dgvCustomers.SelectedRows[0].DataBoundItem;
                var customerForm = new CustomerForm(_customerService!, customer);
                if (customerForm.ShowDialog() == DialogResult.OK)
                {
                    LoadDataAsync();
                }
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                var customer = (Models.Customer)dgvCustomers.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"Удалить заказчика '{customer.CompanyName}'?", 
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    DeleteCustomerAsync(customer.Id);
                }
            }
        }

        private async void DeleteCustomerAsync(int customerId)
        {
            try
            {
                var success = await _customerService!.DeleteCustomerAsync(customerId);
                if (success)
                {
                    MessageBox.Show("Заказчик успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                }
                else
                {
                    MessageBox.Show("Не удалось удалить заказчика.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении заказчика: {ex.Message}", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateShipment_Click(object sender, EventArgs e)
        {
            var shipmentForm = new ShipmentForm(_shipmentService!, _customerService!, _materialService!);
            if (shipmentForm.ShowDialog() == DialogResult.OK)
            {
                LoadDataAsync();
            }
        }

        private void btnViewShipment_Click(object sender, EventArgs e)
        {
            if (dgvShipments.SelectedRows.Count > 0)
            {
                var shipment = (Models.Shipment)dgvShipments.SelectedRows[0].DataBoundItem;
                var shipmentForm = new ShipmentForm(_shipmentService!, _customerService!, _materialService!, shipment);
                if (shipmentForm.ShowDialog() == DialogResult.OK)
                {
                    LoadDataAsync();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataAsync();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var reportsForm = new ReportsForm(_dbConnection!);
            reportsForm.ShowDialog();
        }
    }
}
