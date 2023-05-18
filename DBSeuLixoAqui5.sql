drop database dbAquiseulixo;

create database dbAquiseulixo;

use dbAquiseulixo;

create table tbFuncionarios(
codfunc int not null auto_increment,
cargo varchar(100), 
nome varchar(100),
senha varchar(18),
email varchar(100),
endereco varchar(100),
telefone char(20),
cpf char(14) not null,
cep char(9),
estado varchar (20),
siglaEst char(2),
cidade varchar(50),
bairro varchar(50),
numero char(10),
complemento varchar(50),
primary key(codfunc));


create table tbLocalizacao(
codLoc int not null auto_increment,
endereco varchar(100),
numero char(10),
cep char(8),
complemento varchar(50),
bairro varchar(50),
cidade varchar(50),
siglaEst char(2),
primary key	(codLoc)
);


create table tbParceiro(
codPar int not null auto_increment,
nome varchar(100) not null,
email varchar(100),
telefone char(14),
cnpj char(14) not null,
endereco varchar(100),
numero char(10),
cep char(8),
complemento varchar(50),
bairro varchar(50),
cidade varchar(50),
siglaEst char(2),
primary key(codPar));

-- insert into tbFuncionarios(cargo, nome, senha, email, endereco, telefone, cpf, cep, estado, siglaEst, cidade, bairro, numero, complemento)
--	values ('administração','mateus','123456','mateus@gmail.com','rua ivaldo','(11) 98574-8582','560.054.738-24','04750000', 'São paulo', 'SP', 'São Paulo','Santo Amaro','22','vila uberto pasquali');

--	select * from tbFuncionarios where nome like '%m%';

-- create table tbUsuario(
-- codusu int not null auto_increment,
-- nomeUsu varchar(100),
-- emailUsu varchar(100),
-- senhaUsu varchar(18),
-- telefoneUsu char(14),
-- primary key(codusu),
-- foreign key (codfunc);	


-- insert into tbUsuario(nomeUsu,emailUsu,senhaUsu,telefoneUsu)
-- 	values ('Thiago', 'thiagosss@gmail.com', '123456', '(11) 94002-8922');
-- 
-- 	insert into tbUsuario(nomeUsu,emailUsu,senhaUsu,telefoneUsu)
-- 	values ('Rodolfo', 'Rodolfo@gmail.com', '1234567', '(11) 94002-8922');*/



-- insert into tbLocalizacao(endereco, numero, cep, complemento, bairro, cidade, siglaEst)
-- 	values('av.sao jose de limeira', '672', '05870-200', '@','vila madalena', 'São 	Paulo', 'SP');
-- insert into tbLocalizacao(endereco, numero, cep, complemento, bairro, cidade, siglaEst)
-- 	values('Av. Dom José', '666', '36824-140', '@','Embu das Artes', 'São 	Paulo', 'SP');

-- insert into tbParceiro(nome, email, telefone, cnpj, cep, siglaEst, endereco, cidade, bairro, numero, complemento )
--     values('aguas de lindoia', 'aguasdelindoia@gmail.com', '(11) 94748-2712', '60.749.458/0001-70', '07058-400', 'SP', 'Av.Dom José', 'São Paulo', 'vila olimpia', '800', 'Casa');        