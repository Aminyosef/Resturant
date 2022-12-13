using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.DataBanse
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CatId { get; set; }
        public decimal Price { get; set; }
        public string Note { get; set; }
        public DateTime Created { get; set; }
        public byte[] ItemImage {get;set;}
        [ForeignKey("CatId")]
        public Category Category { get; set; }
    }
}
