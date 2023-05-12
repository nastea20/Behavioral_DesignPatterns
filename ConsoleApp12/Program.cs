using System;
using System.Collections.Generic;

interface ICommand
{
    void Execute();
    void Undo();
}

class ChangeStatusCommand : ICommand
{
    private Task task;
    private string newStatus;
    private string oldStatus;

    public ChangeStatusCommand(Task task, string newStatus)
    {
        this.task = task;
        this.newStatus = newStatus;
    }

    public void Execute()
    {
        oldStatus = task.Status;
        task.ChangeStatus(newStatus);
    }

    public void Undo()
    {
        task.ChangeStatus(oldStatus);
    }
}

interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

interface IObserver
{
    void Update(ISubject subject);
}

class Task : ISubject
{
    private string name;
    private List<string> comments = new List<string>();
    private string status = "In Progress";
    private List<IObserver> observers = new List<IObserver>();

    public Task(string name)
    {
        this.name = name;
    }

    public void AddComment(string comment)
    {
        comments.Add(comment);
    }

    public void ChangeStatus(string status)
    {
        this.status = status;
        Notify();
    }

    public void DisplayComments()
    {
        foreach (string comment in comments)
        {
            Console.WriteLine(comment);
        }
    }

    public void DisplayStatus()
    {
        Console.WriteLine(status);
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (IObserver observer in observers)
        {
            observer.Update(this);
        }
    }

    public string Name { get { return name; } }
    public string Status { get { return status; } }
}

class TaskManager
{
    private List<ICommand> commands = new List<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        commands.Add(command);
    }

    public void UndoLastCommand()
    {
        ICommand command = commands[commands.Count - 1];
        command.Undo();
        commands.Remove(command);
    }
}

class User : IObserver
{
    private string name;

    public User(string name)
    {
        this.name = name;
    }

    public void Update(ISubject subject)
    {
        Task task = subject as Task;
        Console.WriteLine("User {0} has been notified that the task \"{1}\" has been updated to status \"{2}\"", name, task.Name, task.Status);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Task task = new Task("Implement Command and Observer Patterns");
        TaskManager taskManager = new TaskManager();

        User user1 = new User("Alice");
        User user2 = new User("Bob");

        task.Attach(user1);
        task.Attach(user2);

        ICommand changeStatusCommand = new ChangeStatusCommand(task, "Completed");
        taskManager.ExecuteCommand(changeStatusCommand);

        Console.WriteLine("Task status is now: " + task.Status);

        taskManager.UndoLastCommand();

        Console.WriteLine("Task status after undo is: " + task.Status);

        Console.ReadLine();
    }
}
