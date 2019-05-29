<p align="center">
<h1>Instruções para execução da Api</h1>
</p>

##

### 1 - baixe a versão do código existente na master.

### 2 - Após iniciar o projeto, verifique se o projeto de inicialização é o (BitCoinChallange.Api) caso não seja altere para o mesmo.

### 3 - Ao executar o projeto você sera redirecionado a documentação interativa da Api através do Swagger, lá é possivel executar o endpoint desenvolvido.

No swagger vai estar no menu superior a versão da documentação, no topo se encontra o nome da api e as informações de contato com redirecionamento para o código fonte através da opção WebSite.
Abaixo se encontra as informações iniciais para utilização da Api e teste dos filtros.


###

O projeto utiliza modelagem DDD e alguns patterns de desenvolvimento, também esta utilizando o conceito do S.O.L.I.D para melhor utiliação dos principios da OO.

O ciclo de vida da request inicia-se pela controller que através de um contrato (interface) utiliza os métodos de busca da application.

Na application o pattern Mediator fica responsável pela entrega da query(dto) ao dominio(Domain) aplicação.

No domínio existe um módulo de processamento das querys(todo módulo de processamento tem no fim da nomenclatura a palavra Handler) que neste caso se chama QueryBooksHandler.

Dentro do handler é executado toda orquestração do processo, executando os objetos de validação, specificação e os resultados esperados, 
não contendo essas regras dentro de si mas executando cada módulo necessário a partir de si, como um facade Pattern.

