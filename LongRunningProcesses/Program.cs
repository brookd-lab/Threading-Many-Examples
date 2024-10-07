using System.Diagnostics;

Stopwatch watch = new Stopwatch();
watch.Start();
EvenNumberSum();
OddNumberSum();
watch.Stop();
Console.WriteLine($"Total time without threading: {watch.ElapsedMilliseconds}");
/*********************/
watch.Reset();
watch.Start();
Thread t1 = new(EvenNumberSum);
Thread t2 = new(OddNumberSum);
t1.Start();
t2.Start();
t1.Join();
t2.Join();
watch.Stop();
Console.WriteLine($"Total time with threading: {watch.ElapsedMilliseconds}");

void EvenNumberSum()
{
    double sum = 0;
    for (double i =0; i < 5_000_000; i++)
    {
        if (i % 2 == 0)
            sum += i;
    }
    Console.WriteLine("Sum of even numbers = {0}", sum); 
}

void OddNumberSum()
{
    double sum = 0;
    for (double i = 0; i < 5_000_000; i++)
    {
        if (i % 2 == 1)
            sum += i;
    }
    Console.WriteLine("Sum of odd numbers = {0}", sum);
}
