using System;
using System.Collections.Generic;

class StudentGradeManagementSystem
{
    // Define a class to store student information
    public class Student
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public List<int> Grades { get; set; }

        public Student(string name, string id)
        {
            Name = name;
            ID = id;
            Grades = new List<int>();
        }

        // Method to calculate average grade
        public double CalculateAverage()
        {
            if (Grades.Count == 0)
                return 0;
            int total = 0;
            foreach (int grade in Grades)
            {
                total += grade;
            }
            return total / (double)Grades.Count;
        }
    }

    // List to store all students
    static List<Student> students = new List<Student>();

    // Main method to run the program
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            // Display the menu options
            Console.WriteLine("Student Grade Management System");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Assign Grades");
            Console.WriteLine("3. Calculate Average Grade");
            Console.WriteLine("4. View All Students");
            Console.WriteLine("5. Remove Student");
            Console.WriteLine("6. Exit");
            Console.Write("Please select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    AssignGrades();
                    break;
                case "3":
                    CalculateAverage();
                    break;
                case "4":
                    ViewAllStudents();
                    break;
                case "5":
                    RemoveStudent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    // Method to add a student
    static void AddStudent()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();
        Console.Write("Enter student ID: ");
        string id = Console.ReadLine();
        students.Add(new Student(name, id));
        Console.WriteLine("Student added successfully.");
    }

    // Method to assign grades to a student
    static void AssignGrades()
    {
        Console.Write("Enter student ID to assign grades: ");
        string id = Console.ReadLine();
        Student student = FindStudentByID(id);
        if (student != null)
        {
            Console.Write("Enter grade (0 to stop): ");
            int grade;
            while (int.TryParse(Console.ReadLine(), out grade) && grade >= 0)
            {
                student.Grades.Add(grade);
                Console.Write("Enter grade (0 to stop): ");
            }
            Console.WriteLine("Grades assigned successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    // Method to calculate and display a student's average grade
    static void CalculateAverage()
    {
        Console.Write("Enter student ID to calculate average: ");
        string id = Console.ReadLine();
        Student student = FindStudentByID(id);
        if (student != null)
        {
            double average = student.CalculateAverage();
            Console.WriteLine($"Student {student.Name} ({student.ID}) has an average grade of {average:F2}.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    // Method to view all students
    static void ViewAllStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students to display.");
        }
        else
        {
            Console.WriteLine("Student List:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name} ({student.ID})");
                Console.WriteLine("Grades: " + string.Join(", ", student.Grades));
                Console.WriteLine($"Average: {student.CalculateAverage():F2}");
            }
        }
    }

    // Method to remove a student
    static void RemoveStudent()
    {
        Console.Write("Enter student ID to remove: ");
        string id = Console.ReadLine();
        Student student = FindStudentByID(id);
        if (student != null)
        {
            students.Remove(student);
            Console.WriteLine("Student removed successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    // Helper method to find a student by ID
    static Student FindStudentByID(string id)
    {
        foreach (var student in students)
        {
            if (student.ID == id)
            {
                return student;
            }
        }
        return null;
    }
}
