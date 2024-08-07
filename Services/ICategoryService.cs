using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Entities;

namespace Book.Services
{
    // Interfaccia ICategoryService che contiene i metodi da implementare in CategoryService
    public interface ICategoryService
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