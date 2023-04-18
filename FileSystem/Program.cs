using System;
using System.Collections.Generic;

public class FileSystemNode
{
    public string Name { get; set; }
    public bool IsDirectory { get; set; }
    public List<FileSystemNode> Children { get; set; }

    public FileSystemNode(string name, bool isDirectory)
    {
        Name = name;
        IsDirectory = isDirectory;
        Children = new List<FileSystemNode>();
    }

    public void AddChild(FileSystemNode child)
    {
        Children.Add(child);
    }

    public bool RemoveChild(FileSystemNode child)
    {
        return Children.Remove(child);
    }

    public FileSystemNode Find(string name)
    {
        if (Name == name)
        {
            return this;
        }

        foreach (var child in Children)
        {
            var result = child.Find(name);
            if (result != null)
            {
                return result;
            }
        }

        return null;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        // Create root directory
        var root = new FileSystemNode("E:\\", true);

        // Add subdirectories
        var programFiles = new FileSystemNode("Program Files", true);
        var users = new FileSystemNode("Users", true);
        root.AddChild(programFiles);
        root.AddChild(users);

        // Add files
        var readme = new FileSystemNode("readme.txt", false);
        var license = new FileSystemNode("license.txt", false);
        programFiles.AddChild(readme);
        programFiles.AddChild(license);

        // Find a node
        var result = root.Find("readme.txt");
        if (result != null)
        {
            Console.WriteLine("Found: " + result.Name);
        }
        else
        {
            Console.WriteLine("Not found.");
        }

        // Remove a node
        programFiles.RemoveChild(readme);

        // Print directory structure
        PrintDirectoryStructure(root);
    }

    static void PrintDirectoryStructure(FileSystemNode node, string indent = "")
    {
        Console.WriteLine(indent + node.Name);
        indent += "  ";
        foreach (var child in node.Children)
        {
            PrintDirectoryStructure(child, indent);
        }
    }
}
