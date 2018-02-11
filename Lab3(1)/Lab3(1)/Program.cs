using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab3_1_
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashTable = new Hashtable();
            ListDictionary listDicti = new ListDictionary();
            HybridDictionary hybDicti = new HybridDictionary();


            Stopwatch stopWatchHashTable = new Stopwatch();
            Stopwatch stopWatchListDicti = new Stopwatch();
            Stopwatch stopWatchHybDicti = new Stopwatch();

            int cnt = 10000;
            /*for (int i = 0; i < cnt; i++)
            {
                hashTable.Add(i, "OOP/.NET");
                listDicti.Add(i, "OOP/.NET");
                hybDicti.Add(i, "OOP/.NET");

            }
            */
            stopWatchHashTable.Start();
            for (int i = 0; i < cnt; i++) hashTable.Add(i, "OOP/.NET"); //Console.WriteLine(hashTable[i]);
            stopWatchHashTable.Stop();
            TimeSpan tsHashTable = stopWatchHashTable.Elapsed;
            //string hashTableElapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //tsHashTable.Hours, tsHashTable.Minutes, tsHashTable.Seconds, tsHashTable.Milliseconds );
            Console.WriteLine("RunTime HashTable" + tsHashTable);

            stopWatchListDicti.Start();
            for (int i = 0; i < cnt; i++) listDicti.Add(i, "OOP/.NET");  //Console.WriteLine(listDicti[i]);
            stopWatchListDicti.Stop();
            TimeSpan tsListDicti = stopWatchListDicti.Elapsed;
            string ListDictiElapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            tsListDicti.Hours, tsListDicti.Minutes, tsListDicti.Seconds, tsListDicti.Milliseconds);
            Console.WriteLine("RunTime ListDicti" + ListDictiElapsedTime);

            stopWatchHybDicti.Start();
            for (int i = 0; i < cnt; i++) hybDicti.Add(i, "OOP/.NET");  //Console.WriteLine(hybDicti[i]);
            stopWatchHybDicti.Stop();
            TimeSpan tsHybDicti = stopWatchHybDicti.Elapsed;
            string HybDictiElapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            tsHybDicti.Hours, tsHybDicti.Minutes, tsHybDicti.Seconds, tsHybDicti.Milliseconds);
            Console.WriteLine("RunTime HybDicti" + HybDictiElapsedTime);

            Console.ReadKey();
        }
    }
}
