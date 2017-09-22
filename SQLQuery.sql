create table guitarras
(
	idguitarra int primary key identity(1, 1),
	nome varchar(400) not null,
	preco money not null,
	descricao varchar(1000) not null,
	data_inclusao date not null,
	url_imagem varchar(512),
	sku varchar(500) not null,
)
go 

create proc spmostrar 
as select top 200 * from guitarras
order by idguitarra desc
go

create proc spinserir
@nome varchar(400),
@preco money,
@descricao varchar(1000),
@data_inclusao date,
@url_imagem varchar(512) = null,
@sku varchar(500)
as insert into guitarras(nome, preco, descricao, data_inclusao, url_imagem, sku)
values(@nome, @preco, @descricao, @data_inclusao, @url_imagem, @sku)
go

create proc spdeletar
@idguitarra int
as 
delete from guitarras where 
idguitarra = @idguitarra
go

create proc sppegar_ultimo_registro
as select top 1 * from guitarras 
order by idguitarra desc;
go