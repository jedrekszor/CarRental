CREATE TABLE cars(licenceNo varchar(255), brand varchar(255), model varchar(255), mileage integer, passengers integer, price float, primary key(licenceNo));
CREATE TABLE clients(clientId varchar(255), name varchar(255), surname varchar(255), licNo varchar(255), age integer, primary key(clientId));
CREATE TABLE orders(orderId varchar(255), clientId varchar(255), carId varchar(255), price float, rentDate date, returnDate date, primary key(orderId), foreign key (clientId) references clients(clientId), foreign key (carId) references cars(licenceNo));
CREATE TABLE	orders_history(
				
				orderId varchar(255), 
				clientId varchar(255), 
				carId varchar(255), 
				rentDate date, 
				returnDate date,
				distance int,
				finalPrice float,
				feedback varchar(255));
