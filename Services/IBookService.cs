using Book.Entities;

namespace Book.Services
{
    // Interfaccia IBookService che contiene i metodi da implementare in BookService
    public interface IBookService
    {
        // operazioni di Lettura
        List<Books> GetAll();
        List<Books> GetBooksByCategoryId(int categoryId);
        List<Books> GetBooksByAuthorId(int authorId);
        List<Books> GetBooksByPublisherId(int publisherId);
        Books GetById(int Id);

        // operazioni di Scrittura
        Books Insert(Books b);
        Books Update(Books b);
        Books Delete(int Id);
    }
}