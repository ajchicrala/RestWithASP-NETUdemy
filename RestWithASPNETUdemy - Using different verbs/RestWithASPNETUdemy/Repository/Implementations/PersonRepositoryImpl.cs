using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class PersonRepositoryImpl : IRepository
    {

        private MySqlContext _context;

        public PersonRepositoryImpl(MySqlContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {

            try
            {
                var result = _context.Persons.Where(c => c.Id == id).FirstOrDefault();
                if (result != null)
                {
                    _context.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Person> FindAll()
        {
            return _context.Persons.Where(c => c.Id > 0).ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.Where(c => c.Id == id).FirstOrDefault();

        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id))
            {
                return new Person();
            }

            var result = _context.Persons.Where(c => c.Id == person.Id).First();
            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return person;

        }

        private bool Exists(int id)
        {
            return _context.Persons.Where(c => c.Id == id).Any();
        }



    }

}
