USE master;
CREATE DATABASE content;
GO

USE content;

CREATE TABLE author (
    id INT PRIMARY KEY,
    name VARCHAR(50) NOT NULL
);