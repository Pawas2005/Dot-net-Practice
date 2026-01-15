using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public List<string> Skills { get; set; }
    }
}
