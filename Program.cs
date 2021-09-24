using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RugbyBoy
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1: Add student \n2: Display students\n3:Exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        DisplayStudent();
                        break;
                    case "3":
                        flag = false;
                        break;

                }
            }
            Console.ReadKey();

        }

        private static void AddStudent()
        {
            string name, address;
            int age, birthYear, birthMonth, birthDay;

            name = GetStringFromConsole("Enter student name: ");
            address = GetStringFromConsole("Enter student address: ");
            birthMonth = GetIntFromConsole("Enter birth month: ");
            birthDay = GetIntFromConsole("Enter birth day: ");
            birthYear = GetIntFromConsole("Enter birth year: ");



            DateTime birthDateStudent = new DateTime(birthYear, birthMonth, birthDay);
            DateTime currentDateTime = DateTime.Now;

            age = currentDateTime.Year - birthDateStudent.Year;

            List<Student> students = new List<Student>();

            students.Add(new Student
            {
                Name = name,
                Address = address,
                Age = age
            });

            using (StreamWriter wr = new StreamWriter("student1.txt"))
            {
                foreach (var student in students)
                {
                    wr.WriteLine($"{student.Name}, {student.Address}, {student.Age}");
                }
            }

            using (StreamReader rd = new StreamReader("student1.txt"))
            {
                string line = rd.ReadLine();


                while (line != null)
                {
                    string[] student = line.Split(',');

                    students.Add(new Student
                    {
                        Name = student[0],
                        Address = student[1],
                        Age = int.Parse(student[2])
                    });

                    line = rd.ReadLine();

                }
            }
        }

        private static void DisplayStudent()
        {
            List<Student> students = new List<Student>();

            using (StreamReader rd = new StreamReader("student1.txt"))
            {
                string line = rd.ReadLine();
                while (line != null)
                {
                    string[] student = line.Split(',');

                    students.Add(new Student
                    {
                        Name = student[0],
                        Address = student[1],
                        Age = int.Parse(student[2])
                    });

                    line = rd.ReadLine();
                }
            }

            foreach (var student in students)
            {
                Console.WriteLine("Student name : {0} Address : {1} Age: {2}", student.Name, student.Address,
                    student.Age);
            }
        }

        private static string GetStringFromConsole(string message)
        {
            string output = "";

            while (string.IsNullOrWhiteSpace(output))
            {
                Console.Write(message);
                output = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(output))
                {
                    Console.WriteLine("Please enter a text.");
                }
            }

            return output;
        }

        private static int GetIntFromConsole(string message)
        {
            string text = "";
            int output;
            bool isValidOutput = int.TryParse(text, out output);

            while (!isValidOutput)
            {
                text = GetStringFromConsole(message);
                isValidOutput = int.TryParse(text, out output);
                if (!isValidOutput)
                {
                    Console.WriteLine("Please enter a digit.");
                }
            }

            return output;
        }
    }
    public class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    }
}