using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunicaHealth
{

    public class MasterMenuItem
    {
        public MasterMenuItem()
        {
        }

        public string Title { get; set; }
        public string Icon { get; set; }
        public Type TargetType { get; set; }
    }
}