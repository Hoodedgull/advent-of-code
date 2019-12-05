using System;
using System.Linq;
using System.Collections.Generic;

namespace day5
{
    class Program
    {
        static void Main(string[] args)
        {

            var results = runIntcode(5);
            results.ForEach(i => System.Console.WriteLine(i));

        }

        private static List<int> runIntcode(int input)
        {
            var instructions = "3,225,1,225,6,6,1100,1,238,225,104,0,1102,46,47,225,2,122,130,224,101,-1998,224,224,4,224,1002,223,8,223,1001,224,6,224,1,224,223,223,1102,61,51,225,102,32,92,224,101,-800,224,224,4,224,1002,223,8,223,1001,224,1,224,1,223,224,223,1101,61,64,225,1001,118,25,224,101,-106,224,224,4,224,1002,223,8,223,101,1,224,224,1,224,223,223,1102,33,25,225,1102,73,67,224,101,-4891,224,224,4,224,1002,223,8,223,1001,224,4,224,1,224,223,223,1101,14,81,225,1102,17,74,225,1102,52,67,225,1101,94,27,225,101,71,39,224,101,-132,224,224,4,224,1002,223,8,223,101,5,224,224,1,224,223,223,1002,14,38,224,101,-1786,224,224,4,224,102,8,223,223,1001,224,2,224,1,223,224,223,1,65,126,224,1001,224,-128,224,4,224,1002,223,8,223,101,6,224,224,1,224,223,223,1101,81,40,224,1001,224,-121,224,4,224,102,8,223,223,101,4,224,224,1,223,224,223,4,223,99,0,0,0,677,0,0,0,0,0,0,0,0,0,0,0,1105,0,99999,1105,227,247,1105,1,99999,1005,227,99999,1005,0,256,1105,1,99999,1106,227,99999,1106,0,265,1105,1,99999,1006,0,99999,1006,227,274,1105,1,99999,1105,1,280,1105,1,99999,1,225,225,225,1101,294,0,0,105,1,0,1105,1,99999,1106,0,300,1105,1,99999,1,225,225,225,1101,314,0,0,106,0,0,1105,1,99999,1008,677,226,224,1002,223,2,223,1005,224,329,1001,223,1,223,107,677,677,224,102,2,223,223,1005,224,344,101,1,223,223,1107,677,677,224,102,2,223,223,1005,224,359,1001,223,1,223,1108,226,226,224,1002,223,2,223,1006,224,374,101,1,223,223,107,226,226,224,1002,223,2,223,1005,224,389,1001,223,1,223,108,226,226,224,1002,223,2,223,1005,224,404,1001,223,1,223,1008,677,677,224,1002,223,2,223,1006,224,419,1001,223,1,223,1107,677,226,224,102,2,223,223,1005,224,434,1001,223,1,223,108,226,677,224,102,2,223,223,1006,224,449,1001,223,1,223,8,677,226,224,102,2,223,223,1006,224,464,1001,223,1,223,1007,677,226,224,1002,223,2,223,1006,224,479,1001,223,1,223,1007,677,677,224,1002,223,2,223,1005,224,494,1001,223,1,223,1107,226,677,224,1002,223,2,223,1006,224,509,101,1,223,223,1108,226,677,224,102,2,223,223,1005,224,524,1001,223,1,223,7,226,226,224,102,2,223,223,1005,224,539,1001,223,1,223,8,677,677,224,1002,223,2,223,1005,224,554,101,1,223,223,107,677,226,224,102,2,223,223,1006,224,569,1001,223,1,223,7,226,677,224,1002,223,2,223,1005,224,584,1001,223,1,223,1008,226,226,224,1002,223,2,223,1006,224,599,101,1,223,223,1108,677,226,224,102,2,223,223,1006,224,614,101,1,223,223,7,677,226,224,102,2,223,223,1005,224,629,1001,223,1,223,8,226,677,224,1002,223,2,223,1006,224,644,101,1,223,223,1007,226,226,224,102,2,223,223,1005,224,659,101,1,223,223,108,677,677,224,1002,223,2,223,1006,224,674,1001,223,1,223,4,223,99,226";
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
                    list[list[i + 1]] = input;
                    i += 2;
                }
                else if (opCode.EndsWith("4"))
                {
                    if(opCode[0] == '1'){
                        outputs.Add(list[i+1]);
                    }else{

                    outputs.Add(list[list[i + 1]]);
                    }
                    i += 2;
                }
                else if (opCode.EndsWith("5"))
                {
                    var newI = JumpIfTrue(list[i], list[i + 1],list[i+2], list);
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
                    var newI = JumpIfFalse(list[i], list[i + 1],list[i+2], list);
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
            if((opCode >= 100 && opCode < 1000) || (opCode > 1000 && opCode - 1000 >= 100))
            {
                return 0 != param1 ? secondValue : -1;
            }
            else
            {
                return 0 != theList[param1] ? secondValue: -1;
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
            if((opCode >= 100 && opCode < 1000) || (opCode > 1000 && opCode - 1000 >= 100))
            {
                return 0 == param1 ? secondValue : -1;
            }
            else
            {
                return 0 == theList[param1] ? secondValue: -1;
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
                return  theList[param1] < secondValue ? 1 : 0;
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
                 return param1 == secondValue? 1 : 0;
            }
            else
            {
                return theList[param1] == secondValue? 1 : 0;
            }
        }
    }
}
