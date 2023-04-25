using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> samples = new List<string>();
            Dictionary<int, List<string>> dSample = new Dictionary<int, List<string>>();
            List<string> things = new List<string>();
            int songID = 0;
            string[] temp = new string[] { };
            string mergeThing = "";

            samples.Add("1028,Roy Orbison,\"Oh, Pretty Woman\",1964"); // correct
            samples.Add("1117,\"Gary \"\"U.S.\"\" Bonds\",Quarter to Three,1961"); // correct
            samples.Add("1323,Big Joe Turner,\"Shake, Rattle and Roll\",1954"); // correct
            samples.Add("859,\"Crosby, Stills, Nash (& Young)\",Ohio,1970"); // correct
            samples.Add("1619,\"Clarence \"\"Frogman\"\" Henry\",Ain't Got No Home,1956"); // correct

            foreach(string sample in samples)
            {
                temp = sample.Split(',');
                Console.WriteLine(temp.Length);
                songID = int.Parse(temp[0]);
                things = new List<string>();

                if (temp.Length == 4) 
                { 
                    for(int x = 1; x < temp.Length; x++) 
                    {
                        things.Add(temp[x]);
                    }
                }
                else
                {
                    mergeThing = "";
                    for (int x = 1; x < temp.Length; x++)
                    {
                        // this is the scenario I chose
                        // what I saw, if the thing is split, the merged thing will start 
                        // with a ' ' or a '"'
                        if (temp[x][0] == ' ' || temp[x][0] == '"')
                        {
                            // this combines all the things that need to be merged
                            // the if statement would just add a ','
                            if (mergeThing.Length > 0)
                                mergeThing += ",";
                            mergeThing += temp[x];
                        }
                        else
                        {
                            if (mergeThing.Length > 0)
                            {
                                things.Add(mergeThing);
                                mergeThing = "";
                            }

                            things.Add(temp[x]);
                        }
                    }
                }
                dSample[songID] = things;
            }

            foreach(KeyValuePair<int, List<string>> kvp in dSample) 
            {
                Console.Write(kvp.Key + "--");
                foreach(string value in kvp.Value)
                {
                    Console.Write(value + "--");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
