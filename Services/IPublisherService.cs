using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Entities;

namespace Book.Services
{
    // Interfaccia IPublisherService che contiene i metodi da implementare in PublisherService
    public interface IPublisherService
    {
        // operazioni di Lettura
        List<Publisher> GetAll();
        Publisher GetById(int Id);
        
        // operazioni di Scrittura
        Publisher Insert(Publisher p);
        Publisher Update(Publisher p);
        Publisher Delete(int Id);

    }
}