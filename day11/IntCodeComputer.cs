using System;
using System.Collections.Generic;
using System.Linq;

namespace day11
{
    public class IntCodeComputer
    {
        private readonly string instructions;
        private List<long> list;

        private int programPointer;

        private long relativeBase;

        public string State { get; set; }
        public List<long> Outputs { get; set; }

        public IntCodeComputer(string instructions)
        {
            this.instructions = instructions;
            list = instructions.Split(',').Select(word => long.Parse(word)).ToList();
            programPointer = 0;
            relativeBase = 0;
            State = "NEW";
            Outputs = new List<long>();
        }
        public void RunIntcode(long? input)
        {
            State = "RUNNING";
            while (programPointer >= 0)
            {

                string opCode = list[programPointer].ToString("D5");
                if (opCode.EndsWith("1"))
                {
                    var newValue = addNumbers((int)list[programPointer], list[programPointer + 1], list[programPointer + 2], list);
                    MutateList(opCode[0], list[programPointer + 3], newValue, list);
                    programPointer += 4;
                }
                else if (opCode.EndsWith("2"))
                {
                    var newValue = multiplyNumbers((int)list[programPointer], list[programPointer + 1], list[programPointer + 2], list);
                    MutateList(opCode[0], list[programPointer + 3], newValue, list);
                    programPointer += 4;
                }
                else if (opCode.EndsWith("3"))
                {
                    if (input.HasValue)
                    {
                        MutateList(opCode[2], list[programPointer + 1], input.Value, list);
                        programPointer += 2;
                        input = null;
                    }
                    else
                    {
                        State = "WAITING";
                        break;
                    }
                }
                else if (opCode.EndsWith("4"))
                {

              
                    Outputs.Add(AccessList(opCode[2], list[programPointer + 1], list));

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
                    var newValue = LessThan(list[programPointer], list[programPointer + 1], list[programPointer + 2], list);
                    MutateList(opCode[0], list[programPointer + 3], newValue, list);

                    programPointer += 4;
                }
                else if (opCode.EndsWith("8"))
                {
                    var newValue = Equals(list[programPointer], list[programPointer + 1], list[programPointer + 2], list);
                    MutateList(opCode[0], list[programPointer + 3], newValue, list);
                    programPointer += 4;
                }
                else if (opCode.EndsWith("99"))
                {
                    State = "HALTED";
                    break;
                }
                else if (opCode.EndsWith("9"))
                {

                    relativeBase += AccessList(opCode[2], list[programPointer + 1], list);

                    programPointer += 2;
                }
                else
                {
                    throw new Exception();
                }

            }

            
        }

        private long addNumbers(long opCode, long param1, long param2, List<long> theList)
        {
            var opString = opCode.ToString("D5");
            var sum = AccessList(opString[1], param2, theList);

            sum += AccessList(opString[2], param1, theList);
            return sum;
        }

        private long AccessList(char mode, long param, List<long> theList)
        {
            int index = 0;
            if (mode == '2')
            {
                index = (int)(relativeBase + param);
            }
            else if (mode == '1')
            {
                return param;
            }
            else
            {
                index = (int)param;
            }

            while (index >= theList.Count)
            {
                theList.Add(0);
            }

            return theList[index];
        }

        private void MutateList(char mode, long param, long newValue, List<long> theList)
        {

            int index = 0;
            if (mode == '2')
            {
                index = (int)(relativeBase + param);
            }
            else if (mode == '1')
            {
                throw new Exception();
            }
            else
            {
                index = (int)param;
            }

            while (index >= theList.Count)
            {
                theList.Add(0);
            }

            theList[index] = newValue;
        }

        private long multiplyNumbers(long opCode, long param1, long param2, List<long> theList)
        {

            var opString = opCode.ToString("D5");
            var sum = AccessList(opString[1], param2, theList);

            sum *= AccessList(opString[2], param1, theList);
            return sum;
        }

        private int JumpIfTrue(long opCode, long param1, long param2, List<long> theList)
        {

            var opString = opCode.ToString("D5");
            var first = AccessList(opString[2], param1, theList);
            var secondValue = AccessList(opString[1], param2, theList);
            return 0L != first ? (int)secondValue : -1;

        }

        private int JumpIfFalse(long opCode, long param1, long param2, List<long> theList)
        {

          var opString = opCode.ToString("D5");
            var first = AccessList(opString[2], param1, theList);
            var secondValue = AccessList(opString[1], param2, theList);
            return 0 == first ? (int)secondValue : -1;


        }

        private long LessThan(long opCode, long param1, long param2, List<long> theList)
        {
          var opString = opCode.ToString("D5");
            var first = AccessList(opString[2], param1, theList);
            var secondValue = AccessList(opString[1], param2, theList);
            return first < secondValue ? 1 : 0;

        }

        private int Equals(long opCode, long param1, long param2, List<long> theList)
        {
           var opString = opCode.ToString("D5");
            var first = AccessList(opString[2], param1, theList);
            var secondValue = AccessList(opString[1], param2, theList);
            return first == secondValue ? 1 : 0;

        }

    }
}