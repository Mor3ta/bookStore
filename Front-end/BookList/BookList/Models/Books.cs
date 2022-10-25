namespace BookList.Models
{
    public class Books
    {
        public int idBooks { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string sinopsis { get; set; }
        public string idiom { get; set; }
        public int idGenre { get; set; }
        public int pages { get; set; }
        public int idAuthor { get; set; }
    }
    public class BookViewModel
    {
        public List<Books> Books { get; set; }

    }


}
