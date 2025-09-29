using PublisherData;
using PublisherDomain;

using (PubContext context = new PubContext())
{
    context.Database.EnsureCreated();
    Console.WriteLine("Database created (if it did not exist).");
}

AddAuthor();
GetAuthors();

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