using System;
using System.Collections.Generic;
using System.Linq;

namespace day7{
    public class IntCodeComputer{
        private readonly string instructions;
        private List<int> list;

        private int programPointer;

        public string State {get;set;}
        public List<int> Outputs{get;set;}

        public IntCodeComputer(string instructions){
            this.instructions = instructions;
            list = instructions.Split(',').Select(word => int.Parse(word)).ToList();
            programPointer = 0;
            State = "NEW";
            Outputs = new List<int>();
        }
        public void RunIntcode(int? input)
        {
            State = "RUNNING";
            while (programPointer >= 0)
            {
                
                string opCode = list[programPointer].ToString();
                if (opCode.EndsWith("1"))
                {
                    list[list[programPointer + 3]] = addNumbers(list[programPointer], list[programPointer + 1], list[programPointer + 2], list);
                    programPointer += 4;
                }
                else if (opCode.EndsWith("2"))
                {
                    list[list[programPointer + 3]] = multiplyNumbers(list[programPointer], list[programPointer + 1], list[programPointer + 2], list);
                    programPointer += 4;
                }
                else if (opCode.EndsWith("3"))
                {
                    if(input.HasValue){
                    list[list[programPointer + 1]] = input.Value;
                    programPointer += 2;
                    input = null;
                    }else{
                        State = "WAITING";
                        break;
                    }
                }
                else if (opCode.EndsWith("4"))
                {
                    if (opCode[0] == '1')
                    {
                        Outputs.Add(list[programPointer + 1]);
                    }
                    else
                    {

                        Outputs.Add(list[list[programPointer + 1]]);
                    }
                    programPointer += 2;
                }
                else if (opCode.EndsWith("5"))
                {
                    var newI = JumpIfTrue(list[programPointer], list[programPointer + 1], list[programPointer + 2], list);
                    if (newI < 0)
                    {
                        programPointer += 3;
                    }
                    else
                    {
                        programPointer = newI;
                    }
                }
                else if (opCode.EndsWith("6"))
                {
                    var newI = JumpIfFalse(list[programPointer], list[programPointer + 1], list[programPointer + 2], list);
                    if (newI < 0)
                    {
                        programPointer += 3;
                    }
                    else
                    {
                        programPointer = newI;
                    }
                }
                else if (opCode.EndsWith("7"))
                {
                    list[list[programPointer + 3]] = LessThan(list[programPointer], list[programPointer + 1], list[programPointer + 2], list);
                    programPointer += 4;
                }
                else if (opCode.EndsWith("8"))
                {
                    list[list[programPointer + 3]] = Equals(list[programPointer], list[programPointer + 1], list[programPointer + 2], list);
                    programPointer += 4;
                }
                else if (opCode.EndsWith("99"))
                {
                    State = "HALTED";
                    break;
                }
                else
                {
                    throw new Exception();
                }

            }


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