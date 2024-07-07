# MyMicroservice

Exemplo criado para exemplificar como subir uma aplicação .Net com banco de dados SQL Server em container Docker.

# Rodando a aplicação

Para rodar a aplicação executar o comando "docker compose up"

# Testando via postman

Para testar utilize os endpoints abaixo:

GET -> http://localhost:3000/api/person (lista todos)
POST -> http://localhost:3000/api/person (Insere)
  body:
    {
    "firstname": "Lucas",
    "lastname": "Alonso asdf",
    "birthday": "1989-02-02"
    }

PUT -> http://localhost:3000/api/person?id=4
  body:
    {
    "firstname": "Lucas",
    "lastname": "asdf",
    "birthday": "1989-02-02"
    }

DELETE -> http://localhost:3000/api/person?id=4
# my-microservice
