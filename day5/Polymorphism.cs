
// using System;

// namespace oops.poly
// {

//     class InfoPrinter
//     {
//         public int Pages;
//         InfoPrinter()
//         {

//             Console.WriteLine("Constructor Called");
//         }

//         InfoPrinter(int Pagess)
//         {
//             this.Pages = Pagess;
//             this.Pages = this.Pages + 1;
//             Console.WriteLine("Total Pages Printed :" + this.Pages);
//         }
//         public void Print(string name, int empId)
//         {
//             Console.WriteLine("Name :" + name + " EmpId :" + empId);
//         }

//         public void Print(int empId, string name)
//         {
//             Console.WriteLine("Name :" + name + " EmpId :" + empId);
//         }

//         static void Main()
//         {
//             InfoPrinter InfPrinter = new InfoPrinter();
//             InfPrinter.Print("Sai", 100); // At compile time
//             InfPrinter.Print(1002, "Seetha");
//             InfoPrinter InfPrinter1 = new InfoPrinter(23);
//             InfoPrinter InfPrinter2 = new InfoPrinter(12);


//         }

//     }

// }


