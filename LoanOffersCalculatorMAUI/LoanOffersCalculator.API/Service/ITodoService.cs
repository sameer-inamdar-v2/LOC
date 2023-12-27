//using LoanOffersCalculatorMAUI.ViewModel;

using LoanOffersCalculator.API.Data;
using LoanOffersCalculator.API.Model;

namespace LoanOffersCalculator.API.Services
{
    public interface ITodoService
    {
        List<ToDoModel> GetToDoList();
        Task AddTodo(ToDoModel model);
        bool UpdateTodo(ToDoModel model);
        Task DeleteTodo(Todo model);
        Todo GetTodoById(string id);
    }
}
