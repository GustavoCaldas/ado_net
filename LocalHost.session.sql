USE ado_net;

CREATE TABLE funcionario(
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    name VARCHAR(60) NOT NULL,
    age INT NOT NULL,
    cpf VARCHAR(11) NOT NULL
);

INSERT INTO funcionario (name, age, cpf)
VALUES ('joao', 11, '123' ),
('gabriel', 13, '1234' ),
('gustavo', 15, '12345' ),
('ana', 17, '123456' ),
('gabriela', 21, '1234567' );

SELECT * FROM funcionario;

DROP DATABASE ado_net;
CREATE DATABASE ado_net;