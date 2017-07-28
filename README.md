# Desafio OLX   :sparkles:

Desafio Olx de API Rest retornando um JSON com as categorias do site.

Para melhor implementação de arquitetura e teste unitario foi implementado o web API com o  padrão repository, o banco escolhido foi o In-Memory que usa memoria principal como armazenamento de dados, não precisando assim ter nenhuma configuração ou instalação extra.

![npm](https://www.asp.net/media/2578149/Windows-Live-Writer_8c4963ba1fa3_CE3B_Repository_pattern_diagram_1df790d3-bdf2-4c11-9098-946ddd9cd884.png)

## Configurando ambiente 
1. Baixar o [visual studio 2017](https://www.visualstudio.com/downloads/)
2.  Clonar o repositorio [https://github.com/jacobsenanaizabel/desafio-responsivo-api](https://github.com/jacobsenanaizabel/desafio-responsivo-api)

http://localhost:63889/api/item e seja bem-vindo. 🎉

## Services
### Requests utilizados no sistema 

### Pegar todos os items de categoria  

| Field            | Value                                                                 |
|----------------- |-----------------------------------------------------------------------|
| **URL Template** | http://localhost:63889/api/item                  |
| **Method**       | GET                                                                   |


### Pegar uma categoria especifica 

| Field            | Value                                                                 |
|----------------- |-----------------------------------------------------------------------|
| **URL Template** | http://localhost:63889/api/item/{{id}}           |
| **Method**       | GET                                                                   |


### Criando uma categoria 

| Field            | Value                                                                 |
|----------------- |-----------------------------------------------------------------------|
| **URL Template** | http://localhost:63889/api/item/                 |
| **Method**       | POST                                                                   |

### Atualizar uma categoria

| Field            | Value                                                                      |
|----------------- |----------------------------------------------------------------------------|
| **URL Template** | http://localhost:63889/api/item/{{id}}           |
| **Method**       | PUT                                                                        |


### Deletar uma categoria

| Field            | Value                                                                      |
|----------------- |----------------------------------------------------------------------------|
| **URL Template** | http://localhost:63889/api/item/1               |
| **Method**       | DELETE                                                                     |

