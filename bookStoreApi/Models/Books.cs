using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace bookStoreApi.Models
{
    public class Books
    {
        [Key]
        public int idBooks { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int publication_year { get; set; }
        public int pages { get; set; }
        public string language { get; set; }
        public string book_cover { get; set; }
        public int? authorID { get; set; }
       
    }
}
