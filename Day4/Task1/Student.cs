using Newtonsoft.Json;
public class Student
{
    public string? Name;
    public int Age;
    public readonly int RollNumber;
    public int Grade;

    public Student(string name, int age, int rollNumber, int grade)
    {
        Name = name;
        Age = age;
        RollNumber = rollNumber;
        Grade = grade;
    }
}


public class StudentList<T> where T : Student
{
    private List<T> Students;
    private string? jsonFilePath;
    public StudentList(string filePath)
    {
        Students = new List<T>();
        jsonFilePath = filePath;
    }
    public int Count => Students.Count;

    public void AddStudent(T student)
    {
        Students.Add(student);
    }

    public void DisplayAllStudents()
    {
        Console.WriteLine("All Students:");
        foreach (var student in Students)
        {
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine($"Name: {student.Name}, \nAge: {student.Age}, \nRoll Number: {student.RollNumber}, \nGrade: {student.Grade}");
            Console.WriteLine("-----------------------------------------------------------------------------");
        }
    }

    public IEnumerable<T>? Search(string? name, int? rollNumber)
    {
        if (!string.IsNullOrEmpty(name) || rollNumber != null)
        {
            return from Student in Students where Student.Name == name || Student.RollNumber == rollNumber select Student;
        }
        else
        {
            return null;
        }
    }

    public void SaveToJson()
    {
        try
        {
            // Read the existing JSON data from the file
            // Deserialize the existing data into a list of students
            // Combine the two list and write it back
            LoadFromJson();

            string jsonData = JsonConvert.SerializeObject(Students, Formatting.Indented);
            File.WriteAllText(jsonFilePath, jsonData);
            Console.WriteLine("Data saved to JSON file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving to the json file");
            Console.WriteLine(ex);

        }
    }

    public void LoadFromJson()
    {
        try
        {
            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);
                Students.AddRange(JsonConvert.DeserializeObject<List<T>>(jsonData));
                Console.WriteLine("Data loaded from JSON file.");

            }
            else
            {
                Console.WriteLine("JSON file not found. Initializing an empty list.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}