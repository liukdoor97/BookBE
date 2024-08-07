using Book.Data;
using Book.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book.Repository
{
    // Repository BookRepository che deriva l'interfaccia IBookRepository
    public class BookRepository : IBookRepository
    {
        // Istanzio il dataContext
        private readonly DataContext dataContext;

        public BookRepository(DataContext DataContext)
        {
            this.dataContext = DataContext;
        }

        // Operazioni di Lettura

        // Metodo che restituisce una lista di Libri
        public List<Books> GetAll()
        {
            var list = dataContext.Books
                             .Include(b => b.Category)
                             .Include(b => b.Author)
                             .Include(b => b.Publisher)
                             .ToList();

            var books = list.Select(b => new Books
            {
                Id = b.Id,
                title = b.title,
                year = b.year,
                CategoryId = b.CategoryId,
                Category = b.Category != null ? new Categories
                {
                    Id = b.Category.Id,
                    name = b.Category.name
                } : null,
                AuthorId = b.AuthorId,
                Author = b.Author != null ? new Author
                {
                    Id = b.Author.Id,
                    name = b.Author.name,
                    lastName = b.Author.lastName,
                    address = b.Author.address,
                    country = b.Author.country
                } : null,
                PublisherId = b.PublisherId,
                Publisher = b.Publisher != null ? new Publisher
                {
                    Id = b.Publisher.Id,
                    name = b.Publisher.name,
                    address = b.Publisher.address,
                    country = b.Publisher.country
                } : null
            }).ToList();


            if (list == null)
            {
                return null;
            }
            return list;

        }

        // Metodo che restituisce una lista di Libri di un determinato categoryId

        public List<Books> GetBooksByCategoryId(int categoryId)
        {
            var list = (from b in dataContext.Books
                        join c in dataContext.Categories on b.Category.Id equals c.Id
                        where c.Id == categoryId
                        select new Books
                        {
                            Id = b.Id,
                            title = b.title,
                            year = b.year,
                            CategoryId = categoryId,
                            Category = new Categories
                            {
                                Id = c.Id,
                                name = c.name
                            },
                            AuthorId = b.AuthorId,
                            Author = b.Author != null ? new Author
                            {
                                Id = b.Author.Id,
                                name = b.Author.name,
                                lastName = b.Author.lastName,
                                address = b.Author.address,
                                country = b.Author.country
                            } : null,
                            PublisherId = b.PublisherId,
                            Publisher = b.Publisher != null ? new Publisher
                            {
                                Id = b.Publisher.Id,
                                name = b.Publisher.name,
                                address = b.Publisher.address,
                                country = b.Publisher.country
                            } : null
                        }).ToList();

            return list;
        }

        // Metodo che restituisce una lista di Libri di un determinato authorId
        public List<Books> GetBooksByAuthorId(int authorId)

        {
            var list = (from b in dataContext.Books
                        join a in dataContext.Authors on b.Author.Id equals a.Id
                        where a.Id == authorId
                        select new Books
                        {
                            Id = b.Id,
                            title = b.title,
                            year = b.year,
                            CategoryId = b.CategoryId,
                            Category = new Categories
                            {
                                Id = b.Category.Id,
                                name = b.Category.name
                            },
                            AuthorId = authorId,
                            Author = b.Author != null ? new Author
                            {
                                Id = a.Id,
                                name = a.name,
                                lastName = a.lastName,
                                address = a.address,
                                country = a.country
                            } : null,
                            PublisherId = b.PublisherId,
                            Publisher = b.Publisher != null ? new Publisher
                            {
                                Id = b.Publisher.Id,
                                name = b.Publisher.name,
                                address = b.Publisher.address,
                                country = b.Publisher.country
                            } : null
                        }).ToList();

            return list;
        }

        // Metodo che restituisce una lista di Libri di un determinato publisherId
        public List<Books> GetBooksByPublisherId(int publisherId)
        {
            var list = (from b in dataContext.Books
                        join p in dataContext.Publishers on b.Publisher.Id equals p.Id
                        where p.Id == publisherId
                        select new Books
                        {
                            Id = b.Id,
                            title = b.title,
                            year = b.year,
                            CategoryId = b.CategoryId,
                            Category = new Categories
                            {
                                Id = b.Category.Id,
                                name = b.Category.name
                            },
                            AuthorId = b.AuthorId,
                            Author = b.Author != null ? new Author
                            {
                                Id = b.Author.Id,
                                name = b.Author.name,
                                lastName = b.Author.lastName,
                                address = b.Author.address,
                                country = b.Author.country
                            } : null,
                            PublisherId = publisherId,
                            Publisher = b.Publisher != null ? new Publisher
                            {
                                Id = p.Id,
                                name = p.name,
                                address = p.address,
                                country = p.country
                            } : null
                        }).ToList();

            return list;
        }

        // Metodo che restituisce un Libro di un determinato Id
        public Books GetById(int Id)
        {

            var b = dataContext.Books.FirstOrDefault(b => b.Id == Id);
            if (b == null)
            {
                return null;
            }
            return b;

        }

        // Operazioni di Scrittura

        // Metodo che Inserisce un nuovo Libro

        public Books Insert(Books b)
        {

            if (b != null)
            {
                dataContext.Add<Books>(b);
                int result = dataContext.SaveChanges();
                if (result == 0)
                {
                    return null;

                }
            }
            return b;


        }

        // Metodo che Modifica un Libro
        public Books Update(Books b)
        {
            Books book = this.GetById(b.Id);
            if (b != null)
            {
                dataContext.Update<Books>(book);
                int result = dataContext.SaveChanges();
                if (result == 0)
                {
                    return null;

                }

            }
            return book;
        }

        // Metodo che Elimina un Libro
        public Books Delete(int Id)
        {
            Books book = this.GetById(Id);

            if (book != null)
            {
                dataContext.Remove<Books>(book);
                int result = dataContext.SaveChanges();
                if (result == 0)
                {
                    return null;

                }
            }
            return book;
        }
    }
}