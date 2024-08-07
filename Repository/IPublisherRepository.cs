using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Entities;

namespace Book.Repository
{
    // Interfaccia IPublisherRepository che contiene i Metodi da implementare in IPublisherRepository
    public interface IPublisherRepository
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