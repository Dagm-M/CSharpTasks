public class Task1
{
    public static void Main()
    {
        Console.Write("Enter your name: ");
        string studentName = Console.ReadLine();

        Console.Write("Enter the number of subjects you have taken: ");
        int numSubjects = int.Parse(Console.ReadLine());

        List<string> subjects = new List<string>();
        List<double> grades = new List<double>();


        for (int i = 1; i <= numSubjects; i++)
        {
            Console.Write($"Enter the name of subject {i}: ");
            string subjectName = Console.ReadLine();

            // Prompt the student to enter the grade and validate input
            double grade;
            do
            {
                Console.Write($"Enter your grade for {subjectName}: ");
            } while (!double.TryParse(Console.ReadLine(), out grade) || grade < 0 || grade > 100);

            subjects.Add(subjectName);
            grades.Add(grade);
        }

        double averageGrade = CalculateAverageGrade(grades);

        Console.WriteLine();
        Console.WriteLine($"Student Name: {studentName}");
        for (int i = 0; i < subjects.Count; i++)
        {
            Console.WriteLine($"{subjects[i]}: {ConvertGrade(grades[i])}");
        }
        Console.WriteLine($"Average Grade: {ConvertGrade(averageGrade)}");
    }

    // Method to calculate the average grade
    public static double CalculateAverageGrade(List<double> grades)
    {
        if (grades.Count == 0)
        {
            return 0;
        }

        double totalGrade = 0;
        foreach (double grade in grades)
        {
            totalGrade += grade;
        }

        return totalGrade / grades.Count;
    }


    public static string ConvertGrade(double points)
    {
        if (points >= 90.0)
            return "A+";
        else if (points >= 83.0)
            return "A";
        else if (points >= 70.0)
            return "B";
        else if (points >= 60.0)
            return "C";
        else if (points >= 50.0)
            return "D";
        else
            return "F";
    }
}