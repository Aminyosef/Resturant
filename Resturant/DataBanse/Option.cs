using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.DataBanse
{
    public class Option
    {
        public int Id { get; set; }
        public string RestName { get; set; }
        public string PrintName { get; set; }
        public string RestPhone { get; set; }
        public string RestAdd1 { get; set; }
        public string RestAdd2 { get; set; }
        public byte[] RestLogo { get; set; }
    }
}
