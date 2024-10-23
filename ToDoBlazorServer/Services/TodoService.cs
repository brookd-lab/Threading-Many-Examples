
namespace ToDoBlazorServer.Services
{
    public class TodoService : ITodoService
    {
        private readonly List<TodoItem> _todoItems;

        public TodoService()
        {
            _todoItems = new();
            _todoItems.Add(new("Wash Clothes"));
            _todoItems.Add(new("Clean Desk"));
        }
        public IEnumerable<TodoItem> GetAll()
        {
            return _todoItems;
        }

        public void Add(TodoItem item)
        {
            _todoItems.Add(item);
        }

        public void Delete(TodoItem item)
        {
            _todoItems.Remove(item);
        }

        public void Complete(TodoItem item)
        {
            item.Completed = true;
        }

        public void Uncomplete(TodoItem item)
        {
            item.Completed = false;
        }

    }
}
