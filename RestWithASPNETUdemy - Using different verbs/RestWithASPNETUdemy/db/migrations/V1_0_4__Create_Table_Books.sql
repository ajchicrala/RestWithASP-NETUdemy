CREATE TABLE books (
ID varchar(12) not null,
AUTHOR longtext,
LAUNCHDATE datetime(6) not null,
PRICE decimal(65,2) not null,
TITLE longtext,
primary key (ID)
);