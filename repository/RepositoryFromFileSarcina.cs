using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10.repository;
using Laborator1.Domain;
using System.IO;
using Lab10.validators;

namespace Lab10.repository
{
    class RepositoryFromFileSarcina : AbstractFileRepository<Sarcina, int>
    {
        private String fileName;
        public RepositoryFromFileSarcina(String fileN, IValidator<Sarcina> validator):base(validator)
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
                if (toke.Length == 2)
                {
                    Sarcina s = new Sarcina(int.Parse(toke[0]), toke[1]);
                    add(s);
                }
            }
            sr.Close();
        }

        public override void writeToFile()
        {
            StreamWriter sr = new StreamWriter(fileName);
            foreach (Sarcina s in getAll())
            {
                sr.WriteLine(s.publish("#"));
            }
            sr.Close();
        }
    }
}
