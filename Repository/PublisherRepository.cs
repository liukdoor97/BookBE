using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Data;
using Book.Entities;

namespace Book.Repository
{
    // Repository PublisherRepository che deriva l'interfaccia IPublisherRepository
    public class PublisherRepository : IPublisherRepository
    {
        // Istanzio il dataContext
        private readonly DataContext dataContext;

        public PublisherRepository(DataContext DataContext){
            this.dataContext = DataContext;
        }

        // Operazioni di Lettura

        // Metodo che restituisce una lista di Case Editrici
        public List<Publisher> GetAll(){
            var list = dataContext.Publishers.ToList();
            if (list == null)
            {
                return null;
            }
            return list;
        }

        // Metodo che restituisce una Casa Editrice di un determinato Id
        public Publisher GetById(int Id){
            var p = dataContext.Publishers.FirstOrDefault(p => p.Id == Id);
            if (p == null)
            {
                return null;
            }
            return p;
        }

        // Operazioni di Scrittura

        // Metodo che Inserisce una nuova Casa Editrice

        public Publisher Insert(Publisher p){
            if (p != null)
            {
                dataContext.Add<Publisher>(p);
                int result = dataContext.SaveChanges();
                if (result == 0)
                {
                    return null;

                }
            }
            return p;
        }

        // Metodo che Modifica una Casa Editrice
        public Publisher Update(Publisher p){
            Publisher publisher = this.GetById(p.Id);
            if (p != null)
            {
                dataContext.Update<Publisher>(publisher);
                int result = dataContext.SaveChanges();
                if (result == 0)
                {
                    return null;

                }

            }
            return publisher;
        }

        // Metodo che Elimina una Casa Editrice
        public Publisher Delete(int Id){
            Publisher p = this.GetById(Id);

            if (p != null)
            {
                dataContext.Remove<Publisher>(p);
                int result = dataContext.SaveChanges();
                if (result == 0)
                {
                    return null;

                }
            }
            return p;
        }
    }
}