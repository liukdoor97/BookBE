using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Entities;

namespace Book.Services
{
    // Interfaccia IAuthorService che contiene i metodi da implementare in AuthorService
    public interface IAuthorService
    {
        // operazioni di Lettura
        List<Author> GetAll();
        Author GetById(int Id);

        // operazioni di Scrittura
        Author Insert(Author a);
        Author Update(Author a);
        Author Delete(int Id);

    }
}