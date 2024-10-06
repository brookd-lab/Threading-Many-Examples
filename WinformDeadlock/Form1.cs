using Microsoft.AspNetCore.Components;
using System.Drawing.Text;
using static System.Net.Mime.MediaTypeNames;

namespace WinformDeadlock
{
    public partial class Form1 : Form
    {
        private readonly object locker = new object();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //var thread2 = new Thread(() => WriteTextUnsafe("Hello"));
            var thread2 = new Thread(() =>
            {
                Invoke(new Action(() =>
                {
                    Thread.Sleep(1000);
                    tbTest.Text = $"This text was set safely.";
                }));
            });
            thread2.Start();
            thread2.Join(200);
        }

        private void WriteTextUnsafe(string text)
        {   
            Invoke(new Action(() =>
            {
                Thread.Sleep(1000);
                tbTest.Text = $"This text: {text} was set safely.";
            }));
        }
    }
}
