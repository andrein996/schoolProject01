using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laborator1.Domain;

namespace Lab10.domain
{
    class ElementFisa : HasID<int>
    {
        private int id;
        private Post post;
        private Sarcina sarcina;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public Post Post
        {
            get { return this.post; }
            set { this.post = value; }
        }

        public Sarcina Sarcina
        {
            get { return this.sarcina; }
            set { this.sarcina = value; }
        }

        public ElementFisa() { }

        public ElementFisa(int id, Post p, Sarcina s)
        {
            this.id = id;
            this.post = p;
            this.sarcina = s;
        }

        public override string ToString()
        {
            return id + " " + post.ToString() + " " + sarcina.ToString();
        }

        public String publish(String separator)
        {
            return id + separator + post.publish(separator) + separator + sarcina.publish(separator);
        }
    }
}
