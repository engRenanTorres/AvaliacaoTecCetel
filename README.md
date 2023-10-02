# Candidato Dev. [Renan Torres](https://www.nansoftware.com.br/).

Trabalho do [Renan Torres](https://www.linkedin.com/in/eng-renan-torres/) para o processo seletivo da Citel Software na vaga de Desenvolvedor Full Stack (.Net Core) - Home Office.
## Tecnologias

<img align="center" alt=".NET" src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white"/>
<img align="center" alt="PostgreSQL" src="https://img.shields.io/badge/postgres-%23316192.svg?style=for-the-badge&logo=postgresql&logoColor=white"/>
<img align="center" alt="docker" src="https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white"/>
<img align="center" alt="Bootstrap" src="https://img.shields.io/badge/bootstrap-%238511FA.svg?style=for-the-badge&logo=bootstrap&logoColor=white"/>

## Descrição

Teste do processo seletivo para vaga de Desenvolvedor Full Stack (.Net Core) - Home Office na [Citel Software](https://www.citelsoftware.com.br/).
## Pré-requisitos

Para rodar o app é preciso ter o [Docker](https://docs.docker.com/engine/install/) e o seu pluguin [Docker-compose](https://docs.docker.com/compose/install/).

Verifique se as portas 5000, 5432 e 8000 da sua máquina estão liberadas. O app irá rodar na 5000, o BD(Postgrees) na 5432 e o pgadmin na 8000.
*Caso necessite trocar o número das portas, altere-as no arquivo 'docker-compose.yml'.

## Lista dos Desafios Propostos pelo processo seletivo

Prazo: 
- [X] 5 dias corridos. Data final: 23:59 de 04/10/2023, Entregue em: 01/10/2023;

Banco de Dados:
- [X] Atividade 1: Criação das entidades de Produto e Categoria;

Backend
- [X] Atividade 2: Criação de Web API MVC ASP NET Core, com CRUD para:
        Api de Produtos e 
        Api de Categorias.
- [X] Atividade 3: Consumir o banco de dados criado;
- [X] Extra 1: Estruturação de Código;
- [X] Extra 2: Qualidade de Escrita;
- [X] Extra 3: Uso de Pattern;

        [X] Extra 3.1: MVC Pattern; 

        [X] Extra 3.2: Repositorie Pattern; 
- [ ] Extra 4: Micro Serviços;
- [X] Extra 5: Injeção de Dependência;
- [ ] Extra 6: Swagger;
- [X] *Bônus*: Testes unitários nas regras de negócio; 
- [X] *Bônus*: Containers Docker; 


Frontend
- [ ] Atividade 4: Criação de WEB APPLICATION consumindo as WEB APIs com os respectivos CRUDS:
        Produtos e 
        Categorias;
- [X] Ativedade 5: Uso de Bootstrap com visual agradável;
- [X] Extra: UX;

Deploy
- [x] Versionar os códigos fontes criados;
- [x] Estrutura/script do banco de dados;
- [X] Devidas instruções, via git BitBucket ou GitHubs;
- [X] Enviar o link ou compactar e enviar via e-mail.

## Pré-requisitos

Para rodar este programa é necessário ter .net sdk, git, docker e docker-compose instalados. 

## Instalação

Download do app pelo git:

```bash
$ git clone https://github.com/engRenanTorres/AvaliacaoTecCetel.git
```
Para rodar a migrações você precisar instalar o donet-ef.
Portanto, abra o terminal e digite o seguinte comando:
```bash
$ dotnet tool install --global dotnet-ef
```
Será preciso rodar as migrações para criar as tabelas e o Banco de dados.

Relembre de verificar se portas 5432 e 8000 do pc estão livres e rode o comando abaixo na mesma pasta onde está o arquivo docker-compose.yml

```bash
$ cd MVCCitel
$ docker-compose up --build db pgadmin
```
Espere o processo terminar e rode as migrações. Entre na pasta do projeto \MVCCitel\MVCCitel e cole o comando:
```bash
$ dotnet run
```

Entre na página [localhost:5000](localhost:5000/) para interagir com o projeto.

* O ideal é subir só o bd primeiro. Pois, é possível que dê erro na ao rodar pela primeira vez, pois o app pode subir enquanto o banco de dados ainda está carregando as informações iniciais.


## Acesso PGADMIN
Se quiser verificar o banco de dados. Acesse o Pgadmin em localhost:8000

O Pgadmin pede login, você pode acessá-lo com:

- Usuário: admin@admin.com
- Senha: admin

## Rodando o app

Existe o menu principal onde você pode listar categorias, ou produtos.

## Estrutura do Banco de Dados

Você pode verificar o comando SQL para geração do banco de dados nos arquivos dentro da pasta:

/MVCCitel/MVCCitel/Migrations

*As migrações são iniciadas automaticamente após o inicio do app.

## Rodando o app dentro do container

* Tentarei tempo durante a semana para configurar o container do .net no mesmo docker-compose do banco de dados.


## Testes

Realizei os testes unitários das regras de negócios das categorias.

## Suporte

Só me procurar [meu linkedin](https://www.linkedin.com/in/eng-renan-torres/) 

ou conheça meu trabalho em [site pessoal](https://www.nansoftware.com.br/).
