using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL.Scenarios.Common.Exceptions
{
    public class NotEnoughProductException : Exception
    {
        public NotEnoughProductException(string name, object key)
            : base($"Not enough \"{name}\" ({key}) at store") { }
        
    }
}
