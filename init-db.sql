-- Criar banco de produtos (já é criado pelo MYSQL_DATABASE)
CREATE DATABASE IF NOT EXISTS products_db;

-- Criar banco de pedidos
CREATE DATABASE IF NOT EXISTS orders_db;

-- Garantir privilégios
GRANT ALL PRIVILEGES ON products_db.* TO 'root'@'%';
GRANT ALL PRIVILEGES ON orders_db.* TO 'root'@'%';
FLUSH PRIVILEGES;