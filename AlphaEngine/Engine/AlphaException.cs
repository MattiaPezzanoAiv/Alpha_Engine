using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaEngine
{
    public class AlphaException:Exception
    {
        public AlphaException(string message)
        {

        }
        public AlphaException()
        {

        }
    }
    public class NotAComponentException : AlphaException
    {

    }
    public class RedundantFatherException:AlphaException
    {

    }
}
