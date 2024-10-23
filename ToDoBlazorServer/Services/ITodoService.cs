namespace ToDoBlazorServer.Services
{
    public interface ITodoService
    {
        public IEnumerable<TodoItem> GetAll();
        public void Add(TodoItem item);
        public void Delete (TodoItem item);
        public void Complete(TodoItem item);
        public void Uncomplete(TodoItem item);
    }
}
