using Project.Domain.Model;
using System;
using System.Collections.Generic;
using Xunit;

namespace Project.Test.Fixture
{
    [CollectionDefinition(nameof(CustomerCollection))]
    public class CustomerCollection : ICollectionFixture<CustomerFixtureTests> { }

    public class CustomerFixtureTests : IDisposable
    {
        public CustomerModel GenerateUniqueCustomerSuccess() => new CustomerModel(37, "Wellington", "wellington.cunha@zup.com.br");
        public CustomerModel GenerateUniqueCustomerNomeEmBrancoIdadeZerada() => new CustomerModel(0, "", "wellington.cunha@zup.com.br");

        public IList<CustomerModel> GenerateListOneCustomerSuccess()
        {
            return new List<CustomerModel>
            {
                new CustomerModel(28, "Wellington", "wellington.cunha@zup.com.br"),
            };
        }
        public IList<CustomerModel> GenerateListOneCustomerNomeEmBranco()
        {
            return new List<CustomerModel>
            {
                new CustomerModel(28, "Wellington", "wellington.cunha@zup.com.br"),                
            };
        }

        public IList<CustomerModel> GenerateListCustomer()
        {
            return new List<CustomerModel>
            {
                new CustomerModel(28, "Wellington", "wellington.cunha@zup.com.br"),
                new CustomerModel(29, "Wellington Cristiano", "cristiano.cunha@zup.com.br"),
                new CustomerModel(30, "Wellington Cunha", "cunha.cunha@zup.com.br")
            };
        }

        public void Dispose() { }
    }
}
