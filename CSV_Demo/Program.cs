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

            samples.Add("8214,The Rolling Stones,\"2,000 Light Years from Home\",1967"); // correct
            samples.Add("11250,\"Jones-Smith, Incorporated [Count Basie]\",\"Oh, Lady Be Good\",1936"); // correct

            foreach (string sample in samples)
            {
                temp = sample.Split(',');
                foreach (string t in temp)
                    Console.Write(t + "--");
                Console.WriteLine();
                //Console.WriteLine(temp.Length);
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
                        if (temp[x][0] == '"')
                        {
                            if (mergeThing.Length > 0)
                            {
                                things.Add(mergeThing);
                                mergeThing = "";
                            }
                            mergeThing += temp[x];
                        }
                        else if (temp[x][0] == ' ')
                        {
                            if (mergeThing.Length > 0)
                            {
                                mergeThing += ",";
                            }
                            mergeThing += temp[x];
                        }
                        else if ((int)temp[x][0] >= 48 && (int)temp[x][0] <= 57)
                        {
                            if (mergeThing.Length > 0)
                            {
                                mergeThing += ",";
                                mergeThing += temp[x];
                            }
                            else
                                things.Add(temp[x]);

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

                        if (temp[x][temp[x].Length - 1] == '"')
                            if (mergeThing.Length > 0)
                            {
                                things.Add(mergeThing);
                                mergeThing = "";
                            }

                    }
                }
                dSample[songID] = things;
            }
            Console.WriteLine("\n\n");
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
