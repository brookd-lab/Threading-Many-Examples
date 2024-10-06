using System.Diagnostics;

object locker = new object();
int total = 0;

for (int i = 1; i <= 100; i++)
{
    var stopWatch = new Stopwatch();
    stopWatch.Start();
    total = 0;

    var t1 = new Thread(() => AddTen(10_000_000!));
    var t2 = new Thread(() => AddTen(10_000_000!));
    var t3 = new Thread(() => AddTen(10_000_000!));
    t1.Start();
    t2.Start();
    t3.Start();
    t1.Join();
    t2.Join();
    t3.Join();


    //AddTen();
    //AddTen();
    //AddTen();

    Console.WriteLine("Total is: {0}", total);
    stopWatch.Stop();
    Console.WriteLine("Time: {0}", stopWatch.Elapsed.Milliseconds);
}

void AddTen(int value)
{
    lock (locker)
    //Monitor.Enter(locker);
    {
        //try
        //{
        for (int i = 1; i <= value; i++)
        {
            //Interlocked.Increment(ref total);
            total++;

        }
        //}
        //finally
        //{
        //    Monitor.Exit(locker);
        //}
    }
}


