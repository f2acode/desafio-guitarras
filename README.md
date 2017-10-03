# Desafio em .NET da TechFit apps: ASP.NET e Web API

## Desafio

Neste projeto, temos a necessidade de criar um cadastro web de guitarras e uma Web API(opcional) que ofereça os dados das guitarras que foram cadastrados (não é necessária a edição via API, somente a lista de guitarras e o detalhe). As informações servidas pela API serão consumidas por cerca de 400 a 700 devices mobiles no mesmo momento. As áreas de negócio não necessitam que ao atualizar uma informação de um instrumento ela esteja atualizada em realtime para os devices que consomem a API (pode existir alguns minutos para que um preço ou informação seja atualizada na api).

Uma Guitarra possui algumas características como: nome (no máximo 400 caracteres), preço (R$), descrição, data de inclusão no cadastro, url da imagem(opcional) e SKU (campo calculado com base no identificador da guitarra no banco e o nome em minúsculo com os espaços substituído por "_", exemplo: Nome: "Fender Telecaster", Id: 213, terá como resultado o seguinte SKU: "213_fender_telecaster" ).

SGBD pode se utilizar o LocalDB.
Layout pode se utilizar o template padrão do ASP.NET MVC ou um de sua preferencia.

## Conhecimento utilizado ##

### SOLID

Container para injeção de dependência utilizado: 

[StructureMap](http://structuremap.github.io/)

[Tutorial](https://www.exceptionnotfound.net/using-automapper-with-structuremap-in-asp-net-web-api/)

#### SRP - Single Responsability Principle
*"A class should have one, and only one, reason to change"*

Examples with problem:

- A class that manipulates data, makes validation and add itself to database.
- A class should not add itself to the database, it should use another class as a model.
- A class should not connect directly to the database.
A class should not make generic validations

#### OCP - Open Closed Principle
*"Software entities (classes, modules, functions, etc) should be open for extension, but closed for modification."*

Example with problems:

- A class that that has multiple types of debit on a account. There are validations accoding to the type of the account.
- A class should not be open to modification, just for extension
- The solution if to make different classes for each specific account and inheritance from the main class: DebitoConta, DebitoContaPoupança

Solution:

- Use a abstract class and make derivations according to that

#### LSP - Liskov Substitution Principle
*"Let q(x) be a property provable about objects x of type T. Then q(y) should be provable for objects y of type S, where S is a subtype of T".*

Problems:
- Take care about inheritance, it's not even true that one class is children of another
- Square and retangle isn't the same thing

#### ISP - Interface Segregation Principle
*"States that no cliente should be forced to depend on methods it does not use"*

Example with problems:

- We have a interface IRegister with some methods, ClientRegister that inherits from IRegister and ProductRegister
- Here we can see that client and product have different methods, but both needs to implement all the methods
- Then we just separate through different interfaces

#### DIP - Dependency Inversion Principle
*"High-level modules should not depend on low-level modules, Both should depend on abstrations. Abstractions should not depend on details. Details should depend on abstrations."*

Annotations:

- Depend on abstration and not implementation
- Where we have a concrete class instantiated we have a coupling and that's not good
- Some classes (the lower level to database, for example) could not be abstract and that's ok
- A container will take care about make a instance of the concrete class, that keep your code imutable on certain points

Benefits:
- If the concrete class change the name that doesn't matter because we're using the abstract class of it.

### Testes

Postman

### Tratamento de erros
