#language: pt-br

Funcionalidade: Contato
	Como um cliente ou fornecedor
	Desejo acessar o sistema
	Para entrar em contato os repossaveis

@FluxoDeContato
Cenario: Fluxo de Contato
	Dado um usuario acessar o sistema
	E clicar em Contato
	Quando preencher as informações solicitadas
	E clicar em Enviar
	Entao o sistema deve exibe uma mensagem de agradecimento