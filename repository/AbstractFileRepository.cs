using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10.domain;
using Lab10.validators;

namespace Lab10.repository
{
    public abstract class AbstractFileRepository<E, ID> : AbstractRepository<E, ID>, IFileRepository<E, ID>
        where E : HasID<ID>
        where ID : IComparable<ID>
    {
        public AbstractFileRepository(IValidator<E> validator) : base(validator) { }

        public abstract void readFromFile();

        public abstract void writeToFile();
    }
}
