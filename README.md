## Projeto de Teste de Escalabilidade no Azure Container Apps
# Visão Geral
Este projeto tem como objetivo demonstrar e testar a escalabilidade no Azure Container Apps por meio da implementação de dois microserviços: ProdutoService e PedidoService.

ProdutoService: Este microserviço é responsável pela gestão de produtos e alimenta o Azure Storage Queue sempre que um novo produto é comprado. Ele oferece a funcionalidade de criação de compras de produtos por meio do endpoint api/purchases.

PedidoService: O PedidoService é responsável por buscar os pedidos no Azure Storage Queue e processá-los. Ele monitora a fila de pedidos e processa os pedidos em segundo plano.

# Funcionalidades
### Criação de Compras de Produtos:

O ProdutoService oferece um endpoint api/purchases para criar compras de produtos. Quando uma compra é criada, os detalhes da compra são enviados para o Azure Storage Queue para processamento posterior.

### Processamento de Pedidos:

O PedidoService busca pedidos na fila do Azure Storage Queue e os processa em segundo plano. Isso permite que os pedidos sejam processados de forma assíncrona, garantindo escalabilidade e desempenho.
Configuração
Antes de executar o projeto, é necessário configurar as credenciais do Azure Storage e outras configurações necessárias. Certifique-se de definir corretamente a string de conexão do Azure Storage no código do ProdutoService e do PedidoService.


# Arquitetura
![image](https://github.com/Eubrandao/AzureContainerApps/assets/55800764/c6306b44-fe4d-4429-a58a-2577398dd9a1)


# Contribuição
Se você deseja contribuir para este projeto, sinta-se à vontade para criar pull requests ou abrir issues no repositório.







