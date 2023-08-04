using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Console.Clear();
        string jsonFilePath = "C:/Users/Dagm/Desktop/Tasks/Day4/Task1/Data.json";
        StudentList<Student> studentList = new StudentList<Student>(jsonFilePath);

        while (true)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Add a student");
            Console.WriteLine("2. View all students");
            Console.WriteLine("3. Save students to JSON");
            Console.WriteLine("4. Load students from JSON");
            Console.WriteLine("5. Exit");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Write("Enter student name:  ");
                    string? name = Console.ReadLine();

                    Console.Write("Enter student age:   ");
                    int age = int.Parse(Console.ReadLine());

                    Console.Write("Enter student roll number:   ");
                    int rollNumber = int.Parse(Console.ReadLine());

                    Console.Write("Enter student grade:    ");
                    int grade = int.Parse(Console.ReadLine());

                    Student newStudent = new Student(name, age, rollNumber, grade);
                    studentList.AddStudent(newStudent);
                    Console.Write("Student added successfully!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;

                case 2:
                    if (studentList.Count > 0)
                    {
                        studentList.DisplayAllStudents();
                    }
                    else
                    {
                        Console.WriteLine("No students in the list to display.");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }

                    break;

                case 3:
                    studentList.SaveToJson();
                    break;

                case 4:
                    studentList.LoadFromJson();
                    break;

                case 5:
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please select a valid option (1-6).");
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
            }
        }
    }
}