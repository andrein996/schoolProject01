using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10.validators
{
    public interface IValidator<E>
    {
        void validare(E obj);
    }
}
