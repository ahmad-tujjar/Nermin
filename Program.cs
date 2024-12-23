using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMG
{
    class Student
    {
        public int Number {  get; set; }
        public string Name { get; set; }
        public int TestOneMarke {  get; set; }
        public int TestTwoMarke { get;set; }
        public int TotalMarks { get; set; }
        public string Status { get; set; }

        public int sumMarks()
        {
            int marke;
            int testOne =this.TestOneMarke;
            int testTwo =this.TestTwoMarke;
            marke = testOne + testTwo;
            return marke;
        }
        public void setStatus()
        {
            if (this.TotalMarks <= 50)
            {
                this.Status = "Failed";
            }else if (this.TotalMarks <= 70 && this.TotalMarks>=50)
            {
                this.Status = "Good";
            }else if(this.TotalMarks <=90 && this.TotalMarks >= 70)
            {
                this.Status = "Very Good";
            }
            else if (this.TotalMarks <=100 && this.TotalMarks >= 90)
            {
                this.Status = "Excellent";
            }
        }

        static void sortData(List<Student> students, int n)
        {
           
            if (n == 1)
                return;

            
            for (int i = 0; i < n - 1; i++)
            {
                if (students[i].TotalMarks > students[i + 1].TotalMarks)
                {
              
                    Student temp = students[i];
                    students[i] = students[i + 1];
                    students[i + 1] = temp;
                }
            }

         
            sortData(students, n - 1);
        }

        public static void PrintStudents(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Student is empty");
                return;
            }

            Console.WriteLine("\nStudent List:");
            foreach (var student in students)
            {
                Console.WriteLine($"Number: {student.Number}, Name: {student.Name}, Total: {student.TotalMarks}, Status: {student.Status}");
            }
        }
       
         public static void AddStudent(List<Student> students)
        {
            Console.Write("Enter Number of Student: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("enter Name of Student: ");
            string name = Console.ReadLine();

            int testOneMark;
            while (true)
            {
                Console.Write("Enter the score of the first test: (0-50): ");
                testOneMark = int.Parse(Console.ReadLine());
                if (testOneMark >= 0 && testOneMark <= 50)
                    break;
                Console.WriteLine("The degree is incorrect. It must be between 0 and 50.");
            }

            int testTwoMark;
            while (true)
            {
                Console.Write("Enter the score of the secind test: (0-50): ");
                testTwoMark = int.Parse(Console.ReadLine());
                if (testTwoMark >= 0 && testTwoMark <= 50)
                    break;
                Console.WriteLine("The degree is incorrect. It must be between 0 and 50.");
            }

            Student newStudent = new Student
            {
                Number = number,
                Name = name,
                TestOneMarke = testOneMark,
                TestTwoMarke = testTwoMark
            };

            newStudent.TotalMarks = newStudent.sumMarks();
            newStudent.setStatus();

            students.Add(newStudent);

            // ترتيب الطلاب بعد الإضافة
            Student.sortData(students, students.Count);

            Console.WriteLine("Adeed.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                Console.WriteLine("\nChose Form List:");
                Console.WriteLine("1 - Add Student");
                Console.WriteLine("2 - Print Studint LIst");
                Console.WriteLine("3 - Exit");
                Console.Write("Chose: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                       Student.AddStudent(students);
                        break;
                    case "2":
                       Student.PrintStudents(students);
                        break;
                    case "3":
                        Console.WriteLine("Applcition End.");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}

