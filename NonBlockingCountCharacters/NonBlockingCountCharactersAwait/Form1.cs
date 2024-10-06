namespace NonBlockingCountCharacters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int GetCountFromFile()
        {
            using (var stream = new StreamReader(@"c:\temp\file.txt"))
            {
                var data = stream.ReadToEnd();
                var count = data.Length;
                Thread.Sleep(5000);
                return count;
            }
        }


        private async void btnGetCount_Click(object sender, EventArgs e)
        {
            Task<int> task = new(GetCountFromFile);
            task.Start();

            lblMessage.Text = "Starting to get the count";
            int count = await task;
            lblMessage.Text = $"There are {count} characters in the file.";
        }
    }
}
