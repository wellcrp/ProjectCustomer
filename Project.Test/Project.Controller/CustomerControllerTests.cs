using Microsoft.AspNetCore.Mvc;
using Moq;
using Project.Api.Controllers;
using Project.Domain.Model;
using Project.Service.Interface;
using Project.Test.Fixture;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Project.Test.Project.Controller
{
    [Collection(nameof(CustomerCollection))]
    public class CustomerControllerTests
    {
        private readonly CustomerFixtureTests _customerFixture;
        private readonly CustomerController _customerController;
        private readonly Mock<ICustomerService> _customerService;

        public CustomerControllerTests(CustomerFixtureTests customerFixture)
        {
            _customerService = new Mock<ICustomerService>();
            _customerFixture = customerFixture;
            _customerController = new CustomerController(_customerService.Object);
        }

        [Fact(DisplayName = "Retorna Dados Salvos")]
        [Trait("Controller", "Cliente Cadastrado")]
        public async Task PostAdd_NovoCliente_DeveSalvarNoArray()
        {
            //Arrange
            var customer = _customerFixture.GenerateUniqueCustomerSuccess();
            var customerList = _customerFixture.GenerateListCustomer();

            _customerService.Setup(c => c.PostAdd(It.IsAny<CustomerModel>())).ReturnsAsync(customerList);

            //ACT
            var result = await _customerController.PostAdd(customer);

            //Assert
            var objectResult = Assert.IsAssignableFrom<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<List<CustomerModel>>(objectResult.Value);

            Assert.Equal(3, model.Count);            
        }
    }
}
