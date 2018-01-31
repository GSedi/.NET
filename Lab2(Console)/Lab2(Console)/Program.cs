using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Lab2_Console_
{
    class Program
    {
    static void Main(string[] args)
        {

          
            
            string s1, s2;
            s1 = Console.ReadLine();
            s2 = Console.ReadLine();

            /*StreamReader sr = new StreamReader("matrix.txt");
            string t1;
            string[] t2;
            int di = 0;
            int[,] matrix = new int[26, 26];

            while (!sr.EndOfStream)
            {
                t1 = sr.ReadLine();
                t2 = t1.Split();
                for (int j = 0; j < t2.Length; j++)
                {
                    matrix[di, j] = int.Parse(t2[j]);
                }
                di++;


            }
            */
            int[,] dp = new int[s1.Length + 1, s2.Length + 1];
            string[,] ptr = new string[s1.Length + 1, s2.Length + 1];
            dp[0, 0] = 0;
            for (int i = 0; i <= s1.Length; i++)
            {
                dp[i, 0] = i;
            }
            for (int j = 0; j <= s2.Length; j++)
            {
                dp[0, j] = j;
            }

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1]);
                        
                        if (dp[i, j] == dp[i - 1, j-1]) ptr[i, j] += "\\";
                    }
                    else
                    {
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1] + 2);
                        
                        if (dp[i, j] == dp[i - 1, j - 1]+2) ptr[i, j] += "\\";
                    }

                    if (dp[i, j] == dp[i, j - 1] + 1) ptr[i, j] += "--";
                    if (dp[i, j] == dp[i - 1, j] + 1) ptr[i, j] += "|";
                    
                }
            }


         
            Console.WriteLine(dp[s1.Length, s2.Length]);

            List<string> ans = new List<string>();

            int temp = dp[s1.Length, s2.Length];
            int dpi = s1.Length, dpj = s2.Length;
            while (true) {
                
                if (dpi != 0 && dpj != 0)
                {
                    if (dp[dpi - 1, dpj - 1] == temp && s1[dpi - 1] == s2[dpj - 1])
                    {

                        dpi -= 1;
                        dpj -= 1;
                        //Console.WriteLine("Do nothing with \"" + s1[dpi] + "\"");
                        ans.Add("Do nothing with \"" + s1[dpi] + "\"");



                    }
                    else
                    {
                        temp = Math.Min(Math.Min(dp[dpi - 1, dpj], dp[dpi, dpj - 1]), dp[dpi - 1, dpj - 1]);
                        if (temp == dp[dpi - 1, dpj])
                        {
                            dpi -= 1;
                          //  Console.WriteLine("Delete the \"" + s1[dpi] + "\"");
                            ans.Add("Delete the \"" + s1[dpi] + "\"");
                        }
                        else if (temp == dp[dpi, dpj - 1])
                        {
                            dpj -= 1;
                            //Console.WriteLine("Insert the \"" + s2[dpj] + "\"");
                            ans.Add("Insert the \"" + s2[dpj] + "\"");
                        }
                        else
                        {
                            dpi -= 1;
                            dpj -= 1;
                            //Console.WriteLine("Substitute the \"" + s1[dpi] + "\" with \"" + s2[dpj] + "\"");
                            ans.Add("Substitute the \"" + s1[dpi] + "\" with \"" + s2[dpj] + "\"");
                        }
                    }
                }
                else if (dpi == 0 && dpj == 0) break;
                else if (dpi == 0)
                {
                    dpj -= 1;
                    //Console.WriteLine("Substitute the \"" + s1[dpi] + "\" with \"" + s2[dpj] + "\"");
                    ans.Add("Insert the \"" + s2[dpj] + "\"");
                }
                else if (dpj == 0) {
                    dpi -= 1;
                    //Console.WriteLine("Delete the \"" + s1[dpi] + "\"");
                    ans.Add("Delete the \"" + s1[dpi] + "\"");
                }


                
                
            }

            ans.Reverse();
            for (int i = 0; i < ans.Count; i++) {
                Console.WriteLine(ans[i]);
            }

           
            //sr.Close();

            Console.ReadKey();
        }
    }
}

/* 
  string s1, s2;
            s1 = Console.ReadLine();
            StreamReader sr = new StreamReader("words");
            int mini = 100000;
            while (!sr.EndOfStream)
            {
                s2 = sr.ReadLine();
                int[,] dp = new int[s1.Length + 1, s2.Length + 1];
                for (int i = 0; i <= s1.Length; i++)
                {
                    dp[i, 0] = i;
                }
                for (int j = 0; j <= s2.Length; j++)
                {
                    dp[0, j] = j;
                }

                for (int i = 1; i <= s1.Length; i++)
                {
                    for (int j = 1; j <= s2.Length; j++)
                    {
                        if (s1[i - 1] == s2[j - 1])
                        {
                            dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1]);
                        }
                        else
                        {
                            dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1] + 2);
                        }
                    }
                }

                if (dp[s1.Length, s2.Length] <= 2)
                {
                    Console.WriteLine(s2 + " " + dp[s1.Length, s2.Length]);
                }

            }

           

            Console.ReadKey();

    */
