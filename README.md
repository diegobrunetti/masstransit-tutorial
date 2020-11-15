# MassTransit Tutorial

Este repositório faz parte do material de auxílio do curso completo [Comunicação assíncrona com .NET Core, MassTransit e RabbitMQ](https://www.youtube.com/channel/UCNnrp4OQMv6tXl0wJ-oXNMA/featured), disponível gratuitamente no YouTube.

Este repositório se organiza da seguinte forma:

- **solucao-completa**: contém o código completo desenvolvido durante o curso
- **projeto-base**: contém o projeto base idêntico ao utilizado no início do curso, para quem quiser codar enquanto acompanhar os vídeos.

## Como rodar os projetos:

Tanto a solução completa quanto a básica dependem do MySQL e do RabbitMQ. Na raíz de cada solução existe um arquivo _docker-compose.yml_ com a configuração de ambas as dependências. Abra um prompt de comando na raíz do diretório que contém o arquivo _docker-compose.yml_ e execute o seguinte comando (é necessário ter o [docker](https://www.docker.com/products/docker-desktop) instalado):

```
docker-compose up -d
```

Isso irá baixar as imagens do MySQL, Adminer (Admin web do MySQL) e do RabbitMQ e subir os containers necessários. Para verificar que os containers estão rodando corretamente, execute um `docker ps` ou acesse as URLs do MySQL Adminer e RabbitMQ:

- Adminer: http://localhost:8080/ (**user**: admin, **senha**: tutorial)
- RabbitMQ: http://localhost:15672 (**user**: guest, **senha**: guest)

Com as dependências devidamente rodando, basta rodar a WebAPI. Abra um prompt de comando dentro do diretório **/Api** e execute ` dotnet run`. A aplicação deverá rodar normalmente e aplicar **as database migrations que irão criar o banco de dados e tabelas necessárias** no MySQL.

Verifique que a API está rodando na porta 5000, acessando http://localhost:5000/swagger.
