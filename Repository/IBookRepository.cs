using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Entities;

namespace Book.Repository
{
    // Interfaccia IBookRepository che contiene i Metodi da implementare in BookRepository
    public interface IBookRepository
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