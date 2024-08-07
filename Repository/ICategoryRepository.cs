using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Entities;

namespace Book.Repository
{
    // Interfaccia ICategoryRepository che contiene i Metodi da implementare in CategoryRepository
    public interface ICategoryRepository
    {
        // operazioni di Lettura
        List<Categories> GetAll();
        Categories GetById(int Id);

        // operazioni di Scrittura
        Categories Insert(Categories c);
        Categories Update(Categories c);
        Categories Delete(int Id);
    }
}