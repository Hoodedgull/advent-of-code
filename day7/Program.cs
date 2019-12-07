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

            var currentMax = 0;

            var setsList = new List<int[]> { new int[] { 0, 1, 2, 3, 4 } };

            for (var q = 0; q < setsList.Select(x =>string.Join("", x)).Distinct().Count(); q++)
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

            setsList.ToList().ForEach(x => System.Console.WriteLine(string.Join("", x)));
            foreach (var phaseSettings in setsList)
            {

                var a = phaseSettings[0];
                var b = phaseSettings[1];
                var c = phaseSettings[2];
                var d = phaseSettings[3];
                var e = phaseSettings[4];

                var input = new Stack<int>();
                input.Push(0);
                input.Push(a);
                var results = runIntcode(input);

                input.Push(results.Last());
                input.Push(b);
                results = runIntcode(input);

                input.Push(results.Last());
                input.Push(c);
                results = runIntcode(input);

                input.Push(results.Last());
                input.Push(d);
                results = runIntcode(input);

                input.Push(results.Last());
                input.Push(e);
                results = runIntcode(input);

                if (results.Last() > currentMax)
                {
                    currentMax = results.Last();
                }


            }


            System.Console.WriteLine(currentMax);
        }

        private static List<int> runIntcode(Stack<int> input)
        {
            var instructions = "3,8,1001,8,10,8,105,1,0,0,21,34,59,68,89,102,183,264,345,426,99999,3,9,102,5,9,9,1001,9,5,9,4,9,99,3,9,101,3,9,9,1002,9,5,9,101,5,9,9,1002,9,3,9,1001,9,5,9,4,9,99,3,9,101,5,9,9,4,9,99,3,9,102,4,9,9,101,3,9,9,102,5,9,9,101,4,9,9,4,9,99,3,9,1002,9,5,9,1001,9,2,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,99,3,9,1001,9,1,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,99,3,9,101,1,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,2,9,9,4,9,99,3,9,1001,9,1,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1001,9,2,9,4,9,3,9,1002,9,2,9,4,9,99";
            //instructions = "3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0";
            var list = instructions.Split(',').Select(word => int.Parse(word)).ToList();
            var outputs = new List<int>();
            var i = 0;
            while (i >= 0)
            {
                string opCode = list[i].ToString();
                if (opCode.EndsWith("1"))
                {
                    list[list[i + 3]] = addNumbers(list[i], list[i + 1], list[i + 2], list);
                    i += 4;
                }
                else if (opCode.EndsWith("2"))
                {
                    list[list[i + 3]] = multiplyNumbers(list[i], list[i + 1], list[i + 2], list);
                    i += 4;
                }
                else if (opCode.EndsWith("3"))
                {
                    list[list[i + 1]] = input.Pop();
                    i += 2;
                }
                else if (opCode.EndsWith("4"))
                {
                    if (opCode[0] == '1')
                    {
                        outputs.Add(list[i + 1]);
                    }
                    else
                    {

                        outputs.Add(list[list[i + 1]]);
                    }
                    i += 2;
                }
                else if (opCode.EndsWith("5"))
                {
                    var newI = JumpIfTrue(list[i], list[i + 1], list[i + 2], list);
                    if (newI < 0)
                    {
                        i += 3;
                    }
                    else
                    {
                        i = newI;
                    }
                }
                else if (opCode.EndsWith("6"))
                {
                    var newI = JumpIfFalse(list[i], list[i + 1], list[i + 2], list);
                    if (newI < 0)
                    {
                        i += 3;
                    }
                    else
                    {
                        i = newI;
                    }
                }
                else if (opCode.EndsWith("7"))
                {
                    list[list[i + 3]] = LessThan(list[i], list[i + 1], list[i + 2], list);
                    i += 4;
                }
                else if (opCode.EndsWith("8"))
                {
                    list[list[i + 3]] = Equals(list[i], list[i + 1], list[i + 2], list);
                    i += 4;
                }
                else if (opCode.EndsWith("99"))
                {
                    break;
                }
                else
                {
                    throw new Exception();
                }

            }


            return outputs;
        }

        private static int addNumbers(int opCode, int param1, int param2, List<int> theList)
        {
            var sum = 0;
            if (opCode >= 1000)
            {
                sum = param2;
            }
            else
            {
                sum = theList[param2];
            }
            if ((opCode >= 100 && opCode < 1000) || (opCode > 1000 && opCode - 1000 >= 100))
            {
                sum += param1;
            }
            else
            {
                sum += theList[param1];
            }
            return sum;
        }

        private static int multiplyNumbers(int opCode, int param1, int param2, List<int> theList)
        {
            var sum = 0;
            if (opCode >= 1000)
            {
                sum = param2;
            }
            else
            {
                sum = theList[param2];
            }
            if ((opCode >= 100 && opCode < 1000) || (opCode > 1000 && opCode - 1000 >= 100))
            {
                sum *= param1;
            }
            else
            {
                sum *= theList[param1];
            }
            return sum;
        }

        private static int JumpIfTrue(int opCode, int param1, int param2, List<int> theList)
        {

            var secondValue = 0;
            if (opCode >= 1000)
            {
                secondValue = param2;
            }
            else
            {
                secondValue = theList[param2];
            }
            if ((opCode >= 100 && opCode < 1000) || (opCode > 1000 && opCode - 1000 >= 100))
            {
                return 0 != param1 ? secondValue : -1;
            }
            else
            {
                return 0 != theList[param1] ? secondValue : -1;
            }

        }

        private static int JumpIfFalse(int opCode, int param1, int param2, List<int> theList)
        {

            var secondValue = 0;
            if (opCode >= 1000)
            {
                secondValue = param2;
            }
            else
            {
                secondValue = theList[param2];
            }
            if ((opCode >= 100 && opCode < 1000) || (opCode > 1000 && opCode - 1000 >= 100))
            {
                return 0 == param1 ? secondValue : -1;
            }
            else
            {
                return 0 == theList[param1] ? secondValue : -1;
            }

        }

        private static int LessThan(int opCode, int param1, int param2, List<int> theList)
        {
            var secondValue = 0;
            if (opCode >= 1000)
            {
                secondValue = param2;
            }
            else
            {
                secondValue = theList[param2];
            }
            if ((opCode >= 100 && opCode < 1000) || (opCode > 1000 && opCode - 1000 >= 100))
            {
                return param1 < secondValue ? 1 : 0;
            }
            else
            {
                return theList[param1] < secondValue ? 1 : 0;
            }
        }

        private static int Equals(int opCode, int param1, int param2, List<int> theList)
        {
            var secondValue = 0;
            if (opCode >= 1000)
            {
                secondValue = param2;
            }
            else
            {
                secondValue = theList[param2];
            }
            if ((opCode >= 100 && opCode < 1000) || (opCode > 1000 && opCode - 1000 >= 100))
            {
                return param1 == secondValue ? 1 : 0;
            }
            else
            {
                return theList[param1] == secondValue ? 1 : 0;
            }
        }
    }
}
