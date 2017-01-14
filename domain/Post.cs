using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10.domain;

namespace Laborator1.Domain
{
    public class Post : HasID<String>
    {
        private String id;
        private String descriere;
        private String tip;

        public String Descriere
        {
            get { return this.descriere; }
            set { this.descriere = value; }
        }

        public String Tip
        {
            get { return this.tip; }
            set { this.tip = value; }
        }

        public String Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public override String ToString()
        {
            return id + " " + descriere + " " + tip;
        }

        public String publish(String separator)
        {
            return this.id + separator + this.descriere + separator + this.tip;
        }

        public Post(String id, String descriere, String tip)
        {
            this.id = id;
            this.descriere = descriere;
            this.tip = tip;
        }

        public Post() {}

    }
}
