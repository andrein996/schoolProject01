using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10.domain;
using Laborator1.Domain;
using System.IO;
using Lab10.validators;

namespace Lab10.repository
{
    class RepositoryFromFilePost : AbstractFileRepository<Post, String> 
    {
        private String fileName;
        public RepositoryFromFilePost(String fileN, IValidator<Post> validator):base(validator)
        {
            this.fileName = fileN;
            readFromFile();
        }

        public override void readFromFile()
        {
            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                String line = sr.ReadLine();
                String[] toke = line.Split('#');
                if (toke.Length == 3)
                {
                    Post p = new Post(toke[0], toke[1], toke[2]);
                    add(p);
                }
            }
            sr.Close();
        }

        public override void writeToFile()
        {
            StreamWriter sr = new StreamWriter(fileName);
            foreach(Post p in getAll())
            {
                sr.WriteLine(p.publish("#"));
            }
            sr.Close();
        }
    }
}
