using System;
using System.Collections.Generic;
using System.IO;
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
            var directory = new DirectoryInfo($@"{Directory.GetCurrentDirectory()}\\Files\\");
            string input = "";

            // These methods are used to create a mock ShapeCollection and populate it with several different shapes
            MockShapeCollection(shapes);
            //Console.WriteLine(collection.ToCollectionString());

            var mockdi = new DirectoryInfo($@"{Directory.GetCurrentDirectory()}\\Files\\");
            FileInfo[] mockFile = mockdi.GetFiles(@"mock.json");
            string json = JsonConvert.SerializeObject(shapes, Formatting.Indented);
            File.WriteAllText($@"{mockdi}\\mock.json", json);

            Console.WriteLine("Welcome to the Coderbyte Math App!");
            
            while (input != "0")
            {
                // Maybe we could ask user if they'd like to load a file?

                var di = new DirectoryInfo($@"{Directory.GetCurrentDirectory()}\Files\");
                // X:\Code Projects\Coderbyte-Math-App\Coderbyte Math App\bin\Debug\netcoreapp3.1\Files
                FileInfo[] jFiles = di.GetFiles("*.json");

                

                if (jFiles.Length > 0)
                {
                    Console.WriteLine("It looks like there are some saved files. Would you like to open one? (Y/N)");

                    input = Console.ReadLine();
                    bool continueLooping = true;

                    while (continueLooping)
                    {
                        switch (input)
                        {
                            case "Y":
                            case "y":
                                Console.WriteLine("Which file would you like to load?");
                                // foreach (FileInfo file in jFiles)
                                for(int i = 0; i < jFiles.Length; i++)
                                {   
                                    Console.WriteLine($@"{i}. {jFiles[i].Name}");
                                }

                                input = Console.ReadLine();
                                if(Convert.ToInt32(input) < jFiles.Length)
                                {
                                    var fileToLoad = jFiles[Convert.ToInt32(input)];
                                    Console.WriteLine($"Loading {fileToLoad.Name}...");

                                    string loadedFile = File.ReadAllText($@"{di}\\{fileToLoad.Name}");

                                    Console.WriteLine($"Before: ");
                                    foreach(IShape s in shapes)
                                    {
                                        Console.WriteLine(s.ToShapeString());
                                    }
                                    shapes = JsonConvert.DeserializeObject<List<IShape>>(loadedFile);

                                    /**
                                     * Note for me:
                                     * This can't deserialize the JSON file because IShape (being an interface) can't be instantiated.
                                     */

                                    Console.WriteLine($"After: {shapes}");
                                    foreach (IShape s in shapes)
                                    {
                                        Console.WriteLine(s.ToShapeString());
                                    }
                                }
                                
                                continueLooping = !continueLooping;
                                break;
                            case "N":
                            case "n":
                                continueLooping = !continueLooping;
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

                                if (radius > 0) SaveShapeToCollectionCheck(shape, shapes);
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

                                if (s_length > 0) SaveShapeToCollectionCheck(shape, shapes);
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
                                
                                if(r_length == r_width && r_length > 0)
                                {
                                    Console.WriteLine($"This is actually a square since L ({r_length}) and W ({r_width}) are equal." +
                                        $"\nWe'll just make this a square instead!");
                                    shape = new Square(r_name, r_length);
                                }
                                else
                                {
                                    shape = new Rectangle(r_name, r_length, r_width);
                                }

                                if (r_length > 0 && r_width > 0) SaveShapeToCollectionCheck(shape, shapes);
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

                                if (a > 0 && b > 0 && c > 0) SaveShapeToCollectionCheck(shape, shapes);
                                #endregion
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                break;

                        }
                        break;
                    case "3":
                        Console.WriteLine($"Here is your current collection:\n");
                        foreach(IShape s in shapes)
                        {
                            Console.WriteLine(s.ToShapeString());
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
                    default:
                        Console.WriteLine("Invalid input");
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

        static void SaveShapeToCollectionCheck(IShape shape, List<IShape> shapes)
        {
            Console.WriteLine($"Save {shape.Name} to the list? (Y/N)");
            switch (Console.ReadLine())
            {
                case "Y":
                case "y":
                    Console.WriteLine("Saving...");
                    shapes.Add(shape);
                    Console.WriteLine("Success!");
                    break;
                case "N":
                case "n":
                    Console.WriteLine("Very well.");
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    break;
            }
        }
    }
}
