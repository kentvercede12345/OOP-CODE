using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;


namespace OOP_CODE
{
    class Program
    {

        static void Main(string[] args)
        {
             using (StreamWriter wr = new StreamWriter("student.text")) 
            {

                wr.WriteLine("Kent Vercede,  Pagadian City");
                wr.WriteLine("Nicko M. Balboa,  Pagadian City");

            }

            //Readline
            using (StreamReader rd = new StreamReader("student.text")) 
            {
                var line = rd.ReadLine();

                while (line != null)
                {
                    //Kent Vercede, Pagadian City
                    string[] student = line.Split(','); //Kent Vercede, Pagadian City [0], Pagadian [1]
                    Console.WriteLine(string.Format("student name: {0}\nAddress: {1}", student[0], student[1]));
                    line = rd.ReadLine();
                }
            }

            Console.ReadKey();
        }
    }
}

