using Project.Domain.Model;

namespace Project.Service.Interface
{
    public interface ICustomerService
    {
        Task<IList<CustomerModel>> PostAdd(CustomerModel customer);
    }
}
