using System;
using System.Collections.Generic;

namespace LibraryManagementAPI.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string BookName { get; set; } = null!;

    public int AuthorId { get; set; }

    public int Price { get; set; }

    public virtual Author Author { get; set; } = null!;
}
