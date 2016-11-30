using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wichtel.Common;

namespace Wichtel.Data
{
    public class Repository : IRepository
    {
        public User LookupWinner()
        {
            return new User{ Who = "@writeline", What = "Yep, it is me!" };
        }
    }
}
