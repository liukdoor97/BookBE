using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Data;
using Book.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book.Repository
{
    // Repository CategoryRepository che deriva l'interfaccia ICategoryRepository
    public class CategoryRepository : ICategoryRepository
    {
        // Istanzio il dataContext
        private readonly DataContext dataContext;

        public CategoryRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        // Operazioni di Lettura

        // Metodo che restituisce una lista di Categorie

        public List<Categories> GetAll()
        {
            var list = dataContext.Categories.ToList();
            if (list == null)
            {
                return null;
            }
            return list;
        }

        // Metodo che restituisce una Categorie di un determinato Id
        public Categories GetById(int Id)
        {
            var c = dataContext.Categories.FirstOrDefault(c => c.Id == Id);
            if (c == null)
            {
                return null;
            }
            return c;
        }

        // Operazioni di Scrittura

        // Metodo che Inserisce una nuova Categoria
        public Categories Insert(Categories c)
        {

            if (c != null)
            {
                dataContext.Add<Categories>(c);
                int result = dataContext.SaveChanges();
                if (result == 0)
                {
                    return null;

                }
            }
            return c;
        }

        // Metodo che Modifica una Categoria

        public Categories Update(Categories c)
        {
            Categories category = this.GetById(c.Id);
            if (c != null)
            {
                dataContext.Update<Categories>(category);
                int result = dataContext.SaveChanges();
                if (result == 0)
                {
                    return null;

                }

            }
            return category;
        }

        // Metodo che Elimina una Categoria

        public Categories Delete(int Id)
        {
            Categories c = this.GetById(Id);

            if (c != null)
            {
                dataContext.Remove<Categories>(c);
                int result = dataContext.SaveChanges();
                if (result == 0)
                {
                    return null;

                }
            }
            return c;
        }

    }
}