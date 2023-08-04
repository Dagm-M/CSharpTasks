public enum Tasks
{
    Personal,
    Work,
    Errand,
    Academic,
    Social,
    Financial,
    Development
}

class TaskHandler
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Tasks Category { get; set; }
    public bool IsCompleted { get; set; }
}

class TaskManager
{
    public List<TaskHandler> tasks;
    public TaskManager()
    {
        this.tasks = new List<TaskHandler>();
    }

    public void AddTask(string name, string description, Tasks category, bool isCompleted)
    {
        tasks.Add(
            new TaskHandler
            {
                Name = name,
                Description = description,
                Category = category,
                IsCompleted = isCompleted
            }
        );
    }
    public void AddTask(TaskHandler task)
    {
        tasks.Add(task);
    }

    public void DisplayTasks()
    {
        Console.WriteLine("-------------------------------");
        Console.WriteLine("All Tasks:");
        foreach (var task in tasks)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("TaskHandler: \nName - " + task.Name
            + "\nDescription - " + task.Description
            + "\nCategory - " + task.Category
            + "\nCompleted - " + task.IsCompleted);
            Console.WriteLine("---------------------------------");
        }
        Console.WriteLine("-------------------------------");
    }

    public void DisplayTasksByCategory(Tasks category)
    {
        var filteredTasks = tasks.FindAll(task => task.Category == category);

        Console.WriteLine($"Tasks in the '{category}' category:");
        foreach (var task in filteredTasks)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("TaskHandler: \nName - " + task.Name
            + "\nDescription - " + task.Description
            + "\nCategory - " + task.Category
            + "\nCompleted - " + task.IsCompleted);
            Console.WriteLine("---------------------------------");
        }
    }

    public void UpdateTasks(string name, string? description, Tasks? category, bool? isCompleted)
    {
        TaskHandler UpdatedTask = tasks.Find(t => t.Name == name);
        if (UpdatedTask != null)
        {
            UpdatedTask.Description = description ?? UpdatedTask.Description;
            UpdatedTask.Category = category ?? UpdatedTask.Category;
            UpdatedTask.IsCompleted = isCompleted ?? UpdatedTask.IsCompleted;
        }
    }


    public async Task SaveTasksToCsvAsync(string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                await writer.WriteLineAsync("Name,Description,Category,IsCompleted");

                foreach (var task in tasks)
                {
                    await writer.WriteLineAsync($"{task.Name},{task.Description},{task.Category},{task.IsCompleted}");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("An error has occured!");
            Console.WriteLine(e);
        }
    }

    public async Task LoadTasksFromCsvAsync()
    {
        string csvFilePath = "C:/Users/Dagm/Desktop/Tasks/Day3/Task1/tasks.csv";
        try
        {
            if (File.Exists(csvFilePath))
            {
                using (StreamReader reader = new StreamReader(csvFilePath))
                {
                    // Skip the header row
                    await reader.ReadLineAsync();

                    while (!reader.EndOfStream)
                    {
                        string line = await reader.ReadLineAsync();
                        string[] values = line.Split(',');

                        if (values.Length == 4 && Enum.TryParse<Tasks>(values[2], out Tasks category) && bool.TryParse(values[3], out bool isCompleted))
                        {
                            AddTask(values[0], values[1], category, isCompleted);
                        }
                    }
                }
            }
            DisplayTasks();
        }
        catch (Exception e)
        {
            Console.WriteLine("An error has occured!");
            Console.WriteLine(e);
        }
    }
}

class Program
{
    public static async Task Main()
    {
        TaskManager taskManager = new TaskManager();
        // Using object initializer to create and populate TaskHandler objects
        TaskHandler task1 = new TaskHandler
        {
            Name = "Buy groceries",
            Description = "Buy groceries for the week",
            Category = Tasks.Personal,
            IsCompleted = false
        };

        taskManager.AddTask(task1);

        TaskHandler task2 = new TaskHandler
        {
            Name = "Prepare presentation",
            Description = "Prepare slides for the upcoming presentation",
            Category = Tasks.Work,
            IsCompleted = true
        };
        taskManager.AddTask(task2);

        TaskHandler task3 = new TaskHandler
        {
            Name = "Pay utility bills",
            Category = Tasks.Financial,
            IsCompleted = false
        };
        taskManager.AddTask(task3);

        taskManager.AddTask("Print Document", "Print the papers for the manager", Tasks.Errand, true);
        await taskManager.LoadTasksFromCsvAsync();
    }
}