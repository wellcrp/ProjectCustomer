using System.ComponentModel.DataAnnotations;

namespace Project.Domain.Model
{
    public class CustomerModel
    {
        public CustomerModel(int customerAge, string customerName, string customerEmail)
        {
            CustomerAge = customerAge;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
        }

        public int CustomerAge { get; private set; }        
        public string CustomerName { get; private set; } = default!;
        public string CustomerEmail { get; private set; } = default!;

        public void validateCustomerName(string customerName)
        {
            if (String.IsNullOrEmpty(customerName))
                throw new Exception($"Nome Cliente em branco !");
        }
    }
}
