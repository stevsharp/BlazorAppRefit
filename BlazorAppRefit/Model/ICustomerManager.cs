using Refit;

namespace BlazorAppRefit.Model
{
    public interface ICustomerManager
    {
        [Get("/Customer")]
        Task<List<Customer>> GetCustomers();

        [Get("/Customer/{id}")]
        Task<Customer> GetCustomer(int id);

        [Post("/Customer")]
        Task New([Body] Customer customer);

        [Put("/Customer/{id}")]
        Task Update(int id, [Body] Customer customer);

        [Delete("/Customer/{id}")]
        Task Delete(int id);
    }
}
