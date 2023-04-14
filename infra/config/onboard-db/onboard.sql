SELECT 'CREATE DATABASE onboard'
WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'onboard')\gexec

\connect onboard;

CREATE TABLE author (
    id SERIAL NOT NULL,
    name varchar(250) NOT NULL,
    email varchar(150) NOT NULL,
    cpf varchar(11) NOT NULL,
    phone varchar(11) NOT NULL,
    PRIMARY KEY (id)
);