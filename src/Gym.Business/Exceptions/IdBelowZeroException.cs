using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Exceptions
{
    public class IdBelowZeroException:Exception
    {
        public IdBelowZeroException()
        {
            
        }
        public IdBelowZeroException(string? message) : base(message)
        {
        }
        public IdBelowZeroException(string propertyName,string? message) : base(message)
        {
            PropertyName = propertyName;
        }


        public string PropertyName {  get; set; }

    }
}
