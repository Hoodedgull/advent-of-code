﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace day13
{
    class Program
    {
        static void Main(string[] args)
        {
            var instructions = "2,380,379,385,1008,2655,586506,381,1005,381,12,99,109,2656,1101,0,0,383,1101,0,0,382,21001,382,0,1,21001,383,0,2,21101,37,0,0,1105,1,578,4,382,4,383,204,1,1001,382,1,382,1007,382,42,381,1005,381,22,1001,383,1,383,1007,383,24,381,1005,381,18,1006,385,69,99,104,-1,104,0,4,386,3,384,1007,384,0,381,1005,381,94,107,0,384,381,1005,381,108,1105,1,161,107,1,392,381,1006,381,161,1102,-1,1,384,1105,1,119,1007,392,40,381,1006,381,161,1101,1,0,384,20101,0,392,1,21101,22,0,2,21101,0,0,3,21101,0,138,0,1105,1,549,1,392,384,392,21001,392,0,1,21101,0,22,2,21102,1,3,3,21102,1,161,0,1106,0,549,1102,0,1,384,20001,388,390,1,20101,0,389,2,21101,180,0,0,1106,0,578,1206,1,213,1208,1,2,381,1006,381,205,20001,388,390,1,21002,389,1,2,21101,205,0,0,1106,0,393,1002,390,-1,390,1102,1,1,384,20102,1,388,1,20001,389,391,2,21101,0,228,0,1105,1,578,1206,1,261,1208,1,2,381,1006,381,253,20102,1,388,1,20001,389,391,2,21102,253,1,0,1105,1,393,1002,391,-1,391,1102,1,1,384,1005,384,161,20001,388,390,1,20001,389,391,2,21101,279,0,0,1106,0,578,1206,1,316,1208,1,2,381,1006,381,304,20001,388,390,1,20001,389,391,2,21102,304,1,0,1105,1,393,1002,390,-1,390,1002,391,-1,391,1101,1,0,384,1005,384,161,20102,1,388,1,21002,389,1,2,21101,0,0,3,21101,0,338,0,1105,1,549,1,388,390,388,1,389,391,389,20101,0,388,1,20101,0,389,2,21101,4,0,3,21102,365,1,0,1105,1,549,1007,389,23,381,1005,381,75,104,-1,104,0,104,0,99,0,1,0,0,0,0,0,0,258,19,19,1,1,21,109,3,22102,1,-2,1,22101,0,-1,2,21102,0,1,3,21101,0,414,0,1106,0,549,22101,0,-2,1,21202,-1,1,2,21102,1,429,0,1105,1,601,2102,1,1,435,1,386,0,386,104,-1,104,0,4,386,1001,387,-1,387,1005,387,451,99,109,-3,2105,1,0,109,8,22202,-7,-6,-3,22201,-3,-5,-3,21202,-4,64,-2,2207,-3,-2,381,1005,381,492,21202,-2,-1,-1,22201,-3,-1,-3,2207,-3,-2,381,1006,381,481,21202,-4,8,-2,2207,-3,-2,381,1005,381,518,21202,-2,-1,-1,22201,-3,-1,-3,2207,-3,-2,381,1006,381,507,2207,-3,-4,381,1005,381,540,21202,-4,-1,-1,22201,-3,-1,-3,2207,-3,-4,381,1006,381,529,21202,-3,1,-7,109,-8,2105,1,0,109,4,1202,-2,42,566,201,-3,566,566,101,639,566,566,1202,-1,1,0,204,-3,204,-2,204,-1,109,-4,2105,1,0,109,3,1202,-1,42,594,201,-2,594,594,101,639,594,594,20102,1,0,-2,109,-3,2105,1,0,109,3,22102,24,-2,1,22201,1,-1,1,21101,0,509,2,21101,0,167,3,21101,1008,0,4,21102,1,630,0,1105,1,456,21201,1,1647,-2,109,-3,2105,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,2,2,2,0,2,2,2,0,0,0,2,2,2,2,2,0,2,2,0,2,2,0,0,2,2,0,0,2,2,2,0,0,2,0,0,2,0,1,1,0,0,2,0,2,2,2,2,0,0,0,0,0,2,0,0,2,0,0,2,0,2,0,0,0,2,2,2,2,0,2,2,2,2,0,2,0,0,0,0,1,1,0,0,2,2,0,0,0,2,2,2,2,2,0,0,2,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,2,2,0,2,0,2,2,0,2,0,1,1,0,0,2,0,0,2,2,0,0,0,0,0,0,2,2,0,0,2,2,0,0,0,0,2,0,2,0,0,0,0,2,0,2,0,0,0,2,0,0,0,1,1,0,2,0,2,2,0,0,0,0,0,2,0,0,0,0,2,0,2,2,0,0,0,0,2,0,2,0,2,2,0,2,0,2,0,2,2,2,2,0,0,1,1,0,0,0,2,2,0,2,0,0,0,0,0,0,0,0,0,0,2,2,0,0,2,0,0,0,2,2,2,2,2,0,2,0,0,2,2,0,0,0,0,1,1,0,0,0,0,0,2,0,0,0,0,2,0,2,0,0,0,2,2,2,2,0,2,0,0,0,2,0,0,2,0,0,0,0,2,0,0,0,0,2,0,1,1,0,0,0,0,0,2,0,0,0,2,2,0,0,0,2,0,0,2,2,2,2,0,2,2,2,0,2,2,0,2,0,2,0,0,0,2,0,0,0,0,1,1,0,0,0,2,2,0,0,2,2,2,2,0,0,0,2,2,0,2,2,0,2,0,0,2,2,2,0,0,0,2,0,0,0,2,0,2,0,2,0,0,1,1,0,2,0,0,2,0,0,2,2,2,0,0,2,2,2,0,2,0,2,0,2,0,0,2,0,2,2,0,2,2,2,0,2,0,0,2,2,2,0,0,1,1,0,0,0,0,0,2,0,2,2,2,2,0,0,0,0,0,0,0,0,2,0,0,0,2,2,2,0,2,0,0,0,2,0,0,2,0,0,0,0,0,1,1,0,2,2,2,2,0,0,2,0,2,0,0,0,2,2,0,2,0,0,0,0,2,2,0,2,0,2,0,0,2,2,0,0,2,0,2,0,2,0,0,1,1,0,0,2,0,2,0,2,0,0,2,0,2,0,0,2,0,0,0,2,2,2,2,0,2,0,2,0,0,0,0,0,2,0,0,0,0,2,0,0,0,1,1,0,0,0,0,0,0,2,0,0,2,2,0,2,2,0,2,2,0,2,0,2,0,2,0,0,2,2,0,2,2,0,0,0,2,2,2,2,2,0,0,1,1,0,2,0,0,0,2,2,0,0,2,0,0,0,2,2,0,2,2,2,0,0,0,0,0,0,0,0,0,2,0,2,2,2,0,0,0,2,2,0,0,1,1,0,0,0,0,2,0,0,2,0,2,0,2,2,0,0,0,2,2,2,0,2,0,2,0,0,2,2,2,0,0,0,0,0,2,0,0,0,2,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,70,46,59,22,22,4,89,60,87,72,55,22,68,21,13,13,32,82,19,23,29,72,22,9,44,63,53,45,9,52,76,55,54,64,20,16,54,2,23,40,58,72,19,18,10,85,70,13,48,97,6,39,20,79,27,32,43,12,20,48,17,15,22,63,67,94,36,18,67,68,85,78,16,93,35,27,29,11,60,21,80,17,9,85,82,39,73,46,40,54,43,22,11,32,10,29,97,51,93,71,16,24,86,81,42,29,21,41,85,48,5,44,74,11,35,95,39,96,92,15,77,42,50,35,25,39,44,2,64,74,70,21,84,70,26,11,70,41,23,39,36,71,37,71,31,60,98,6,4,77,48,95,75,44,33,40,66,91,48,15,5,12,95,28,81,22,19,38,88,68,37,56,25,33,15,38,22,31,91,82,63,59,57,20,44,18,72,29,86,58,77,1,67,49,65,48,11,72,70,53,44,40,66,87,4,33,71,47,23,81,54,30,3,54,30,90,2,4,51,73,30,47,23,37,47,32,51,91,1,97,60,60,11,82,68,1,68,9,78,88,96,10,24,46,76,46,71,28,78,9,81,97,72,73,98,71,81,72,66,17,41,55,41,73,4,19,2,9,71,52,84,96,91,17,9,80,95,83,77,51,68,12,70,16,31,14,67,28,2,65,98,41,19,6,56,91,95,55,14,14,24,17,78,87,43,51,31,94,87,73,98,34,37,5,64,87,30,81,4,36,10,65,80,46,78,46,5,52,54,94,54,35,23,84,75,74,72,3,10,39,27,24,31,68,43,51,44,55,46,66,4,18,65,86,59,33,11,68,87,25,36,13,14,10,11,16,26,9,12,36,12,34,23,52,37,68,91,3,74,90,74,35,46,46,49,97,59,5,12,90,52,50,34,9,59,23,87,42,75,90,91,79,64,38,40,30,28,52,6,96,30,35,35,74,61,17,77,98,90,62,4,55,31,31,57,40,6,20,17,27,3,62,23,70,73,12,17,20,13,64,27,15,20,52,55,72,95,92,61,5,87,20,57,61,68,17,34,69,16,14,30,89,74,40,39,73,80,15,85,95,45,6,66,24,11,80,64,25,68,76,61,92,24,17,21,73,54,50,11,62,18,77,52,14,92,40,44,86,68,44,2,57,98,73,69,86,91,4,32,24,74,73,12,51,65,91,8,37,83,95,64,41,17,76,55,53,47,34,42,85,11,97,93,51,55,82,61,6,48,12,28,33,42,54,12,4,70,76,70,47,35,65,73,79,64,7,95,80,30,94,67,83,63,40,52,96,60,42,21,48,81,84,8,44,37,4,38,22,72,40,82,48,29,71,48,55,98,63,97,89,17,42,4,90,72,9,48,83,54,62,48,39,14,16,74,8,96,10,73,15,8,46,78,27,1,98,18,87,79,76,45,49,58,11,27,60,54,91,75,88,78,21,24,91,68,51,10,65,71,3,32,33,36,42,41,46,24,54,34,76,74,46,81,95,49,29,6,14,88,38,92,39,15,9,55,58,43,93,74,92,81,35,3,57,72,17,3,14,18,82,41,32,76,69,17,92,35,7,75,60,21,77,20,65,11,98,75,38,59,94,33,24,27,41,96,34,27,14,14,49,50,95,10,9,85,63,32,55,41,27,48,56,98,51,3,30,24,61,35,35,45,40,75,94,87,28,32,74,58,3,13,17,97,78,92,18,37,89,90,54,94,43,76,39,32,17,61,73,15,46,28,22,90,9,58,27,55,56,58,45,70,58,67,35,35,89,68,54,70,53,93,14,31,78,75,85,58,8,37,6,58,58,43,20,33,68,92,75,32,15,48,37,28,15,98,15,61,87,15,6,93,83,79,93,68,83,70,93,5,7,9,97,65,7,59,24,37,66,37,43,79,55,47,70,12,52,74,28,92,70,66,11,10,57,57,1,81,18,42,73,88,52,90,92,33,63,48,52,44,63,87,30,86,98,20,88,27,34,57,64,79,18,85,31,63,46,45,27,20,26,96,7,13,27,19,73,50,47,81,98,95,56,40,57,23,18,31,58,37,36,52,40,47,72,31,25,42,3,16,15,51,97,93,72,74,27,68,42,33,12,80,84,24,66,64,13,48,11,54,51,52,19,82,6,56,94,60,85,1,54,82,94,71,73,9,43,27,47,13,44,30,96,83,54,67,80,12,32,46,96,61,54,62,27,40,22,40,85,33,18,7,88,80,89,10,43,66,79,87,94,51,95,52,83,47,14,89,26,69,93,83,98,92,76,62,10,81,33,39,5,81,80,10,49,10,53,72,48,586506";
            var icc = new IntCodeComputer(instructions);

            var score = 0;
            var input = 0;
            (int, int) paddlePos = (0, 0);
            (int, int) ballPos = (0, 0);

            while (true)
            {
                icc.RunIntcode(input);



                var tiles = new List<Tile>();

                for (int i = 0; i < icc.Outputs.Count; i += 3)
                {
                    var x = icc.Outputs[i];
                    var y = icc.Outputs[i + 1];
                    var type = icc.Outputs[i + 2];

                    if (x == -1 && y == 0)
                    {
                        score = (int)type;
                    }
                    else
                    {
                        if (type == 4)
                        {
                            ballPos = ((int)x, (int)y);
                        }
                        if (type == 3)
                        {
                            paddlePos = ((int)x, (int)y);
                        }

                        tiles.Add(new Tile
                        {
                            Location = ((int)x, (int)y),
                            Type = (int)type
                        });
                    }

                }


                var screen = tiles.GroupBy(tile => tile.Location.Item2).OrderBy(group => group.Key).Select(row => row.OrderBy(tile => tile.Location.Item1).Select(tile => tile.Type)).ToList();
                var chars = string.Join('\n', screen.Select(row => string.Join("", row)));
                System.Console.WriteLine(chars);

                System.Console.WriteLine(chars.Count(c => c == '2'));

                if (icc.State == "HALTED")
                {
                    break;
                }
                else
                {
                    if (paddlePos.Item1 < ballPos.Item1)
                    {
                        input = 1;
                    }
                    else if (paddlePos.Item1 > ballPos.Item1)
                    {
                        input = -1;
                    }
                    else
                    {
                        input = 0;
                    }
                }
            }
            ;
        }
    }
}
