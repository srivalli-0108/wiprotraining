using System;

class Employee
{

    public string Name { get; set; }
    public int Age { get; set; }

    public static int Count=0;
    public Employee()
    {
        Count++;
         Console.WriteLine("The value of count is : " + Count);
        Name = "Sai";
        Age = 21;
    }
    public Employee(string name, int age)
    {

        Name = name;
        Age = age;

    }

    public Employee(string name)
    {

        Name = name;


    }

    public void Display()
    {

        Console.WriteLine("Name : " + Name + "Age : " + Age);
    }
 
    }

class Program
{


    static void Main()
    {

        Employee e1 = new Employee();
        Employee e2 = new Employee();
        Employee e3 = new Employee();

        e1.Display();
        e2.Display();
        e3.Display();
    }
}
