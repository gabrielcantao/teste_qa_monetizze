#language: pt-br

Funcionalidade: Loja
	Como um cliente
	Desejo acessar o sistema
	Para utilizar o fluxo de compra

@FluxoDeCompra
Cenario: Fluxo de Compra
	Dado usuario acessar a loja
	E selecionar um vinho
	Quando adicionar duas ou mais quantidades do mesmo vinho
	E clicar em Prosseguir
	Quando preencher todos os campos obrigatorios
	E clicar em Finalizar Compra
	Entao o sistema deve exibir a mensagem de confirmação de compra







	