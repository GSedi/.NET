using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace SearchAlgo
{
    class Program
    {
        static List<FileInfo> files = new List<FileInfo>();
        static HashSet<long> hs = new HashSet<long>();
        static long hash;
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\");
           recFind(dir);
            
           
            
            StreamWriter sw = new StreamWriter("words.txt");
            for (int i = 0; i < hs.Count; i++) {
                sw.WriteLine(hs.ElementAt(i));
            }
            sw.Close();
        }

           static void recFind(DirectoryInfo dir) {
            try
            {
                
                FileSystemInfo[] infos = dir.GetFileSystemInfos();

                foreach (FileSystemInfo fsi in infos)
                {
                    if (fsi is FileInfo)
                    {
                        //files.Add(fsi as FileInfo);
                        hash = fsi.GetHashCode();
                        hs.Add(hash);
                        Console.WriteLine(hash + " " + hs.Count());

                    }
                    else if (fsi is DirectoryInfo) recFind(fsi as DirectoryInfo);
                }
            }
            catch (Exception e) { }
        
        
        }
    }
}
