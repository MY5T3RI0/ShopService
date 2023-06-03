using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL.Scenarios.Common.Exceptions
{
    public class AbsenceException : Exception
    {
        public AbsenceException(string name, object key)
            : base($"Entity \"{name}\" ({key}) is ended") { }
        
    }
}
