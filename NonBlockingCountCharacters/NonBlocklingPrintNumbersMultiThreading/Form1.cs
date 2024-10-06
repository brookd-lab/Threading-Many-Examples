using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Logging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace NonBlocklingPrintNumbersMultiThreading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDoTme_Click(object sender, EventArgs e)
        {
            //Task t = new(TimeConsumingWork);
            //t.Start();
            //await t;
            Thread t = new Thread(TimeConsumingWork);
            t.Start();
        }

        private void btnPrintNumbers_Click(object sender, EventArgs e)
        {
            //Task t = new Task(() => PrintNumbers());
            //t.Start();
            //await t;

            //Thread t = new Thread(PrintNumbers);
            //t.Start();

            //Thread t = new Thread(() => { PrintNumbers(50); });
            //t.Start();

            //Task t2 = new Task(() => PrintNumbers(50));
            //t2.Start();

            //Thread t1 = new Thread((PrintNumbers!));
            //t1.Start(10);

            //var n = new Number(30);
            //Thread t2 = new Thread(n.PrintNumbers);
            //t2.Start();

            //Thread t3 = new Thread(() => PrintNumbers(30));
            //t3.Start();

            //Task t = new Task(() => PrintNumbers(15));
            //t.Start();
            //await t;
            //if (t.IsCompletedSuccessfully)
            //    MessageBox.Show("I finished!");
        }

        private void TimeConsumingWork()
        {
            if (IsHandleCreated)
            {
                Invoke(new Action(() =>
                {
                    lblTime.Text = "Beginning Time Consuming Work...";
                }));
            }

            Thread.Sleep(5000);

            if (IsHandleCreated)
            {
                Invoke(new Action(() =>
                {
                    lblTime.Text = "Time Consuming Work Completed.";
                }));
            }

        }

        private void PrintNumbers(int target)
        {
            if (IsHandleCreated)
            {
                Invoke(new Action(() =>
                {
                    lbNumbers.Items.Clear();

                    //if (int.TryParse(end.ToString(), out int num))
                    //{
                        for (int i = 0; i <= target; i++)
                        {
                            lbNumbers.Items.Add(i);
                        }
                    //}
                }
                ));
            }
        }
    }

    class Number : Form
    {
        private readonly int _end;
        public Number(int end)
        {
            _end = end;
        }

        public void PrintNumbers()
        {
           for (var i = 0; i <= _end; i++)
            {

            }
        }

    }
}
