-- Создание базы данных для учета отгрузки стройматериалов
CREATE DATABASE construction_materials_db;

-- Подключение к базе данных
\c construction_materials_db;

-- Создание таблицы стройматериалов
CREATE TABLE Materials (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Description TEXT,
    Unit VARCHAR(50) NOT NULL, -- единица измерения (шт, м, кг, м², м³)
    Price DECIMAL(10,2) NOT NULL,
    StockQuantity INTEGER NOT NULL DEFAULT 0,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Создание таблицы заказчиков
CREATE TABLE Customers (
    Id SERIAL PRIMARY KEY,
    CompanyName VARCHAR(255) NOT NULL,
    ContactPerson VARCHAR(255),
    Phone VARCHAR(50),
    Email VARCHAR(255),
    Address TEXT,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Создание таблицы отгрузок
CREATE TABLE Shipments (
    Id SERIAL PRIMARY KEY,
    ShipmentNumber VARCHAR(50) UNIQUE NOT NULL,
    CustomerId INTEGER NOT NULL REFERENCES Customers(Id),
    ShipmentDate DATE NOT NULL,
    Status VARCHAR(50) NOT NULL DEFAULT 'Pending', -- Pending, Shipped, Delivered, Cancelled
    TotalAmount DECIMAL(12,2) DEFAULT 0,
    Notes TEXT,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Создание таблицы деталей отгрузки
CREATE TABLE ShipmentDetails (
    Id SERIAL PRIMARY KEY,
    ShipmentId INTEGER NOT NULL REFERENCES Shipments(Id) ON DELETE CASCADE,
    MaterialId INTEGER NOT NULL REFERENCES Materials(Id),
    Quantity INTEGER NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL,
    TotalPrice DECIMAL(12,2) NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Создание индексов для оптимизации запросов
CREATE INDEX idx_shipments_customer_id ON Shipments(CustomerId);
CREATE INDEX idx_shipments_date ON Shipments(ShipmentDate);
CREATE INDEX idx_shipment_details_shipment_id ON ShipmentDetails(ShipmentId);
CREATE INDEX idx_shipment_details_material_id ON ShipmentDetails(MaterialId);

-- Вставка тестовых данных
INSERT INTO Materials (Name, Description, Unit, Price, StockQuantity) VALUES
('Цемент М400', 'Портландцемент марки М400', 'кг', 15.50, 1000),
('Песок речной', 'Песок речной фракции 0-5мм', 'м³', 800.00, 50),
('Щебень гранитный', 'Щебень гранитный фракции 5-20мм', 'м³', 1200.00, 30),
('Арматура А500С', 'Арматура класса А500С диаметр 12мм', 'м', 45.00, 500),
('Кирпич красный', 'Кирпич керамический полнотелый', 'шт', 8.50, 2000),
('Бетон М300', 'Готовый бетон марки М300', 'м³', 3500.00, 20);

INSERT INTO Customers (CompanyName, ContactPerson, Phone, Email, Address) VALUES
('ООО "СтройИнвест"', 'Иванов Иван Иванович', '+7(495)123-45-67', 'ivanov@stroiinvest.ru', 'г. Москва, ул. Строительная, д.1'),
('ЗАО "МонолитСтрой"', 'Петров Петр Петрович', '+7(495)234-56-78', 'petrov@monolit.ru', 'г. Москва, ул. Бетонная, д.15'),
('ИП Сидоров А.А.', 'Сидоров Алексей Александрович', '+7(495)345-67-89', 'sidorov@mail.ru', 'г. Москва, ул. Кирпичная, д.25');

-- Создание функции для автоматического обновления UpdatedAt
CREATE OR REPLACE FUNCTION update_updated_at_column()
RETURNS TRIGGER AS $$
BEGIN
    NEW.UpdatedAt = CURRENT_TIMESTAMP;
    RETURN NEW;
END;
$$ language 'plpgsql';

-- Создание триггеров для автоматического обновления UpdatedAt
CREATE TRIGGER update_materials_updated_at BEFORE UPDATE ON Materials
    FOR EACH ROW EXECUTE FUNCTION update_updated_at_column();

CREATE TRIGGER update_customers_updated_at BEFORE UPDATE ON Customers
    FOR EACH ROW EXECUTE FUNCTION update_updated_at_column();

CREATE TRIGGER update_shipments_updated_at BEFORE UPDATE ON Shipments
    FOR EACH ROW EXECUTE FUNCTION update_updated_at_column();
