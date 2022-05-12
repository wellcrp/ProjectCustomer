using Project.Domain.Model;
using Project.Repository.Interface;

namespace Project.Repository.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private IList<CustomerModel> _customers;

        public CustomerRepository()
        {
            _customers = new List<CustomerModel>();
        }

        public Task<IList<CustomerModel>> postAdd(CustomerModel customer)
        {
            try
            {
                if (customer.CustomerAge != 0)
                    _customers.Add(customer);

                if (_customers.Count.Equals(0))
                    throw new Exception("NÃO FOI POSSIVEL GRAVAR, ACONTECEU UM ERRO !");

                return Task.FromResult(_customers);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
