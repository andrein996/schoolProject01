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
    class RepositoryFromFileElementFisa : AbstractFileRepository<ElementFisa, int>
    {
        private String fileName;
        public RepositoryFromFileElementFisa(String fileN, IValidator<ElementFisa> validator):base(validator)
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
                if (toke.Length == 6)
                {
                    Post p = new Post(toke[1], toke[2], toke[3]);
                    Sarcina s = new Sarcina(int.Parse(toke[4]), toke[5]);
                    ElementFisa e = new ElementFisa(int.Parse(toke[0]), p, s);

                    add(e);
                }
            }
            sr.Close();
        }

        public override void writeToFile()
        {
            StreamWriter sr = new StreamWriter(fileName);
            foreach (ElementFisa e in getAll())
            {
                sr.WriteLine(e.publish("#"));
            }
            sr.Close();
        }
    }
}
