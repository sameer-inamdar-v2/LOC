
using LoanOffersCalculator.API.Data;
using LoanOffersCalculator.API.Helpers;
using LoanOffersCalculator.API.Model;
using MongoDB.Bson;
using Realms;
using Realms.Sync;

namespace LoanOffersCalculator.API.Services
{

    public class TodoService : ITodoService
    {
        public static Realms.Sync.App RealmApp;

        private Realm realm;
        private FlexibleSyncConfiguration config;
        public TodoService()
        {
            RealmApp = Realms.Sync.App.Create("application-0-stgmx");
            User user = RealmApp.LogInAsync(Credentials.EmailPassword("disha.rai@v2solutions.com", "Test@123456")).Result;
            if (RealmApp != null)
            {
                config = new FlexibleSyncConfiguration(user);
            }
        }
        public async Task AddTodo(ToDoModel model)
        {
            try
            {
                realm = Realm.GetInstance(config);
                Todo todo =
                    new Todo
                    {
                        Name = GeneralHelper.UppercaseFirst(model.Name),
                        Partition = RealmApp.CurrentUser.Id,
                        Owner = RealmApp.CurrentUser.Profile.Email
                    };
                await realm.WriteAsync(() =>
               {
                   realm.Add(todo);
               });

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw new Exception(msg);
            }
        }



        public List<ToDoModel> GetToDoList()
        {
            realm = Realm.GetInstance(config);

            var returnResponse = new List<ToDoModel>();
            try
            {
                var tlist = realm.All<Todo>().ToList().Reverse<Todo>().OrderBy(t => t.Completed);
                realm.Subscriptions.Update(() =>
                {
                    // Subscribe to all long running items, and name
                    // the subscription "longRunningItems"
                    var longRunningTasksQuery = realm.All<Todo>()
                        .Where(t => !t.Completed);
                    realm.Subscriptions.Add(longRunningTasksQuery,
                        new SubscriptionOptions() { Name = "longRunningItems" });
                });

                returnResponse = tlist.Select(x => new ToDoModel()
                {
                    //do your variable mapping here 
                    Id = x.Id.ToString(),
                    Name = x.Name,
                    Owner = x.Owner,
                    Partition = x.Partition,
                    Completed = x.Completed
                }).ToList();

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw new Exception(msg);
            }
            return returnResponse;

        }

        public async Task DeleteTodo(Todo foundTodo)
        {
            try
            {
                realm = Realm.GetInstance(config);
                await realm.WriteAsync(() =>
                 {
                     realm.Remove(foundTodo);
                 });
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw new Exception(msg);
            }
        }
        public bool UpdateTodo(ToDoModel model)
        {
            try
            {
                realm = Realm.GetInstance(config);
                realm.Write(() =>
                {
                    var foundTodo = realm.Find<Todo>(model.Id);
                    if (foundTodo != null)
                    {
                        foundTodo.Name = GeneralHelper.UppercaseFirst(model.Name);
                    }
                });
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return true;
        }

        public Todo GetTodoById(string id)
        {
            realm = Realm.GetInstance(config);
            return realm.Find<Todo>(ObjectId.Parse(id));
        }
    }
}
