using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_3_
{
    class Program
    {
        static void Main(string[] args)
        {
            
                DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Администратор\Desktop\dotNET\Labs\Lab1(3)\Lab1(3)\bin\Debug");
                FileInfo[] files = dir.GetFiles();
                string title;
              
                while (true) {
                     Console.WriteLine("Enter a file title");
                     title = Console.ReadLine();
                      if (title == "exit") break;
                                              
                    try
                    {
                        StreamReader sr = new StreamReader(title);
                    try
                    {
                        Console.WriteLine(Path.GetFullPath(title));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Sorry, something get wrong!");
                    }
                    try
                    {
                        Console.WriteLine(sr.ReadToEnd());
                        sr.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Sorry, something get wrong!");
                    }
                }
                    catch (FileNotFoundException fnfe)
                    {
                        Console.WriteLine("File not found");
                    }
                    catch(UnauthorizedAccessException uae) {
                        Console.WriteLine("Unauthorized access");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Sorry, something get wrong!");
                    }
            }

             


            
            
        }
    }
}
