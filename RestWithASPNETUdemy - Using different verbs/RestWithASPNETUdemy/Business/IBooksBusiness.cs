using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IBooksBusiness
    {
        Books Create(Books books);
        Books FindById(long id);
        List<Books> FindAll();
        Books Update(Books person);
        void Delete(long id);
    }
}
