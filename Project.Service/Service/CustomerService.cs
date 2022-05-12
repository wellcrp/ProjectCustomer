using Project.Domain.Model;
using Project.Repository.Interface;
using Project.Service.Interface;

namespace Project.Service.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IList<CustomerModel>> PostAdd(CustomerModel customer)
        {
            var resultCustomer = new CustomerModel(customer.CustomerAge, customer.CustomerName, customer.CustomerEmail);

            resultCustomer.validateCustomerName(customer.CustomerName);

            var result = await _customerRepository.postAdd(customer);

            return result;
        }
    }
}
