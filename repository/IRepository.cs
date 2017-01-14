using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10.domain;

namespace Lab10.repository
{
    public interface IRepository<E, ID> where E: HasID<ID>
                                        where ID: IComparable<ID>
    {
        void add(E item);
        E delete(ID index);
        void update(ID index, E newItem);
        E findById(ID key);
        List<E> getAll();
        void sort(comparator<E> cmp);
    }
}
