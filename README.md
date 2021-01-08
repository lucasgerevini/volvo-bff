# Volvo - Backend For Front
> CRUD de caminhões

## Instruções

Windows:

1. Instale a versão .NET 5.0 SDK  
<https://download.visualstudio.microsoft.com/download/pr/acff3e6a-d8d6-4c2a-a0cb-1853b58055cc/7910b2a414caa17d30b0cb82583cb542/dotnet-sdk-5.0.101-win-x64.exe>
2. Via prompt execute o comando abaixo e verifique se a instalação esta OK, obtenha o numero da versão se OK
```sh
dotnet --version
```
3. Baixe o projeto do git
4. Via terminal acesse a pasta raiz do projeto onde você ve o arquivo Volvo.sln
5. Execute o comando para restaurar o projeto
```sh
dotnet restore
```

## Executando a aplicação
1. Ainda no terminal, estando na pasta raiz do projeto, execute o comando abaixo, acesse a pasta Volvo.BFF 
```sh
cd Volvo.BFF
```
2. Executar a aplicação, no prompt digite
```sh
dotnet run --urls=http://localhost:5000/
```
3. No browser acesse <http://localhost:5000/swagger/index.html>

## Executando os testes
1. Ainda no terminal, estando na pasta raiz do projeto, execute o comando abaixo, acesse a pasta Volvo.Test 
```sh
cd Volvo.Test
```
2. Execute o comando para efetuar os testes
```sh
dotnet test
```
