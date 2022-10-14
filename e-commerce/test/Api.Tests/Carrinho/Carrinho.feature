Feature: Carrinho
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Adicionar item sem promoção no carrinho
	Given carrinho está vazio
	When adicionar 1 do produto 1 no carrinho
	Then o valor do carrinho deve ser 50

Scenario: Adicionar item com promoção dois por um no carrinho
	Given carrinho está vazio
	And produto 2 possui promoção 1
	When adicionar 2 do produto 2 no carrinho
	Then o valor do carrinho deve ser 30

Scenario: Adicionar item com promoção 3 por 10 no carrinho
	Given carrinho está vazio
	And produto 3 possui promoção 2
	When adicionar 1 do produto 3 no carrinho
	And adicionar 1 do produto 3 no carrinho
	And adicionar 1 do produto 3 no carrinho
	Then o valor do carrinho deve ser 10

Scenario: Adicionar vários itens no carrinho
	Given carrinho está vazio
	And produto 2 possui promoção 1
	And produto 3 possui promoção 2
	When adicionar 1 do produto 1 no carrinho
	And adicionar 3 do produto 2 no carrinho
	And adicionar 4 do produto 3 no carrinho
	Then o valor do carrinho deve ser 130