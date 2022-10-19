using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookStoreApi.Models
{
    public class Author
    {
        [Key]
        public int IdAuthor { get; set; }
        public string ?Author_Name { get; set; }
        public string ?Biography { get; set; }
      
      
     
    }
}
