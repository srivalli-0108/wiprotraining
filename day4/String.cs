// class StringPrograms
//  {
//     static void Main()
//     {
//       string text = "CSharp_Language_invented_in _2002";

//       int length = text.Length; 
//       Console.WriteLine("The Length of a string : " + length);
//       string subString = text.Substring(7, 8);
//       Console.WriteLine("The text from a string : " + subString);
//       Console.WriteLine(text.IndexOf("harp"));
//       Console.WriteLine(text.ToUpper());
//       string newString = text.Replace("CSharp", "Java");
//       Console.WriteLine(newString);

//       String replaced = text.Replace(" ", "");
//       Console.WriteLine("Without space : " + replaced.Length);

//       int pos = text.IndexOf("Language");
//       string newText = text.Substring(pos, 8);
//       Console.WriteLine("New Text Value " + newText);
//       string data = "CSharp,Language";
//       String[] lang = data.Split(',');
//         foreach (string valuess in lang)
//         {
          
//          }
//       string[] lang1 = text.Split(' ');
//       Console.WriteLine("The blank spaces in the text : " + (lang1.Length));

//       string[] lang2 = text.Split('_');
//       Console.WriteLine("The special characters in the text : " + (lang2.Length));
        
//       string[] lang3 = text.Split(' ');
//       Console.WriteLine("The number of words in the text : " + (lang3.Length));


//     }
//  }