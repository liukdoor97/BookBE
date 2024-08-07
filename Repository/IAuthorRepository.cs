using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Entities;

namespace Book.Repository
{
    // Interfaccia IAuthorRepository che contiene i Metodi da implementare in AuthorRepository
    public interface IAuthorRepository
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