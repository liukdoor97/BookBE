using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Repository;
using Book.Entities;

namespace Book.Services
{
    // Classe PublisherService che deriva da IPublisherService
    public class PublisherService : IPublisherService
    {
        // istanzio publisherRepository
        private readonly IPublisherRepository publisherRepository;
        public PublisherService(IPublisherRepository publisherRepository)
        {
            this.publisherRepository = publisherRepository;
        }

        // operazioni di Lettura

        public List<Publisher> GetAll()
        {
            return publisherRepository.GetAll();
        }
        public Publisher GetById(int Id)
        {
            return publisherRepository.GetById(Id);
        }

        // operazioni di Scrittura

        public Publisher Insert(Publisher p)
        {
            return publisherRepository.Insert(p);
        }
        public Publisher Update(Publisher p)
        {
            return publisherRepository.Update(p);
        }
        public Publisher Delete(int Id)
        {
            return publisherRepository.Delete(Id);
        }
    }
}