using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC_CoilOperation
{
    internal class COIL_info
    {
        private int x;
        private int y;
        private int z;
        private int total;

        public void SetValue(int px, int py, int pz)
        {
            x = px;
            y = py;
            z = pz;
            total = x + y + z;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public int GetZ()
        {
            return z;
        }

        public int GetTotal()
        {
            return total;
        }
    }
}
