using Moq;
using Project.Domain.Model;
using Project.Repository.Interface;
using Project.Service.Service;
using Project.Test.Fixture;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Project.Test.Project.Service
{
    [Collection(nameof(CustomerCollection))]
    public class CustomerServiceTests
    {
        private readonly CustomerFixtureTests _customerFixture;
        private readonly CustomerService _customerService;
        private readonly Mock<ICustomerRepository> _customerRepository;

        public CustomerServiceTests(CustomerFixtureTests customerFixture)
        {
            _customerFixture = customerFixture;
            _customerRepository = new Mock<ICustomerRepository>();
            _customerService = new CustomerService(_customerRepository.Object);
        }

        [Fact(DisplayName = "Retorna Cliente Salvo")]
        [Trait("Cliente Service", "Cliente Cadastrado")]
        public async Task PostAdd_AdicionaCliente_DeveRetornarListaDeCliente()
        {
            //Arrange
            var customer = _customerFixture.GenerateUniqueCustomerSuccess();
            var listCustomer = _customerFixture.GenerateListOneCustomerSuccess();

            _customerRepository.Setup(x => x.postAdd(It.IsAny<CustomerModel>())).ReturnsAsync(listCustomer);

            //ACT
            var result = await _customerService.PostAdd(customer);

            //Assert -> Deve Conter apenas 1 valor retornado
            Assert.Single(result);

            //Assert -> Deve Verificar se ocorreu invoke method, ao menos 1 vez
            _customerRepository.Verify(x => x.postAdd(It.IsAny<CustomerModel>()), Times.Once());
        }

        [Fact(DisplayName = "Retorna Cliente Erro")]
        [Trait("Cliente Service", "Cliente Sem Nome")]
        public void PostAdd_AdicionaCliente_DeveOcorrerErroNomeVazio()
        {
            //Arrange
            var customer = _customerFixture.GenerateUniqueCustomerNomeEmBrancoIdadeZerada();
            var customerModel = new CustomerModel(customer.CustomerAge, customer.CustomerName, customer.CustomerEmail);

            _customerRepository.Setup(x => x.postAdd(It.IsAny<CustomerModel>())).Throws(new Exception("Nome Cliente em branco !"));

            //ACT
            var exception = Assert.Throws<Exception>(() => customer.validateCustomerName(customer.CustomerName));

            //Assert -> Deve retornar Erro
            Assert.Equal($"Nome Cliente em branco !", exception.Message);
        }
    }
}
