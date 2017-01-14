using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10.domain;

namespace Lab10.repository
{
    interface IFileRepository<E, ID> : IRepository<E, ID> 
        where E : HasID<ID>
        where ID : IComparable<ID>
    {
        void readFromFile();
        void writeToFile();
    }
}
