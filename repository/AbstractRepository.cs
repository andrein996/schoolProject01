using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10.domain;
using Lab10.repository;
using Lab10.validators;

namespace Lab10.repository
{
    public class AbstractRepository<E, ID> : IRepository<E, ID> where E : HasID<ID>
                                                            where ID : IComparable<ID>
    {
        private List<E> items;
        private IValidator<E> validator;

        public AbstractRepository(IValidator<E> validator)
        {
            items = new List<E>();
            this.validator = validator;
        }

        public void add(E item)
        {
            if (this.findById(item.Id) != null)
            {
                throw new Exception("Exista deja id-ul!");
            }
            else
            {
                validator.validare(item);
                items.Add(item);
            }
        }

        public E delete(ID index)
        {
            E item = findById(index);
            if (item != null)
            {
                items.Remove(item);
                return item;
            }
            else
            {
                return default(E);
            }
        }

        public E findById(ID key)
        {
            int index = items.FindIndex((x) => x.Id.Equals(key));
            if (index != -1)
            {
                return items.ElementAt(index);
            }
            return default(E);
        }

        public List<E> getAll()
        {
            return items;
        }

        public void sort(comparator<E> cmp)
        {
            
        }

        public void update(ID index, E newItem)
        {
            E item = this.findById(index);
            if (item != null)
            {
                int indexItem = items.IndexOf(item);
                items.RemoveAt(indexItem);

                validator.validare(newItem);
                items.Insert(indexItem, newItem);
            }
            else
            {
                throw new Exception("Index inexistent!");
            }
        }
    }
}
