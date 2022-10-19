
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace books_store.Models
{
    public class Store
    {
        [Key]
        public int idStore { get; set; }
        public string store { get; set; }
        public string address { get; set; }
        public string phone { get; set; }



    }
}