namespace LibraryManagementAPI.DTOs
{
    public class AddBook
    {
        public int AuthorId { get; set; }
        public string BookName { get; set; }

        public int Price { get; set; }
    }
}
