-- Creación de la tabla Clients
CREATE TABLE client (
    client_id INT PRIMARY KEY,
    number_document VARCHAR(20),
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email VARCHAR(100)
);

-- Creación de la tabla Bills
CREATE TABLE bill (
    bill_id INT PRIMARY KEY,
    client_id INT,
    company_name VARCHAR(100),
    nit VARCHAR(20),
    code VARCHAR(20),
    FOREIGN KEY (client_id) REFERENCES Client(client_id)
);

-- Creación de la tabla Products
CREATE TABLE product (
    product_id INT PRIMARY KEY,
    name_product VARCHAR(100),
    description_product VARCHAR(255),
    Attribute_4 VARCHAR(50)
);

-- Creación de la tabla Bills_Products (para la relación muchos a muchos entre Bills y Products)
CREATE TABLE bill_product (
    bill_productid INT PRIMARY KEY,
    bill_id INT,
    product_id INT,
    FOREIGN KEY (bill_id) REFERENCES Bill(bill_id),
    FOREIGN KEY (product_id) REFERENCES Product(product_id)
);

-- Creación de la tabla usuario
CREATE TABLE usuario (
    usuario_id INT PRIMARY KEY,
    username VARCHAR(50),
    contrasena VARCHAR(100),
    email VARCHAR(100),
    role_id INT,
    FOREIGN KEY (role_id) REFERENCES rol(role_id)
);

-- Creación de la tabla rol
CREATE TABLE rol (
    role_id INT PRIMARY KEY,
    name_rol VARCHAR(50)
);
