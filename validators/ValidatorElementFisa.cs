using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10.validators;
using Lab10.domain;

namespace Lab10.validators
{
    class ValidatorElementFisa : IValidator<ElementFisa>
    {
        public void validare(ElementFisa obj)
        {
            string err = "";

            if (obj.Id < 0 ||
                obj.Id.Equals(null))
            {
                err += "ID-ul este invalid\n";
            }
            ValidatorPost vPost = new ValidatorPost();
            ValidatorSarcina vSarcina = new ValidatorSarcina();

            vPost.validare(obj.Post);
            vSarcina.validare(obj.Sarcina);

            if (err != "")
            {
                Exception e = new Exception(err);
                throw e;
            }
        }
    }
}