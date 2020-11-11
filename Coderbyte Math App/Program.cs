﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using Coderbyte_Math_App.Classes;
using Coderbyte_Math_App.Interfaces;
using Json.Net;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace Coderbyte_Math_App
{
    class Program
    {
        static void Main(string[] args)
        {
            //ShapeCollection collection = new ShapeCollection("mock");

            List<IShape> shapes = new List<IShape>();
            IShape shape;
            var filesDir = new DirectoryInfo($@"{Directory.GetCurrentDirectory()}\\Files\\");
            FileInfo[] files = filesDir.GetFiles("*.json");
            string fileName = "";
            string fileString = "";
            string input = "";
            bool initialLoadLoop = true;

            // Uncomment the line below to fill the shapes collection with mock data. Useful to test files.
            MockShapeCollection(shapes);

            Console.WriteLine("Welcome to the Coderbyte Math App!");
            
            while (input != "0")
            {
                while (initialLoadLoop)
                {

                    if (files.Length > 0)
                    {
                        Console.WriteLine("It looks like there are some saved files. Would you like to open one? (Y/N)");

                        input = Console.ReadLine();

                        switch (input)
                        {
                            case "Y":
                            case "y":
                                #region load file
                                Console.WriteLine("Which file would you like to load?");

                                for (int i = 0; i < files.Length; i++)
                                {
                                    Console.WriteLine($@"{i}. {files[i].Name}");
                                }

                                input = Console.ReadLine();
                                try
                                {
                                    if (Convert.ToInt32(input) < files.Length)
                                    {
                                        fileName = files[Convert.ToInt32(input)].Name;
                                        Console.WriteLine($"Loading {fileName}...");

                                        fileString = LoadFile(fileName);

                                        Console.WriteLine(fileString);

                                        switch (fileString)
                                        {
                                            case "File Not Found":
                                                Console.WriteLine($"Error: {fileString}");
                                                break;
                                            case "":
                                                Console.WriteLine("Error: The file appears to be empty." +
                                                    "\nWould you like to delete it? (Y/N)");

                                                bool deleteEmptyFileLoop = true;

                                                while (deleteEmptyFileLoop)
                                                {
                                                    input = Console.ReadLine();

                                                    switch (input)
                                                    {
                                                        case "Y":
                                                        case "y":
                                                            Console.WriteLine($"Deleting {fileName}.json...");
                                                            File.Delete($@"{filesDir}\{fileName}");
                                                            Console.Write("Success!");

                                                            deleteEmptyFileLoop = !deleteEmptyFileLoop;
                                                            break;
                                                        case "N":
                                                        case "n":
                                                            Console.WriteLine("I'll just leave this here then.");

                                                            deleteEmptyFileLoop = !deleteEmptyFileLoop;
                                                            break;
                                                        default:
                                                            Console.WriteLine("Invalid input");
                                                            break;
                                                    }
                                                }
                                                break;
                                            default:
                                                initialLoadLoop = !initialLoadLoop;
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input");
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Sorry, we can only take numeric inputs for this.\n{0}", e.Message);
                                }
                                #endregion
                                break;
                            case "N":
                            case "n":
                                Console.WriteLine("No worries, just be sure to save your progress later!");
                                initialLoadLoop = !initialLoadLoop;
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                break;
                        }
                    }



                }

                Console.WriteLine("\n\nWhat would you like to do?\n" +
                    "\n0. Exit Program" +
                    "\n1. Create a new collection of shapes" +
                    "\n2. Create a new shape" +
                    "\n3. View the current collection" +
                    "\n4. Sort current collection" +
                    "\n5. Help" +
                    "\n6. Load file" +
                    "\n7. Save file");

                input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        Console.WriteLine("See you next time!");
                        break;
                    case "1":
                        shapes = new List<IShape>();

                        Console.WriteLine($"The new list has been created!");
                        break;
                    case "2":
                        Console.WriteLine("What kind of shape are we making?" +
                            "\nC - Circle" +
                            "\nS - Square" +
                            "\nR - Rectangle" +
                            "\nT - Triangle");
                        switch (Console.ReadLine())
                        {
                            case "C":
                            case "c":
                                #region circle
                                Console.WriteLine("What would you like to call this circle?");
                                string c_name = Console.ReadLine();

                                Console.WriteLine("Radius:");
                                double radius = Convert.ToDouble(Console.ReadLine());

                                shape = new Circle(c_name, radius);

                                if (radius > 0) AddShapeToListCheck(shape, shapes);
                                #endregion
                                break;
                            case "S":
                            case "s":
                                #region square
                                Console.WriteLine("What would you like to call this square?");
                                string s_name = Console.ReadLine();

                                Console.WriteLine("Length:");
                                double s_length = Convert.ToDouble(Console.ReadLine());

                                shape = new Square(s_name, s_length);

                                if (s_length > 0) AddShapeToListCheck(shape, shapes);
                                #endregion
                                break;
                            case "R":
                            case "r":
                                #region rectangle
                                Console.WriteLine("What would you like to call this rectangle?");
                                string r_name = Console.ReadLine();

                                Console.WriteLine("Length:");
                                double r_length = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Width:");
                                double r_width = Convert.ToDouble(Console.ReadLine());

                                if (r_length == r_width && r_length > 0)
                                {
                                    Console.WriteLine($"This is actually a square since L ({r_length}) and W ({r_width}) are equal." +
                                        $"\nWe'll just make this a square instead!");
                                    shape = new Square(r_name, r_length);
                                }
                                else
                                {
                                    shape = new Rectangle(r_name, r_length, r_width);
                                }

                                if (r_length > 0 && r_width > 0) AddShapeToListCheck(shape, shapes);
                                #endregion
                                break;
                            case "T":
                            case "t":
                                #region triangle
                                Console.WriteLine("What would you like to call this triangle?");
                                string t_name = Console.ReadLine();

                                Console.WriteLine("Side A:");
                                double a = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Side B:");
                                double b = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Side C:");
                                double c = Convert.ToDouble(Console.ReadLine());

                                shape = new Triangle(t_name, a, b, c);

                                if (a > 0 && b > 0 && c > 0) AddShapeToListCheck(shape, shapes);
                                #endregion
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                break;

                        }
                        break;
                    case "3":
                        Console.WriteLine($"Here is your current collection:\n");

                        if (shapes.Count > 0)
                        {
                            foreach (IShape s in shapes)
                            {
                                Console.WriteLine(s.ToShapeString());
                            }
                        }
                        else
                        {
                            Console.Write("It appears your collection is empty at the moment." +
                                "\nWhy not add some shapes to it?");
                        }
                        break;
                    case "4":
                        Console.WriteLine("What are we sorting by?" +
                            "\nP - Perimeter" +
                            "\nA - Surface Area");
                        switch (Console.ReadLine())
                        {
                            case "P":
                            case "p":
                                #region perimeter sort
                                shapes.Sort((x, y) => x.Perimeter.CompareTo(y.Perimeter));

                                Console.WriteLine("Do you want that in descending (largest-to-smallest) order? (Y/N)");
                                switch (Console.ReadLine())
                                {
                                    case "Y":
                                    case "y":
                                        shapes.Reverse();
                                        Console.WriteLine($"Here's the result!\n");
                                        foreach (IShape s in shapes)
                                        {
                                            Console.WriteLine(s.ToShapeString());
                                        }
                                        break;
                                    case "N":
                                    case "n":
                                        Console.WriteLine($"Here's the result!\n");
                                        foreach (IShape s in shapes)
                                        {
                                            Console.WriteLine(s.ToShapeString());
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Invalid input");
                                        break;
                                }
                                #endregion
                                break;
                            case "A":
                            case "a":
                                #region surface area sort
                                shapes.Sort((x, y) => x.SurfaceArea.CompareTo(y.SurfaceArea));

                                Console.WriteLine("Do you want that in descending (largest-to-smallest) order? (Y/N)");
                                switch (Console.ReadLine())
                                {
                                    case "Y":
                                    case "y":
                                        shapes.Reverse();
                                        Console.WriteLine($"Here's the result!\n");
                                        foreach (IShape s in shapes)
                                        {
                                            Console.WriteLine(s.ToShapeString());
                                        }
                                        Console.WriteLine($"Here's the result!\n");
                                        break;
                                    case "N":
                                    case "n":
                                        Console.WriteLine($"Here's the result!\n");
                                        foreach (IShape s in shapes)
                                        {
                                            Console.WriteLine(s.ToShapeString());
                                        }
                                        Console.WriteLine($"Here's the result!\n");
                                        break;
                                    default:
                                        Console.WriteLine("Invalid input");
                                        break;
                                }
                                #endregion
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                break;
                        }
                        break;
                    case "5":
                        #region help dialogue
                        Console.WriteLine("Here are helpful things to know!\n" +
                            "\nIn this application, we refer to a group of shapes as a \"Collection\"." +
                            "\nWe keep a collection of shapes that we can save into a save file (TODO)" +
                            "\nso we may act on them later.\n" +
                            "\nIt's also worth noting that you don't have to enter the perimeter or" +
                            "\nthe surface area of any of the shapes! The CLI will guide you through" +
                            "\nthe process to create each one.");
                        #endregion
                        break;
                    case "6":
                        #region save file
                        bool loop = true;
                        while (loop)
                        {
                            Console.WriteLine("Would you like to save your work? (Y/N)");
                            input = Console.ReadLine();

                            switch (input)
                            {
                                case "Y":
                                case "y":
                                    if (fileName == "")
                                    {
                                        Console.WriteLine("It appears we aren't working in a loaded save file." +
                                            "\nLet's create a new one!" +
                                            "\nWhat would you like to call this new file?");
                                        input = Console.ReadLine();
                                        if (Directory.GetFiles(filesDir.Name).Contains($@"{filesDir}\{input}.json"))
                                        {
                                            bool overwriteLoop = true;
                                            var tempFileName = input;

                                            while (overwriteLoop)
                                            {
                                                Console.WriteLine($"It looks like {input}.json already exists!" +
                                                    $"\nOverwrite this file? (Y/N)");

                                                input = Console.ReadLine();

                                                switch (input)
                                                {
                                                    case "Y":
                                                    case "y":
                                                        Console.WriteLine($"Overwriting {tempFileName}.json... ");
                                                        SaveFile(shapes, tempFileName);
                                                        Console.Write("Success!");

                                                        overwriteLoop = !overwriteLoop;
                                                        break;
                                                    case "N":
                                                    case "n":
                                                        Console.WriteLine("No worries, we just need to use a different name!");

                                                        overwriteLoop = !overwriteLoop;
                                                        break;
                                                    default:
                                                        Console.WriteLine("Invalid input");
                                                        break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Creating new file: {input}.json... ");
                                            File.Create($@"{filesDir}\{input}");
                                            Console.Write("Success!");
                                        }
                                    }

                                    loop = !loop;
                                    SaveFile(shapes, fileName);
                                    break;
                                case "N":
                                case "n":
                                    loop = !loop;
                                    break;
                                default:
                                    Console.WriteLine("Invalid input");
                                    break;
                            }
                        }
                        #endregion
                        break;
                    case "7":
                        bool saveLoop = true;
                        while (saveLoop)
                        {
                            Console.WriteLine("What file would you like to save to?");

                            for (int i = 0; i < files.Length; i++)
                            {
                                if (files[i].Name == fileName)
                                {
                                    Console.WriteLine($@"{i}. {files[i].Name} <-- Current File");
                                }
                                else
                                {
                                    Console.WriteLine($@"{i}. {files[i].Name}");
                                }

                                input = Console.ReadLine();

                                try
                                {
                                    if (Convert.ToInt32(input) < files.Length)
                                    {
                                        fileName = files[Convert.ToInt32(input)].Name;
                                        Console.WriteLine($"Saving to {fileName}... ");

                                        SaveFile(shapes, fileName);
                                        fileString = LoadFile(fileName);

                                        Console.Write("Success!");

                                        Console.WriteLine(fileString);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input");
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Sorry, that didn't work.\n\nERROR: {0}", e.Message);
                                }
                            }
                        }
                        break;
                }
            }
            
        }

        static void MockShapeCollection(List<IShape> s)
        {
            s.Add(new Circle("Circle 1", 10));
            s.Add(new Circle("Circle 2", 20));
            s.Add(new Circle("Circle 3", 30));
            s.Add(new Square("Square 1", 10));
            s.Add(new Square("Square 2", 20));
            s.Add(new Square("Square 3", 30));
            s.Add(new Square("Square 4", 40));
            s.Add(new Rectangle("Rectangle 1", 10, 15));
            s.Add(new Rectangle("Rectangle 2", 20, 25));
            s.Add(new Rectangle("Rectangle 3", 30, 35));
            s.Add(new Rectangle("Rectangle 4", 40, 45));
            s.Add(new Triangle("Triangle 1", 10, 10, 10));
            s.Add(new Triangle("Triangle 2", 10, 15, 10));
            s.Add(new Triangle("Triangle 3", 10, 15, 20));
        }

        static void AddShapeToListCheck(IShape shape, List<IShape> shapes)
        {
            Console.WriteLine($"Save {shape.Name} to the list? (Y/N)");
            switch (Console.ReadLine())
            {
                case "Y":
                case "y":
                    Console.WriteLine("Saving...");
                    shapes.Add(shape);
                    Console.Write("Success!");
                    break;
                case "N":
                case "n":
                    Console.WriteLine($"{shape.Name} deleted");
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    break;
            }
        }

        static void SaveFile(List<IShape> shapes, string fileName)
        {
            var saveDir = new DirectoryInfo($@"{Directory.GetCurrentDirectory()}\Files\");
            var fullFileName = $@"{saveDir}\{fileName}";
            var files = Directory.GetFiles(saveDir.FullName);

            if (!files.Contains(fileName))
            {
                File.Create(fullFileName);
            }

            string json = JsonConvert.SerializeObject(shapes, Formatting.Indented);

            File.WriteAllText(fullFileName, json);
        }

        static string LoadFile(string fileName)
        {
            var saveDir = new DirectoryInfo($@"{Directory.GetCurrentDirectory()}\\Files");
            var files = Directory.GetFiles(saveDir.FullName);

            if (files.Contains($@"{saveDir.FullName}\{fileName}"))
            {
                return File.ReadAllText($@"{saveDir.FullName}\{fileName}");
            }
            else
            {
                return "File Not Found";
            }
        }
    }
}
