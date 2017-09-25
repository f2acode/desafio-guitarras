# Desafio em .NET da TechFit apps: ASP.NET e Web API

## Desafio

Neste projeto, temos a necessidade de criar um cadastro web de guitarras e uma Web API(opcional) que ofereça os dados das guitarras que foram cadastrados (não é necessária a edição via API, somente a lista de guitarras e o detalhe). As informações servidas pela API serão consumidas por cerca de 400 a 700 devices mobiles no mesmo momento. As áreas de negócio não necessitam que ao atualizar uma informação de um instrumento ela esteja atualizada em realtime para os devices que consomem a API (pode existir alguns minutos para que um preço ou informação seja atualizada na api).

Uma Guitarra possui algumas características como: nome (no máximo 400 caracteres), preço (R$), descrição, data de inclusão no cadastro, url da imagem(opcional) e SKU (campo calculado com base no identificador da guitarra no banco e o nome em minúsculo com os espaços substituído por "_", exemplo: Nome: "Fender Telecaster", Id: 213, terá como resultado o seguinte SKU: "213_fender_telecaster" ).

SGBD pode se utilizar o LocalDB.
Layout pode se utilizar o template padrão do ASP.NET MVC ou um de sua preferencia.

## Conhecimento utilizado ##

### SOLID

**SRP - Single Responsability Principle**
*"A class should have one, and only one, reason to change"*

**OCP - Open Closed Principle**
*"Software entities (classes, modules, functions, etc) should be open for extension, but closed for modification."*

**LSP - Liskov Substitution Principle**
*"Let q(x) be a property provable about objects x of type T. Then q(y) should be provable for objects y of type S, where S is a subtype of T".*

**ISP - Interface Segregation Principle**
*"States that no cliente should be forced to depend on methods it does not use"*

**DIP - Dependency Inversion Principle**
*"High-level modules should not depend on low-level modules, Both should depend on abstrations. Abstractions should not depend on details. Details should depend on abstrations."*

### Testes

Postman

### Tratamento de erros