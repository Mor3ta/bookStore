namespace BookList.Models
{
    public class Author
    {
        public int idAuthor { get; set; }
        public string name { get; set; }
        public string bio { get; set; }
        public List<object> books { get; set; }
    }

    public class AuthorViewModel
    {
        public List<Author> Authors { get; set; }

    }
}
