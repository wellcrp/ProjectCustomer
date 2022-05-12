using Project.Repository.Repository;
using Project.Test.Fixture;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Project.Test.Project.Repository
{
    [Collection(nameof(CustomerCollection))]
    public class CustomerRepositoryTests
    {
        private readonly CustomerFixtureTests _customerFixture;
        private readonly CustomerRepository _customerRepository;
        public CustomerRepositoryTests(CustomerFixtureTests customerFixture)
        {
            _customerFixture = customerFixture;
            _customerRepository = new CustomerRepository();
        }

        [Fact(DisplayName = "Retorna Lista de Cliente Salvo")]
        [Trait("Cliente Repository", "Lista de Cliente Cadastrado")]
        public async Task postAdd_AdicionaCliente_DeveRetornarClienteAdicionado()
        {
            //Arrange
            var customer = _customerFixture.GenerateUniqueCustomerSuccess();

            //Act
            var result = await _customerRepository.postAdd(customer);

            //Assert -> Não deve ser null
            Assert.NotNull(result);

            Assert.True(result.Count > 0);
        }

        [Fact(DisplayName = "Retorna Lista de Cliente Salvo")]
        [Trait("Cliente Repository", "Lista de Cliente Cadastrado")]
        public async Task postAdd_NaoAdicionaCliente_DeveRetornarExceptionAoAdicionarCliente()
        {
            //Arrange
            var customer = _customerFixture.GenerateUniqueCustomerNomeEmBrancoIdadeZerada();

            //Act
            var exception = await Assert.ThrowsAsync<Exception>(() => _customerRepository.postAdd(customer));

            //Assert -> deve Gerar Throws
            Assert.NotEmpty(exception.Message);

            Assert.Equal("NÃO FOI POSSIVEL GRAVAR, ACONTECEU UM ERRO !", exception.Message);
        }
    }
}
