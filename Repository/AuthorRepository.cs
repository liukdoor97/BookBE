using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Data;
using Book.Entities;

namespace Book.Repository
{
    // Repository AuthorRepository che deriva l'interfaccia IAuthorRepository
    public class AuthorRepository : IAuthorRepository
    {
        // Istanzio il dataContext
        private readonly DataContext dataContext;

        public AuthorRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        // Operazioni di Lettura

        // Metodo che restituisce una lista di Autori
        public List<Author> GetAll()
        {
            var list = dataContext.Authors.ToList();
            if (list == null)
            {
                return null;
            }
            return list;
        }

        // Metodo che restituisce un Autore di un determinato Id
        public Author GetById(int Id)
        {
            var a = dataContext.Authors.FirstOrDefault(a => a.Id == Id);
            if (a == null)
            {
                return null;
            }
            return a;
        }

        // Operazioni di Scrittura

        // Metodo che Inserisce un nuovo Autore
        public Author Insert(Author a)
        {
            if (a != null)
            {
                dataContext.Add<Author>(a);
                int result = dataContext.SaveChanges();
                if (result == 0)
                {
                    return null;

                }
            }
            return a;
        }

        // Metodo che Modifica un Autore
        public Author Update(Author a)
        {
            Author author = this.GetById(a.Id);
            if (a != null)
            {
                dataContext.Update<Author>(author);
                int result = dataContext.SaveChanges();
                if (result == 0)
                {
                    return null;

                }

            }
            return author;
        }

        // Metodo che Elimina un Autore
        public Author Delete(int Id)
        {
            Author a = this.GetById(Id);

            if (a != null)
            {
                dataContext.Remove<Author>(a);
                int result = dataContext.SaveChanges();
                if (result == 0)
                {
                    return null;

                }
            }
            return a;
        }
    }
}