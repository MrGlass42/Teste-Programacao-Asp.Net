CREATE TABLE PessoaFisica(
	psf_id numeric(6, 0) IDENTITY(1,1) NOT NULL,
	psf_nome varchar(150) NOT NULL,
	psf_sobreNome varchar(150) NOT NULL,
	psf_cpf varchar(20) NOT NULL,
	psf_cep varchar(10) NOT NULL,
	psf_logradouro varchar(100) NOT NULL,
	psf_numero varchar(5) NOT NULL,
	psf_complemento varchar(100) NULL,
	psf_bairro varchar(100) NOT NULL,
	psf_cidade varchar(100) NOT NULL,
	psf_uf varchar(20) NOT NULL,
	psf_dt_nasc date NOT NULL,
 CONSTRAINT PK_PessoaFisica PRIMARY KEY CLUSTERED 
);


CREATE TABLE PessoaJuridica(
	psj_id numeric(6, 0) IDENTITY(1,1) NOT NULL,
	psj_cnpj varchar(20) NOT NULL,
	psj_razaoSocial varchar(100) NOT NULL,
	psj_nomeFantasia varchar(100) NOT NULL,
	psj_logradouro varchar(100) NOT NULL,
	psj_numero varchar(5) NOT NULL,
	psj_complemento varchar(100) NULL,
	psj_bairro varchar(100) NOT NULL,
	psj_cidade varchar(100) NOT NULL,
	psj_uf varchar(10) NOT NULL,
	psj_cep varchar(10) NOT NULL,
 CONSTRAINT PK_PessoaJuridica PRIMARY KEY CLUSTERED  
 );
