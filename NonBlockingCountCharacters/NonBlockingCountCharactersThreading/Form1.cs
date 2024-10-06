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
            int count;

            using (var stream = new StreamReader(@"c:\temp\file.txt"))
            {
                var data = stream.ReadToEnd();
                count = data.Length;
                Thread.Sleep(5000);
            }
            return count;

        }


        private void btnGetCount_Click(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                lblMessage.Text = "Processing file. Please wait...";
            }));
           
            Thread t = new Thread(() => {
                var count = GetCountFromFile();
                Invoke(new Action(() =>
                {
                    lblMessage.Text = $"There are {count} characters in the file.";
                }));
            });
            t.Start();

            
        }
    }
}
