using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeBloge.Application.Generators
{
    public static class CodeGenerators
    {
        public static string CreateActivationCode()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
