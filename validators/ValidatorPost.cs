using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laborator1.Domain;
using Lab10.validators;

namespace Lab10
{
    class ValidatorPost : IValidator<Post>
    {
        public void validare(Post p)
        {
            string err = "";
            if (p.Id.CompareTo("") == 0 ||
                p.Id.Equals(null))
            {
                err += "ID-ul este invalid\n";
            }
            if (p.Descriere.CompareTo("") == 0 ||
                p.Descriere.Equals(null))
            {
                err += "Descrierea este invalid\n";
            }
            if (p.Tip.CompareTo("") == 0 ||
                p.Tip.Equals(null) ||
                (p.Tip.CompareTo("parttime") != 0 &&
                p.Tip.CompareTo("fulltime") != 0))
            {
                err += "Tipul este invalid\n";
            }
            if (err != "")
            {
                Exception e = new Exception(err);
                throw e;
            }
        }
    }
}
