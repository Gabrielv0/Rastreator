# README #
## Este repositório é dedicado ao projeto 01 do módulo 03 do Curso DevInHouse- Turma Edp ##
O projeto contém um formulário que armazena os dados digitados do usuário, com objetivo de armazenar os codigos de rastreios de compras afim de unificar tudo em um só lugar e facilitar o acompanhamento.

## Conteúdo da pagina
- Tela de login
- Tela de Registro
- Tela Home(onde o usuario cadastra seus rastreios)
- Tela de Rastreio(onde o usuario busca as encomendas pelo nome ou faz uma listagem total)
- Ranking(Ainda em desenvolvimento*)

## Tela de Login: 
Contém 2 inputs e 1 botão(Log in):

1. Email: Input do tipo text.
2. Password: Input do tipo text.
3. Log in: Button do tipo submit, verifica os dados informados pelo usuário no banco e redireciona a tela home caso haja sucesso ao encontrar.

## Tela de Registro:
Contém 3 inputs e 1 botão(Register):

1. Email: Input do tipo text.
2. Password: Input do tipo text.
3. Register: Button do tipo submit, confere as informações passada pelo usuário e caso não exista cria uma nova conta no banco de dados.

## Tela Home:
Contém 4 labels, 5 inputs correspondentes e 1 botão (Adicionar):

1. Nome: Input do tipo text.
2. Empresa: Input do tipo text.
3. Codigo de Rastreio: Input do tipo text.
4. Data da Compra: Input do tipo date-time.
5. Botões Adicionar: Button do tipo submit, envia as informações para fila para ser consumida e salva no banco de dados.


## Tela de Rastreio:
Contém 1 label, 1 input e 2 botões(Pesquisar e Listar tudo):

1. Nome do Produto: Input do tipo text.
2. Pesquisar: Button do tipo submit, faz uma busca no banco de dados do nome do produto informado no input e retorna as informações na tela.
3. Pesquisar: Button do tipo submit, retorna todos os rastreios ja cadastrado.

## Tela Ranking 
Ainda em desenvolvimento*.

## Desenvolvido por Gabriel Fernandes Amorim ##