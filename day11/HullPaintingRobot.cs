using System.Collections.Generic;

namespace day11
{
    class HullPaintingRobot
    {

        public Dictionary<(int, int), char> environment { get; set; }
        private (int, int) Location { get; set; }

        private (int, int) Direction { get; set; }

        public HullPaintingRobot()
        {
            environment = new Dictionary<(int, int), char>();
            Direction = (0, 1);
            Location = (0, 0);
            environment[Location] = '#';
        }

        public void Move()
        {
            Location = (Location.Item1 + Direction.Item1, Location.Item2 + Direction.Item2);
        }

        public void Turn(long dir)
        {
            if (dir == 0)
            {
                TurnLeft();
            }
            else
            {
                TurnRight();
            }
        }

        private void TurnLeft()
        {
            if (Direction.Equals((0, 1)))
                Direction = (-1, 0);
            else if (Direction.Equals((-1, 0)))
                Direction = (0, -1);
            else if (Direction.Equals((0, -1)))
                Direction = (1, 0);
            else if (Direction.Equals((1, 0)))
                Direction = (0, 1);
            else
                throw new System.Exception();
        }

        private void TurnRight()
        {
            if (Direction.Equals((0, 1)))
                Direction = (1, 0);
            else if (Direction.Equals((-1, 0)))
                Direction = (0, 1);
            else if (Direction.Equals((0, -1)))
                Direction = (-1, 0);
            else if (Direction.Equals((1, 0)))
                Direction = (0, -1);
            else
                throw new System.Exception();
        }


        public int GetColorCodeOfLocation()
        {
            return GetColorCodeOfLocation(Location);
        }

        public int GetColorCodeOfLocation((int, int) loc)
        {
            if (environment.TryGetValue(loc, out char color))
            {
                return ConvertColor(color);
            }
            else
            {
                return 0;
            }
        }

        public char GetColorOfLocation((int, int) loc){
            return ConvertColorCode(GetColorCodeOfLocation(loc));
        }

        public void PaintLocation(int colorCode)
        {
            environment[Location] = ConvertColorCode(colorCode);

        }

        private int ConvertColor(char color)
        {
            switch (color)
            {
                case '.': return 0;
                case '#': return 1;
                default: return 0;
            }
        }

        private char ConvertColorCode(int colorCode)
        {
            switch (colorCode)
            {
                case 0: return '.';
                case 1: return '#';
                default: return '.';
            }
        }
    }
}