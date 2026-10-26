--CRIANDO BANCO
CREATE DATABASE programacao_do_zero;
--USAR O BANCO
USE programacao_do_zero;

--CRIAR TABELA USUÁRIO
CREATE TABLE usuario (

id INT NOT NULL AUTO_INCREMENT,
nome VARCHAR(50) NOT NULL,
sobrenome VARCHAR(150) NOT NULL,
telefone VARCHAR(15) NOT NULL,
email VARCHAR(50) NOT NULL,
genero VARCHAR(20) NOT NULL,
senha VARCHAR(30) NOT NULL,
PRIMARY KEY(id)
);

--CRIAR TABELA ENDEREÇO
CREATE TABLE endereco (

id int not null auto_increment,
rua varchar(250) not null,
numero varchar(30) not null,
bairro varchar(150) not null,
cidade varchar(250) not null,
complemento varchar(150) null,
cep varchar(9) not null,
estado varchar(2) not null
PRIMARY KEY(id)
);

--ALTERAR TABELA ENDEREÇOS
alter table endereco add usuario_id int not null;
--CRIAR FOREIGN KEY
ALTER TABLE endereco
ADD constraint FK_usuario foreign key (usuario_id) references usuario(id);

--INSERIR USUÁRIO
insert into usuario
(nome, sobrenome, telefone, email, genero, senha) 
values 
('Nicolas', 'Santos', '(12) 99203-5552', 'contatonicolas2412@gmail.com', 'Masculino', '1123');
--SELECIONAR USUÁRIO
select * from usuario;