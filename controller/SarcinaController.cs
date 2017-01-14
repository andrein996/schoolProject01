using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laborator1.Domain;
using Lab10.repository;

namespace Lab10.controller
{
    class SarcinaController
    {
        private IRepository<Sarcina, int> repo;

        public SarcinaController(IRepository<Sarcina, int> r)
        {
            this.repo = r;
        }

        public void addItem(Sarcina s)
        {
            try
            {
                repo.add(s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<Sarcina> getAll()
        {
            return repo.getAll();
        }

        public Sarcina removeItem(int index)
        {
            if (repo.findById(index) != null)
            {
                return repo.delete(index);
            }
            return default(Sarcina);
        }

        public Sarcina getItemWithId(int id)
        {
            return repo.findById(id);
        }

        public void updateItem(int index, Sarcina newElem)
        {
            if (repo.findById(index) != null)
            {
                repo.update(index, newElem);
            }
            else
            {
                throw new Exception("Nu exista item-ul de la index-ul " + index);
            }
        }
    }
}
