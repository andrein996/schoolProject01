using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laborator1.Domain;
using Lab10.validators;

namespace Lab10
{
    class ValidatorSarcina : IValidator<Sarcina>
    {
        public void validare(Sarcina s)
        {
            string err = "";
            if (s.Id <= 0)
            {
                err += "ID negativ\n";
            }
            if (s.DescriereSarcina.CompareTo("") == 0 ||
                s.DescriereSarcina.Equals(null))
            {
                err += "Descrierea este invalida\n";
            }
            if (err != "")
            {
                Exception e = new Exception(err);
                throw e;
            }
        }
    }
}
