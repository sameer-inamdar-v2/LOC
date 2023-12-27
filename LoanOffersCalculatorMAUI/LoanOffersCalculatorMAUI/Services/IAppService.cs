using LoanOffersCalculatorMAUI.ViewModel;

namespace LoanOffersCalculatorMAUI.Services
{
    public interface IAppService<T>
    {
        Task<List<T>> GetAllAsync(string requestUri);
        Task<T> SaveAsync(string requestUri, T obj);

        Task<bool> DeleteAsync(string requestUri, string Id);

    }
}
