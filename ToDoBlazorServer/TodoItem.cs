namespace ToDoBlazorServer
{
    public class TodoItem
    {
        public string Text { get; set; }
        public bool Completed { get; set; }

        public TodoItem(string text)
        {
            Text = text;
        }
    }
}
