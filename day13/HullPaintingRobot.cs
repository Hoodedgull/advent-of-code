using System.Collections.Generic;

namespace day13
{
    class Tile
    {

        public (int, int) Location { get; set; }

        public int Type;

        public Tile()
        {
    
            Location = (0, 0);
        }

       
    }
}