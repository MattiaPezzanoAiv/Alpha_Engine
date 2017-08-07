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
    public class MultipleTransformException:AlphaException
    {

    }
    /// <summary>
    /// Throwed when load a gameobject with the same name of other gameobject alredy loaded.
    /// </summary>
    public class AlredyLoadedObjectException : AlphaException
    {

    }
}
