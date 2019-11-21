using System;
using System.Collections.Generic;

namespace Util
{
    enum School
    {
        Hogwarts,
        Harvard,
        MIT
    }
    class Program
    {
        static List<Student> students = new List<Student>();
        static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome to School Tracker!");

            var adding = true;

            while (adding)
            {
                try
                {
                    var newStudent = new Student
                    {
                        Name = Util.Console.Ask("Student Name: "),
                        Grade = Util.Console.AskInt("Student Grade: "),
                        School = (School)Util.Console.AskInt("Student School: "),
                        Birthday = Util.Console.Ask("Student Birthday: "),
                        Address = Util.Console.Ask("Student Address: "),
                        Phone = Util.Console.AskInt("Student Phone Number: ")
                    };

                    students.Add(newStudent);
                    Student.Count++;
                    System.Console.WriteLine("Student Count: {0}", Student.Count);
                    System.Console.WriteLine("Add another? y/n");

                    if (System.Console.ReadLine() != "y")
                        adding = false;
                }
                catch (Exception)
                {
                    System.Console.WriteLine("Error adding student, Please try again");
                }
            }

            foreach (var student in students)
            {
                System.Console.WriteLine("Name: {0}, Grade: {1},", student.Name, student.Grade);
            }
            Exports();
        }

        private static void Import()
        {
            var importedStudent = new Student("Jenny", 86, "May", "123 Hello Blvd.", 2865432);
            System.Console.WriteLine(importedStudent.Name);
        }

        static void Exports()
        {
            foreach (var student in students)
            {
                switch(student.School)
                {
                    case School.Hogwarts:
                        System.Console.WriteLine("Exporting to Hogwarts");
                        break;
                    case School.Harvard:
                        System.Console.WriteLine("Exporting to Harvard");
                        break;
                    case School.MIT:
                        System.Console.WriteLine("Exporting to MIT");
                        break;
                }
            }
        }
        class Member
        {
            public string Name;
            public string Address;
            protected int phone;

            public int Phone
            {
                set { phone = value; }
            }
        }
        class Student : Member
        {
            static public int Count = 0;

            public int Grade;
            public string Birthday;
            public School School;

            public Student()
            {

            }
            public Student(string name, int grade, string birthday, string address, int phone)
            {
                Name = name;
                Grade = grade;
                Birthday = birthday;
                Address = address;
                Phone = phone;
            }
        }
        class Teacher : Member
        {
            public string Subject;
        }
    }
}
