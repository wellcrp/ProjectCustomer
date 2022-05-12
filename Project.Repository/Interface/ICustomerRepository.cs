using Project.Domain.Model;

namespace Project.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<IList<CustomerModel>> postAdd(CustomerModel customer);
    }
}
