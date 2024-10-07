var employees = new List<Employee> {
    new Employee() { Id =1, Name="Jake"},
    new Employee() { Id =2, Name="Sam"},
    new Employee() { Id =3, Name="Mike"}
};

Employee employee = employees.Where(e => e.Id == 2).Select(s => s).FirstOrDefault()!;
Console.WriteLine($"{employee.Id}, {employee.Name}");

Predicate<int> odd = e => e % 2 == 1;
var evenIdEmployees = employees.Where(e => odd(e.Id)).ToList();
Func<int, bool> odd1 = e => e % 2 == 1;
var oddIdEmployees = employees.Where(e => odd1(e.Id)).ToList();

var e1 = employees.Find(e => e.Id == 2);
var e2 = employees.Find(e => FindEmployee(e));
Predicate<Employee> p1 = e => e.Id == 3;
Func<Employee, bool> p2 = e => e.Id == 3;
var e3 = employees.Find(p1);
var e4 = employees.Find(e => p2(e));

var e5 = employees.Find(delegate (Employee x) { return x.Id == 3; });
var e6 = employees.Find(x => x.Id == 3);

Console.WriteLine();

bool FindEmployee(Employee emp)
{
    return emp.Id == 3;
}

Console.WriteLine();

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
}


//var d = delegate (string text) { Console.WriteLine(text); };
//var e = new Action<string>(text => Console.WriteLine(text));
//var f = delegate (string text) { Print(text); };
//var g = new Action<string>(text => Print(text));
//f("hello");
//g("hello");


//void Print(string text)
//{
//    Console.WriteLine(text);
//}