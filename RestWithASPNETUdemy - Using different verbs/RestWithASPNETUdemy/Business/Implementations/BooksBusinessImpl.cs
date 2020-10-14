using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository;
using RestWithASPNETUdemy.Repository.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class BooksBusinessImpl : IBooksBusiness
    {

        private IRepository<Books> _repository;

        public BooksBusinessImpl(IRepository<Books> repository)
        {
            _repository = repository;
        }

        public Books Create(Books books)
        {
            return _repository.Create(books);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Books> FindAll()
        {
            return _repository.FindAll();
        }

        public Books FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Books Update(Books books)
        {
            return _repository.Update(books);
        }




    }

}
