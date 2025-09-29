using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

using (PubContext context = new PubContext())
{
    context.Database.EnsureCreated();
    Console.WriteLine("Database created (if it did not exist).");
}

//AddAuthor();
GetAuthors();
//AddAuthorWithBooks();
GetAuthorsWithBooks();

void GetAuthorsWithBooks()
{
    using var context = new PubContext();
    var authorsWthBooks = context.Authors.Include(a => a.Books).ToList();
    foreach (var author in authorsWthBooks)
    {
        Console.WriteLine($"{author.FirstName} {author.LastName} : ");
        if(author.Books == null || author.Books.Count == 0)
        {
            Console.WriteLine("None!!");
            continue;
        }

        foreach(var book in author.Books)
        {
            Console.WriteLine($"{book.Title} (Published at {book.PublishDate})");
        }
    }
}

void AddAuthorWithBooks()
{
    var author = new Author { FirstName = "J.K.", LastName = "Rowling" };
    author.Books.Add(new Book { Title = "Harry potter and the philosophers stone", PublishDate = new DateOnly(2001, 10, 2) });
    author.Books.Add(new Book { Title = "Harry potter and the half blood prince", PublishDate = new DateOnly(2009, 04, 25) });

    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}

void AddAuthor()
{
    var author1 = new Author { FirstName = "Dan", LastName = "Brown" };
    var author2 = new Author { FirstName = "Agatha", LastName = "Christie" };
    var author3 = new Author { FirstName = "Stephen", LastName = "King" };
    using var context = new PubContext();
    context.Authors.Add(author1);
    context.Authors.Add(author2);
    context.Authors.Add(author3);
    context.SaveChanges();
}

void GetAuthors()
{
    using var context = new PubContext();
    var authors = context.Authors.ToList();
    foreach (var author in authors)
    {
        Console.WriteLine($"{author.Id} : {author.FirstName} {author.LastName}");
    }
}