using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace day7
{
    class Program
    {
        static void Main(string[] args)
        {


            //        RunFirstTest();
            RunSecondTest();




        }

        private static void RunSecondTest()
        {
            var instructions = "3,8,1001,8,10,8,105,1,0,0,21,34,59,68,89,102,183,264,345,426,99999,3,9,102,5,9,9,1001,9,5,9,4,9,99,3,9,101,3,9,9,1002,9,5,9,101,5,9,9,1002,9,3,9,1001,9,5,9,4,9,99,3,9,101,5,9,9,4,9,99,3,9,102,4,9,9,101,3,9,9,102,5,9,9,101,4,9,9,4,9,99,3,9,1002,9,5,9,1001,9,2,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,99,3,9,1001,9,1,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,99,3,9,101,1,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,2,9,9,4,9,99,3,9,1001,9,1,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1001,9,2,9,4,9,3,9,1002,9,2,9,4,9,99";
           // instructions = "3,52,1001,52,-5,52,3,53,1,52,56,54,1007,54,5,55,1005,55,26,1001,54,-5,54,1105,1,12,1,53,54,53,1008,54,0,55,1001,55,1,55,2,53,55,53,4,53,1001,56,-1,56,1005,56,6,99,0,0,0,0,10";
            //instructions = "3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5";
            var currentMax = 0;
            int[] bestCombo = null;
            var setsList = GenerateAllOptions( new List<int[]>{ new int[] {5,6,7,8,9}});
            System.Console.WriteLine(setsList.Count);
            foreach (var combination in setsList)
            {

                var A = new IntCodeComputer(instructions);
                var B = new IntCodeComputer(instructions);
                var C = new IntCodeComputer(instructions);
                var D = new IntCodeComputer(instructions);
                var E = new IntCodeComputer(instructions);

                // Phase settings
                A.RunIntcode(combination[0]);
                B.RunIntcode(combination[1]);
                C.RunIntcode(combination[2]);
                D.RunIntcode(combination[3]);
                E.RunIntcode(combination[4]);

                while (true)
                {
                    A.RunIntcode(E.Outputs.LastOrDefault());
                    B.RunIntcode(A.Outputs.LastOrDefault());
                    C.RunIntcode(B.Outputs.LastOrDefault());
                    D.RunIntcode(C.Outputs.LastOrDefault());
                    E.RunIntcode(D.Outputs.LastOrDefault());
                    if (E.State == "HALTED")
                    {
                        if (E.Outputs.LastOrDefault() > currentMax)
                        {
                            currentMax = E.Outputs.LastOrDefault();
                            bestCombo = combination;
                        }
                        break;
                    }

                }
            }
            System.Console.WriteLine(currentMax);
            System.Console.WriteLine(string.Join("",bestCombo));
        }

        private static List<int[]> GenerateAllOptions2()
        {
            var list = new List<int[]>();
            for(int a = 5; a < 10; a++){
                for(int b = 5; b < 10; b++){
                    for(int c = 5; c <10; c++){
                        for(int d= 5; d<10; d++){
                            for(int e = 5; e< 10; e++){
                                if(a != b && a != c && a != d && a != e
                                && b != c && b!= d && b!= e&& 
                                c != d && c!= e
                                && d!= e){

                                list.Add(new int[]{a,b,c,d,e});
                                }
                            }
                        }
                    }
                }
            }
            return list;
        }

        private static void RunFirstTest()
        {

            var instructions = "3,8,1001,8,10,8,105,1,0,0,21,34,59,68,89,102,183,264,345,426,99999,3,9,102,5,9,9,1001,9,5,9,4,9,99,3,9,101,3,9,9,1002,9,5,9,101,5,9,9,1002,9,3,9,1001,9,5,9,4,9,99,3,9,101,5,9,9,4,9,99,3,9,102,4,9,9,101,3,9,9,102,5,9,9,101,4,9,9,4,9,99,3,9,1002,9,5,9,1001,9,2,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,99,3,9,1001,9,1,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,99,3,9,101,1,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,2,9,9,4,9,99,3,9,1001,9,1,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1001,9,2,9,4,9,3,9,1002,9,2,9,4,9,99";
            var icc = new IntCodeComputer(instructions);

            var currentMax = 0;

            List<int[]> setsList = GenerateAllOptions(new List<int[]> { new int[] { 0, 1, 2, 3, 4 } });

            foreach (var phaseSettings in setsList)
            {
                var a = phaseSettings[0];
                var b = phaseSettings[1];
                var c = phaseSettings[2];
                var d = phaseSettings[3];
                var e = phaseSettings[4];

                icc = new IntCodeComputer(instructions);

                icc.RunIntcode(a);
                icc.RunIntcode(0);
                var results = icc.Outputs;

                icc = new IntCodeComputer(instructions);
                icc.RunIntcode(b);
                icc.RunIntcode(results.Last());
                results = icc.Outputs;
                icc = new IntCodeComputer(instructions);

                icc.RunIntcode(c);
                icc.RunIntcode(results.Last());
                results = icc.Outputs;
                icc = new IntCodeComputer(instructions);

                icc.RunIntcode(d);
                icc.RunIntcode(results.Last());
                results = icc.Outputs;
                icc = new IntCodeComputer(instructions);

                icc.RunIntcode(e);
                icc.RunIntcode(results.Last());
                results = icc.Outputs;
                if (results.Last() > currentMax)
                {
                    currentMax = results.Last();
                }
            }
            System.Console.WriteLine(currentMax);

        }

        private static List<int[]> GenerateAllOptions(List<int[]> parts)
        {
            var setsList = parts;

            for (var q = 0; q < setsList.Select(x => string.Join("", x)).Distinct().Count(); q++)
            {

                for (int j = 0; j < 5; j++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        var clone = setsList[q].Select(x => x).ToArray();

                        var tmp = clone[j];
                        clone[j] = clone[i];
                        clone[i] = tmp;
                        setsList.Add(clone);




                    }
                }
            }

            return setsList;
        }
    }
}
