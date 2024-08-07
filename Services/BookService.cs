using Book.Entities;
using Book.Repository;

namespace Book.Services
{
    // Classe BookService che deriva da IBookService
    public class BookService : IBookService
    {
        // istanzio bookRepository
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository _bookRepository)
        {
            this.bookRepository = _bookRepository;
        }

        // operazioni di Lettura

        public List<Books> GetAll()
        {
            return bookRepository.GetAll();

        }
        public List<Books> GetBooksByCategoryId(int categoryId)
        {
            return bookRepository.GetBooksByCategoryId(categoryId);
        }
        public List<Books> GetBooksByAuthorId(int authorId)
        {
            return bookRepository.GetBooksByAuthorId(authorId);
        }
        public List<Books> GetBooksByPublisherId(int publisherId)
        {
            return bookRepository.GetBooksByPublisherId(publisherId);
        }

        public Books GetById(int Id)
        {
            return bookRepository.GetById(Id);
        }

        // operazioni di Scrittura

        public Books Insert(Books b)
        {
            return bookRepository.Insert(b);
        }
        public Books Update(Books b)
        {
            return bookRepository.Update(b);
        }
        public Books Delete(int Id)
        {
            return bookRepository.Delete(Id);
        }
    }
}