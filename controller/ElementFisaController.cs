using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10.domain;
using Lab10.repository;

namespace Lab10.controller
{
    class ElementFisaController
    {
        private IRepository<ElementFisa, int> repo;

        public ElementFisaController(IRepository<ElementFisa, int> r)
        {
            this.repo = r;
        }

        public void addItem(ElementFisa ef)
        {
            try
            {
                repo.add(ef);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<ElementFisa> getAll()
        {
            return repo.getAll();
        }

        public ElementFisa removeItem(int index)
        {
            if (repo.findById(index) != null)
            {
                return repo.delete(index);
            }
            return default(ElementFisa);
        }

        public void updateItem(int index, ElementFisa newElem)
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
