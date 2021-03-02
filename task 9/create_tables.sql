-- Удалить таблицы
-- drop table products cascade;
-- drop table categories cascade;

-- Создание таблицы Продукты
create table if not exists products (
	id bigserial primary key,
	name varchar(30) not null,
	date_arrival date default current_date
);

-- Создание таблицы Категории
create table if not exists categories (
	id bigserial primary key,
	name varchar(30) not null
);

-- Создание промежуточной таблицы
create table if not exists category_product (
	category_id bigint REFERENCES categories(id) ON DELETE CASCADE,
	product_id bigint REFERENCES products(id) ON DELETE CASCADE
);


