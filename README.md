📬 dotnet-rabbitmq-email-service

Projeto de estudo utilizando .NET e RabbitMQ para simular envio e processamento assíncrono de mensagens com padrão Producer/Consumer.

🧠 Sobre o projeto

Este projeto demonstra conceitos fundamentais de mensageria utilizando RabbitMQ com .NET.

A aplicação simula o envio de mensagens (como se fossem e-mails), onde:

Uma API atua como Producer, enviando mensagens para uma fila
Um Worker atua como Consumer, processando essas mensagens de forma assíncrona

⚠️ Este projeto é apenas para fins de estudo e não realiza envio real de e-mails.

🏗️ Arquitetura

	[ API (.NET) ] ---> [ RabbitMQ ] ---> [ Worker (.NET) ]
	     Producer                         Consumer
📦 Estrutura do projeto

	Email.Api        # API responsável por publicar mensagens na fila
	Email.Worker     # Worker responsável por consumir e processar mensagens

🚀 Tecnologias utilizadas
.NET
RabbitMQ
Docker (opcional)

⚙️ Como executar o projeto
1. Subir o RabbitMQ com Docker

		docker run -d --hostname rabbitmq --name rabbitmq \
		-p 5672:5672 -p 15672:15672 rabbitmq:3-management

Painel de gerenciamento:

	http://localhost:15672

Usuário: guest
Senha: guest

2. Executar o Worker
   
		cd Email.Worker
		dotnet run

3. Executar a API
   
		cd Email.Api
		cd RabbitMQ
		dotnet run

4. Enviar uma mensagem

    ⚠️ A porta pode variar a cada execução. Verifique no terminal a mensagem:
   
           Now listening on: http://localhost:XXXX
   
curl -X POST http://localhost:XXXX/email \
-H "Content-Type: application/json" \
-d '{"to":"teste@email.com","subject":"Oi","body":"Teste fila"}'

A API possui integração com Swagger para facilitar os testes dos endpoints. Após iniciar a aplicação, acesse no navegador: 

	http://localhost:XXXX/swagger

🧪 Resultado esperado

No console do Worker:

📨 Email recebido:

{"to":"teste@email.com","subject":"Oi","body":"Teste fila"}

✅ Email processado!

📚 Conceitos abordados
Mensageria assíncrona
Padrão Producer/Consumer
Filas (Queue)
Desacoplamento entre serviços
Processamento assíncrono
🔥 Possíveis melhorias
Implementar ACK manual
Adicionar retry em caso de falha
Criar Dead Letter Queue
Configuração via appsettings.json
Reutilização de conexão com RabbitMQ
Logs estruturados
💡 Objetivo

Este projeto foi desenvolvido com o objetivo de aprender e praticar conceitos de mensageria utilizando RabbitMQ em aplicações .NET, simulando um cenário comum de processamento assíncrono.
