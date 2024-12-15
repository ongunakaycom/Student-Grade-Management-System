using System;
using System.Collections.Generic;

class StudentGradeManagementSystem
{
    static Dictionary<int, (string Name, List<int> Grades)> studentRecords = new();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- Student Grade Management System ---");
            Console.WriteLine("1. Add New Student");
            Console.WriteLine("2. Assign Grades");
            Console.WriteLine("3. Calculate Average Grade");
            Console.WriteLine("4. View All Students");
            Console.WriteLine("5. Remove Student");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    AssignGrades();
                    break;
                case 3:
                    CalculateAverage();
                    break;
                case 4:
                    ViewAllStudents();
                    break;
                case 5:
                    RemoveStudent();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("Enter Student ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine();
        studentRecords[id] = (name, new List<int>());
        Console.WriteLine("Student added successfully.");
    }

    static void AssignGrades()
    {
        Console.Write("Enter Student ID: ");
        int id = int.Parse(Console.ReadLine());
        if (studentRecords.ContainsKey(id))
        {
            Console.Write("Enter Grade (or -1 to stop): ");
            int grade;
            while ((grade = int.Parse(Console.ReadLine())) != -1)
            {
                studentRecords[id].Grades.Add(grade);
                Console.Write("Enter another grade (or -1 to stop): ");
            }
            Console.WriteLine("Grades added successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void CalculateAverage()
    {
        Console.Write("Enter Student ID: ");
        int id = int.Parse(Console.ReadLine());
        if (studentRecords.ContainsKey(id))
        {
            var grades = studentRecords[id].Grades;
            if (grades.Count > 0)
            {
                double average = grades.Average();
                Console.WriteLine($"Average Grade for {studentRecords[id].Name}: {average:F2}");
            }
            else
            {
                Console.WriteLine("No grades assigned yet.");
            }
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void ViewAllStudents()
    {
        Console.WriteLine("\n--- Student Records ---");
        foreach (var student in studentRecords)
        {
            Console.WriteLine($"ID: {student.Key}, Name: {student.Value.Name}, Grades: {string.Join(", ", student.Value.Grades)}");
        }
    }

    static void RemoveStudent()
    {
        Console.Write("Enter Student ID: ");
        int id = int.Parse(Console.ReadLine());
        if (studentRecords.Remove(id))
        {
            Console.WriteLine("Student removed successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
}
