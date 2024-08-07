using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Repository;
using Book.Entities;

namespace Book.Services
{
    // Classe AuthorService che deriva da IAuthorService
    public class AuthorService : IAuthorService
    {
        // istanzio authorRepository
        private readonly IAuthorRepository authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        // operazioni di Lettura

        public List<Author> GetAll()
        {
            return authorRepository.GetAll();
        }
        public Author GetById(int Id)
        {
            return authorRepository.GetById(Id);
        }

        // operazioni di Scrittura

        public Author Insert(Author a)
        {
            return authorRepository.Insert(a);
        }
        public Author Update(Author a)
        {
            return authorRepository.Update(a);
        }
        public Author Delete(int Id)
        {
            return authorRepository.Delete(Id);
        }
    }
}