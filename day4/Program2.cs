// class Program2
// {

//     static void Main()
//     {
//         // shared one
//         string a = "Srivalli"; // using literal // get stored in a string pool
//         string e = "Srivalli";
//          Console.WriteLine(object.ReferenceEquals(a, e));
//         // it's not the shared one
//         string b = new string("Srivalli"); //using constructor // It's treating as a new string object 
//         string d = new string("Srivalli");
//         Console.WriteLine(object.ReferenceEquals(b, d));
//         Console.WriteLine("The value of B is :" + b);
//         Console.WriteLine(a == b); // It's checking the value .Equals
//         Console.WriteLine(a.GetHashCode());
//         Console.WriteLine(b.GetHashCode());
//         Console.WriteLine(object.ReferenceEquals(a, b)); // false 

//         //  string c = b;
//         //  Console.WriteLine(c.GetHashCode());
//         //  strings literals are interned
//         string c = string.Intern(b);
//         Console.WriteLine(c.GetHashCode());
//         //Console.WriteLine(c);
//         Console.WriteLine(object.ReferenceEquals(a, c)); // true
//         // throughout the execution the hash codes will be consistent
//         Console.WriteLine(StringComparer.Ordinal.GetHashCode(a));
//          Console.WriteLine(StringComparer.Ordinal.GetHashCode(c));
//     }


// }