/*
 * string s1, s2;
        s1 = Console.ReadLine();
        s2 = Console.ReadLine();



        int[,] dp = new int[s1.Length + 1, s2.Length + 1];

        for (int i = 0; i <= s1.Length; i++)
        {
            dp[i, 0] = i;
        }
        for (int j = 0; j <= s2.Length; j++)
        {
            dp[0, j] = j;
        }

        for (int i = 1; i <= s1.Length; i++)
        {
            for (int j = 1; j <= s2.Length; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                {
                    dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1]);
                }
                else
                {
                    dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1] + 2);
                }
             }
         }


        Console.WriteLine(dp[s1.Length, s2.Length]);





        Console.ReadKey();
 */
/*
    for (int i = 0; i <= s1.Length; i++) {
               for (int j = 0; j <= s2.Length; j++) {
                   if (ptr[i, j] == null) continue;
                   if (ptr[i, j].Length == 4) Console.Write( ptr[i, j] + "    " );
                   else if (ptr[i, j].Length == 3) Console.Write(ptr[i, j] + "     ");
                   else if (ptr[i, j].Length == 2) Console.Write(ptr[i, j] + "      ");
                   else if (ptr[i, j].Length == 1) Console.Write(ptr[i, j] + "       ");

               }
               Console.WriteLine();

           }
           for (int i = 0; i <= s1.Length; i++) {
               for (int j = 0; j <= s2.Length; j++) {
                   Console.Write(dp[i, j] + " ");

               }
               Console.WriteLine();
           }
   */

/*
 string s1, s2;
        s1 = Console.ReadLine();
        s2 = Console.ReadLine();



        int[,] dp = new int[s1.Length + 1, s2.Length + 1];
        string[,] ptr = new string[s1.Length + 1, s2.Length + 1];

        for (int i = 0; i <= s1.Length; i++)
        {
            dp[i, 0] = i;
        }
        for (int j = 0; j <= s2.Length; j++)
        {
            dp[0, j] = j;
        }

        for (int i = 1; i <= s1.Length; i++)
        {
            for (int j = 1; j <= s2.Length; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                {
                    dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1]);

                    if (dp[i, j] == dp[i - 1, j-1]) ptr[i, j] += "\\";
                }
                else
                {
                    dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1] + 2);

                    if (dp[i, j] == dp[i - 1, j - 1]+2) ptr[i, j] += "\\";
                }

                if (dp[i, j] == dp[i, j - 1] + 1) ptr[i, j] += "--";
                if (dp[i, j] == dp[i - 1, j] + 1) ptr[i, j] += "|";

            }
        }



        Console.WriteLine(dp[s1.Length, s2.Length]);

        List<string> ans = new List<string>();

        int temp = dp[s1.Length, s2.Length];
        int dpi = s1.Length, dpj = s2.Length;
        while (true) {

            if (dpi != 0 && dpj != 0)
            {
                if (dp[dpi - 1, dpj - 1] == temp && s1[dpi - 1] == s2[dpj - 1])
                {

                    dpi -= 1;
                    dpj -= 1;
                    //Console.WriteLine("Do nothing with \"" + s1[dpi] + "\"");
                    ans.Add("Do nothing with \"" + s1[dpi] + "\"");



                }
                else
                {
                    temp = Math.Min(Math.Min(dp[dpi - 1, dpj], dp[dpi, dpj - 1]), dp[dpi - 1, dpj - 1]);
                    if (temp == dp[dpi - 1, dpj])
                    {
                        dpi -= 1;
                      //  Console.WriteLine("Delete the \"" + s1[dpi] + "\"");
                        ans.Add("Delete the \"" + s1[dpi] + "\"");
                    }
                    else if (temp == dp[dpi, dpj - 1])
                    {
                        dpj -= 1;
                        //Console.WriteLine("Insert the \"" + s2[dpj] + "\"");
                        ans.Add("Insert the \"" + s2[dpj] + "\"");
                    }
                    else
                    {
                        dpi -= 1;
                        dpj -= 1;
                        //Console.WriteLine("Substitute the \"" + s1[dpi] + "\" with \"" + s2[dpj] + "\"");
                        ans.Add("Substitute the \"" + s1[dpi] + "\" with \"" + s2[dpj] + "\"");
                    }
                }
            }
            else if (dpi == 0 && dpj == 0) break;
            else if (dpi == 0)
            {
                dpj -= 1;
                //Console.WriteLine("Substitute the \"" + s1[dpi] + "\" with \"" + s2[dpj] + "\"");
                ans.Add("Substitute the \"" + s1[dpi] + "\" with \"" + s2[dpj] + "\"");
            }
            else if (dpj == 0) {
                dpi -= 1;
                //Console.WriteLine("Delete the \"" + s1[dpi] + "\"");
                ans.Add("Delete the \"" + s1[dpi] + "\"");
            }




        }

        ans.Reverse();
        for (int i = 0; i < ans.Count; i++) {
            Console.WriteLine(ans[i]);
        }

        StreamReader sr = new StreamReader("matrix.txt");
        string t1;
        string[] t2;
        int di = 0;
        int[,] matrix = new int[26, 26];

        while (!sr.EndOfStream) {
            t1 = sr.ReadLine();
            t2 = t1.Split();
            for (int j = 0; j < t2.Length; j++) {
                matrix[di, j] = int.Parse(t2[j]);
            }
            di++;


        }

        for (int i = 0; i < 26; i++) {
            for (int j = 0; j < 26; j++) {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        sr.Close();

        Console.ReadKey(); 

    */

