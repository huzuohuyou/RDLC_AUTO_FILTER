using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InhospitalIndicators.Service
{

    public static class Expand
    {
        public static double ToDouble(this string str)
        {
            var value = 0.0d;
            if (double.TryParse(str, out value))
            {
                return value;
            }
            return 0;
        }

        
    }
}
