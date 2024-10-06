Console.WriteLine("Main starting\n");

var t1 = new Thread(DoWork1);
t1.Start();

var t2 = new Thread(DoWork2);
t2.Start();

//if (t2.Join(3500))
//{
//    Console.WriteLine("Done work 2");
//}
//else
//{
//    Console.WriteLine("W2 has not completed in the specified time");
//}

t2.Join(1000);
Console.WriteLine("Done work 2");

for (int i = 0; i < 10; i++)
{
    if (t1.IsAlive)
    {
        Console.WriteLine("W1 still doing work");
        Thread.Sleep(500);
    }
    else
    {
        Console.WriteLine("done Work 1");
        break;
    }
}

//while (t1.IsAlive)
//{   
//        Console.WriteLine("W1 still doing work");
//        Thread.Sleep(500);
//}
//if (t1.IsAlive == false)
//    Console.WriteLine("W1 has completed work");

Console.WriteLine("\nMain ending");


void DoWork1()
{
    Console.WriteLine("Doing work 1");
    Thread.Sleep(3000);
}

void DoWork2()
{
    Console.WriteLine("Doing work 2");
    Thread.Sleep(5000);
}