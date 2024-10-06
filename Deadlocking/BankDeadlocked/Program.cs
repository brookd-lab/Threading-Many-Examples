// Before: (with deadlock)
using System.Numerics;

Console.WriteLine(Environment.ProcessorCount);

TransferManager manager = new TransferManager();

Account checking = new(101, "checking");
Account saving = new(102, "saving");

manager.DoDoubleTransfer(checking, saving);

class Account
{
    private readonly int _id;
    private readonly string _name;

    public int Id { get { return _id; } }
    public string Name { get { return _name; } }
    public int Total { get; set; } = 0;
    public Account(int id, string name)
    {
        _id = id;
        _name = name;
    }

}

class TransferManager
{
    private object lock1 = new object();
    private object lock2 = new object();
    public void DoDoubleTransfer(Account acc1, Account acc2)
    {
        Console.WriteLine("Starting...");
        var task1 = new Task(() => Transfer(acc1, acc2, 500));
        var task2 = new Task(() => Transfer(acc2, acc1, 600));
        task1.Start();
        task2.Start();
        task1.Wait();
        task2.Wait();
        //Task.WaitAll(task1, task2);
        Console.WriteLine("Finished...");
    }

    private void Transfer(Account acc1, Account acc2, int sum)
    {
        object lock1 = acc1, lock2 = acc2;
        if (acc1.Id > acc2.Id)
        {
            lock1 = acc2; lock2 = acc1;
        }
        lock (lock1)
        {
            Thread.Sleep(1000);
            lock (lock2)
            {
                acc2.Total += sum;
                Console.WriteLine($"Finished transfering sum {sum} to account {acc2.Name}");
            }
        }
    }
}

//var lock1 = new object();
//var lock2 = new object();

//Console.WriteLine("Starting"); 
//var task1 = new Task(DoSomething1);
//var task2 = new Task(DoSomething2);
//task1.Start();
//task2.Start();
//Task.WaitAll(task1, task2);
//Console.WriteLine("Finished");

//void DoSomething1()
//{
//    lock(lock1)
//    {
//        Thread.Sleep(1000);
//        lock(lock2)
//        {
//            Console.WriteLine("Finished thread 1");
//        }
//    }
//}

//void DoSomething2()
//{
//    lock (lock2)
//    {
//        Thread.Sleep(1000);
//        lock (lock1)
//        {
//            Console.WriteLine("Finished thread 2");
//        }
//    }
//}