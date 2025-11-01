using RIS_p2_LR5.Data;
using RIS_p2_LR5.Services;
using System.Data;

namespace RIS_p2_LR5
{
    public partial class ReportsForm : Form
    {
        private readonly DatabaseConnection _dbConnection;

        public ReportsForm(DatabaseConnection dbConnection)
        {
            InitializeComponent();
            _dbConnection = dbConnection;
        }

        private async void ReportsForm_Load(object sender, EventArgs e)
        {
            await LoadReportsAsync();
        }

        private async Task LoadReportsAsync()
        {
            try
            {
                // Отчет по остаткам на складе
                var stockQuery = @"
                    SELECT Name, Unit, StockQuantity, Price, 
                           (StockQuantity * Price) as TotalValue
                    FROM Materials 
                    ORDER BY TotalValue DESC";
                
                var stockData = await _dbConnection.ExecuteQueryAsync(stockQuery);
                dgvStockReport.DataSource = stockData;

                // Отчет по отгрузкам за последний месяц
                var shipmentsQuery = @"
                    SELECT s.ShipmentNumber, c.CompanyName, s.ShipmentDate, 
                           s.Status, s.TotalAmount
                    FROM Shipments s
                    LEFT JOIN Customers c ON s.CustomerId = c.Id
                    WHERE s.ShipmentDate >= CURRENT_DATE - INTERVAL '30 days'
                    ORDER BY s.ShipmentDate DESC";
                
                var shipmentsData = await _dbConnection.ExecuteQueryAsync(shipmentsQuery);
                dgvShipmentsReport.DataSource = shipmentsData;

                // Отчет по заказчикам
                var customersQuery = @"
                    SELECT c.CompanyName, c.ContactPerson, c.Phone,
                           COUNT(s.Id) as ShipmentsCount,
                           COALESCE(SUM(s.TotalAmount), 0) as TotalAmount
                    FROM Customers c
                    LEFT JOIN Shipments s ON c.Id = s.CustomerId
                    GROUP BY c.Id, c.CompanyName, c.ContactPerson, c.Phone
                    ORDER BY TotalAmount DESC";
                
                var customersData = await _dbConnection.ExecuteQueryAsync(customersQuery);
                dgvCustomersReport.DataSource = customersData;

                // Обновление статистики
                await UpdateStatisticsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке отчетов: {ex.Message}", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task UpdateStatisticsAsync()
        {
            try
            {
                // Общая стоимость склада
                var totalStockValue = await _dbConnection.ExecuteScalarAsync(
                    "SELECT SUM(StockQuantity * Price) FROM Materials");
                lblTotalStockValue.Text = $"Общая стоимость склада: {totalStockValue:C}";

                // Количество материалов
                var materialsCount = await _dbConnection.ExecuteScalarAsync(
                    "SELECT COUNT(*) FROM Materials");
                lblMaterialsCount.Text = $"Материалов на складе: {materialsCount}";

                // Количество отгрузок за месяц
                var shipmentsCount = await _dbConnection.ExecuteScalarAsync(
                    "SELECT COUNT(*) FROM Shipments WHERE ShipmentDate >= CURRENT_DATE - INTERVAL '30 days'");
                lblShipmentsCount.Text = $"Отгрузок за месяц: {shipmentsCount}";

                // Общая сумма отгрузок за месяц
                var totalShipmentsValue = await _dbConnection.ExecuteScalarAsync(
                    "SELECT COALESCE(SUM(TotalAmount), 0) FROM Shipments WHERE ShipmentDate >= CURRENT_DATE - INTERVAL '30 days'");
                lblTotalShipmentsValue.Text = $"Общая сумма отгрузок за месяц: {totalShipmentsValue:C}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении статистики: {ex.Message}", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReportsAsync();
        }

        private void btnExportStock_Click(object sender, EventArgs e)
        {
            ExportToCsv(dgvStockReport, "Остатки_на_складе.csv");
        }

        private void btnExportShipments_Click(object sender, EventArgs e)
        {
            ExportToCsv(dgvShipmentsReport, "Отгрузки_за_месяц.csv");
        }

        private void btnExportCustomers_Click(object sender, EventArgs e)
        {
            ExportToCsv(dgvCustomersReport, "Отчет_по_заказчикам.csv");
        }

        private void ExportToCsv(DataGridView dataGridView, string fileName)
        {
            try
            {
                using var saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV файлы (*.csv)|*.csv",
                    FileName = fileName
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using var writer = new StreamWriter(saveFileDialog.FileName, false, System.Text.Encoding.UTF8);
                    
                    // Заголовки
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        writer.Write(dataGridView.Columns[i].HeaderText);
                        if (i < dataGridView.Columns.Count - 1)
                            writer.Write(",");
                    }
                    writer.WriteLine();

                    // Данные
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            var cellValue = row.Cells[i].Value?.ToString() ?? "";
                            // Экранируем запятые и кавычки
                            if (cellValue.Contains(",") || cellValue.Contains("\""))
                            {
                                cellValue = "\"" + cellValue.Replace("\"", "\"\"") + "\"";
                            }
                            writer.Write(cellValue);
                            if (i < row.Cells.Count - 1)
                                writer.Write(",");
                        }
                        writer.WriteLine();
                    }

                    MessageBox.Show($"Отчет успешно экспортирован в файл: {saveFileDialog.FileName}", 
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте: {ex.Message}", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
