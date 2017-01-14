using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10.domain;

namespace Laborator1.Domain
{
    class Sarcina : HasID<int>
    {
        private int id;
        private String descriereSarcina;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public String DescriereSarcina
        {
            get { return this.descriereSarcina; }
            set { this.descriereSarcina = value; }
        }

        public Sarcina() { }

        public Sarcina(int id, String descriereSarcina)
        {
            this.id = id;
            this.descriereSarcina = descriereSarcina;
        }

        public override string ToString()
        {
            return id + " " + descriereSarcina;
        }

        public String publish(String separator)
        {
            return id + separator + descriereSarcina;
        }
    }
}
