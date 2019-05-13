# Desafio

Criei um sistema distribuído em dois controller:

#ItemController
Que representa todos os itens do sistema CD, DVD e Livro.

Dentro de cada controller eu tenho um crud completo onde eu posso adicionar itens por tipo, depois de adicionar eu posso buscar por palavra chave, editar, emprestar, pegar de volta e excluir.

Dentro do ItemController existem 4 requisições GET, e eu tive que aprender a dizer para API como ela deve tratar cada requisição que chegar para ela, tive uma certa dificuldade no começo mas fazendo algumas pesquisas na internet consegui entender como fazer, por exemplo eu queria buscar por um item passando o nome, mas o programa retornava um erro: 

“An unhandled exception occurred while processing the request. AmbiguousMatchException: The request matched multiple endpoints. Matches:
desafio.Controllers.ItemController.Get (desafio) desafio.Controllers.ItemController.Buscar (desafio) Microsoft.AspNetCore.Routing.Matching.DefaultEndpointSelector.ReportAmbiguity(CandidateSet candidates)”


O programa não sabia em qual GET ele deveria ir, então aprendi a passar o a ActionResult na URL para o programa entender a ActionResult que eu queria naquele momento, a rota [HttpGet("Buscar/{name}")], está indo na API/Controller/Action e passando o parâmetro nome, então consegui entender como dizer para a api a rota que eu espero que ela faça.
Além do verbo GET, usei outros verbos como por exemplo o POST, PUT e o DELETE, os dois últimos eu nunca tinha usado em aplicação nenhuma, eu entendi que o PUT é utilizado para atualizar e o delete para deletar.
ContactController 
No ContactController eu mantive a mesma pegada porém sem a funcionalidade de buscar um contato por nome, os contatos são listados por ordem de adição no sistema e além de adicionar, podemos editar e excluir.

#Interface

Foi criado um novo projeto na mesma solução requisitando a API, o projeto de interface está em  ASP.NET Core MVC.
Ao requisitar ou enviar algum dado para a API estou manipulando o JSON com a biblioteca JQuery + Ajax que foi outra coisa nova que aprendi.

O front-end na parte de Item está bem simples com formulários ocultos e assim que são solicitados eles aparecem na tela, são usados e ao enviar desaparecem, fiz isso usando a propriedade do HTML hide para esconder, e ao clicar no botão da ação eu adiciono o display block para ele aparecer na tela. Usei algumas classes do bootstrap para melhorar o visual mas ainda não domino a biblioteca bootstrap, tenho conhecimentos bem básicos sobre ela, mas acabo olhando sua documentação e aplicando algumas coisas.

O front de contatos ficou um pouco melhor porque utilizei o bootstrap um pouco mais do que na página que trata sobre item, no contato eu utilizei o modal para exibir o formulário que adiciona e edita os contatos e nos botões utilizei a class que deixa os botões mais estilizados, tudo isso utilizando referências de cursos que estudo na internet e a própria documentação do bootstrap.

Outra coisa muito importante que aprendi foi o habilitar solicitações entre origens (CORS) no ASP.NET Core, é mais um conhecimento novo que adquiri com esse desafio, a permitir que outras aplicações façam requisição para minha API.

#API

Antes de participar da entrevista eu não tinha nenhuma experiência com API, porém no dia em que aconteceu a entrevista, já peguei um artigo que explicava como fazer uma api, imaginando que o desafio poderia pedir o desenvolvimento de uma api, então foi a partir desse artigo que comecei a aprender, e foi uma experiência muito rica, aprendi como funciona a API e que não é “tão diferente” do que eu já fazia com ASP.NET Core MVC, o bom uso da API é que posso requisitá-la de várias plataformas como web, mobile e etc...

#Banco de dados

O banco de dados acredito que foi o maior desafio de todos, eu nunca realizei nem pesquisas sobre banco de dados NoSQL, mas topei aceitar o desafio e optei por persistir os dados em mongoDB, aprendi o fazer o crud básico e não achei tão complicado, olhando as referências de estudo eu pude entender como fazer o crud e aplicar no sistema.

#Injeção de dependências 

A princípio estava injetando a própria classe para não  instanciar toda vez o objeto, mas depois tive que fazer umas mudanças e passei a injetar a classe de interface. 

#Testes unitários

Acabei deixando o teste unitário por último pois quis atacar logo o que eu tinha mais fresco de aprendizado na minha mente, não implementei a interface nas classes, mas para mockar eu preciso da interface, tive que dar uma refatorada que não demandou tanto tempo assim, então apliquei a interface nos modelos do sistema, e conseguir mockar nos testes usei o padrão SUT e usei o AAA (Arrange, Act, Assert) para fazer uma separação do que iria usar e depois configurei como ficaria o teste e de fato a verificação do que deveria acontecer.



#Github

Eu usei o github para versionar meu projeto e o board para me organizar e entregar na data correta.

#Como executar o projeto

1 - SDK 2.2 ou posterior do .NET Core
2 - Visual Studio 2019
3 - instalar o mongoDB 4.0.9
4 - Configurar o mongoDB ( adicionar o caminho da sua pasta bin “C:\Arquivos de Programas\MongoDB\Servidor\<número_de_versão>\bin” a variável de ambiente path do windows, essa alteração possibilita o acesso ao MongoDB a partir de qualquer lugar em seu computador de desenvolvimento.
5- Instalar no nuget a versão mais estável do mongo, -> Install-Package MongoDB.Driver -Version 2.8.0

6 - Instalar no nuget se precisar -> Microsoft.AspNetCore.Mvc.Core 2.2.2
7 - Instalar no nuget se precisar -> Microsoft.AspNetCore.Razor.Design
8 - Instalar no nuget se precisar -> Microsoft.VisualStudio.Web.CodeGenerationDesign 2.2.3

9 - Configurar nas propriedades de inicialização da solução para iniciar os dois projetos ao mesmo tempo projeto (desafio) e (InterfaceDesafio)


#Referências de Estudo 

https://docs.microsoft.com/pt-br/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-2.2&tabs=visual-studio#add-a-model
https://docs.microsoft.com/pt-br/aspnet/core/security/cors?view=aspnetcore-2.2
https://docs.microsoft.com/pt-br/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.2&tabs=visual-studio#call-the-api-with-jquery

#Considerações finais

O que eu tenho a dizer é muito obrigado por essa oportunidade de tentar entrar para uma empresa tão bacana e mesmo que ainda não tenha entrado para o time, vocês já contribuíram com a minha evolução e amadurecimento, aprendi muito em pouco tempo de estudo e percebi que em 10 dias dá para  aprender muita coisa como API, configurar CORS, mongoBD, JQuery, Ajax, é só ter foco e comprometimento, acredito que esse teste vai servir como um trampolim na minha jornada como desenvolvedor.

