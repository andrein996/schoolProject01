using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laborator1.Domain;
using Lab10.controller;
using Lab10.repository;
using Lab10.validators;
using Lab10.domain;

namespace Lab10
{
    class Program
    {
        static void printMenu()
        {
            Console.WriteLine("-------------------Meniu--------------------");
            Console.WriteLine("1 - Meniu posturi");
            Console.WriteLine("2 - Meniu sarcine");
            Console.WriteLine("3 - Meniu element fisa");
            Console.WriteLine("0 - Exit");
        }

        static void printCRUDMenu()
        {
            Console.WriteLine("1 - Add");
            Console.WriteLine("2 - Remove");
            Console.WriteLine("3 - Update");
            Console.WriteLine("4 - Print all");
            Console.WriteLine("Orice pentru a reveni inapoi");
        }

        static void printElementFisaMenu()
        {
            Console.WriteLine("1 - Add");
            Console.WriteLine("2 - Remove");
            Console.WriteLine("3 - Update");
            Console.WriteLine("4 - Print all");
            Console.WriteLine("5 - Print posturi");
            Console.WriteLine("6 - Print sarcine");
            Console.WriteLine("Orice pentru a reveni inapoi");
        }

        public static int ReadInt32(string value)
        {
            int val = -1;
            if (!int.TryParse(value, out val))
                return -1;
            return val;
        }

        static void posturiMenu(PostController ctr)
        {
            Console.WriteLine("---------------Meniu posturi----------------");
            printCRUDMenu();

            int x = ReadInt32(Console.ReadLine());
            if (x == 1)
            {
                Console.WriteLine("Id: ");
                String id = Console.ReadLine();
                Console.WriteLine("Descriere post: ");
                String descriere = Console.ReadLine();
                Console.WriteLine("Tip post: ");
                String tip = Console.ReadLine();

                try
                {
                    ctr.addItem(new Post(id, descriere, tip));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (x == 2)
            {
                Console.WriteLine("Index: ");
                String index = Console.ReadLine();
                ctr.removeItem(index);
            }
            else if (x == 3)
            {
                Console.WriteLine("Index: ");
                String index = Console.ReadLine();

                Console.WriteLine("Id: ");
                String id = Console.ReadLine();
                Console.WriteLine("Descriere post: ");
                String descriere = Console.ReadLine();
                Console.WriteLine("Tip post: ");
                String tip = Console.ReadLine();

                try
                {
                    ctr.updateItem(index, new Post(id, descriere, tip));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (x == 4)
            {
                foreach (Post p in ctr.getAll())
                {
                    Console.WriteLine(p);
                }
            }
        }

        static void sarcineMenu(SarcinaController ctr)
        {
            Console.WriteLine("---------------Meniu sarcine----------------");
            printCRUDMenu();

            int x = ReadInt32(Console.ReadLine());
            if (x == 1)
            {
                Console.WriteLine("Id: ");
                int id = ReadInt32(Console.ReadLine());
                Console.WriteLine("Descriere sarcina: ");
                String descriere = Console.ReadLine();

                try
                {
                    ctr.addItem(new Sarcina(id, descriere));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (x == 2)
            {
                Console.WriteLine("Index: ");
                int index = ReadInt32(Console.ReadLine());
                ctr.removeItem(index);
            }
            else if (x == 3)
            {
                Console.WriteLine("Index: ");
                int index = ReadInt32(Console.ReadLine());

                Console.WriteLine("Id: ");
                int id = ReadInt32(Console.ReadLine());
                Console.WriteLine("Descriere sarcina: ");
                String descriere = Console.ReadLine();

                try
                {
                    ctr.updateItem(index, new Sarcina(id, descriere));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (x == 4)
            {
                foreach (Sarcina s in ctr.getAll())
                {
                    Console.WriteLine(s);
                }
            }
        }

        static void elementFisaMenu(PostController postCtr, SarcinaController sarcinaCtr, ElementFisaController ctr)
        {
            Console.WriteLine("-------------Meniu element fisa-------------");
            printElementFisaMenu();

            int x = ReadInt32(Console.ReadLine());
            if (x == 1)
            {
                Console.WriteLine("Id element fisa: ");
                int id = ReadInt32(Console.ReadLine());
                Console.WriteLine("Id post: ");
                String idPost = Console.ReadLine();
                Console.WriteLine("Id sarcina: ");
                int idSarcina = ReadInt32(Console.ReadLine());

                Post p = postCtr.getItemWithId(idPost);
                Sarcina s = sarcinaCtr.getItemWithId(idSarcina);

                if (p != null && 
                    s != null)
                {
                    try
                    {
                        ctr.addItem(new ElementFisa(id, 
                            p, 
                            s));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }         
                }
            }
            else if (x == 2)
            {
                Console.WriteLine("Id element fisa: ");
                int id = ReadInt32(Console.ReadLine());

                ctr.removeItem(id);
            }
            else if (x == 3)
            {
                Console.WriteLine("Id element fisa: ");
                int id = ReadInt32(Console.ReadLine());
                Console.WriteLine("Id post: ");
                String idPost = Console.ReadLine();
                Console.WriteLine("Id sarcina: ");
                int idSarcina = ReadInt32(Console.ReadLine());

                Post p = postCtr.getItemWithId(idPost);
                Sarcina s = sarcinaCtr.getItemWithId(idSarcina);

                if (p != null &&
                    s != null)
                {
                    try
                    {
                        ctr.updateItem(id, new ElementFisa(id,
                            p,
                            s));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            else if (x == 4)
            {
                foreach (ElementFisa ef in ctr.getAll())
                {
                    Console.WriteLine(ef);
                }
            }
            else if (x == 5)
            {
                foreach (Post p in postCtr.getAll())
                {
                    Console.WriteLine(p);
                }
            }
            else if (x == 6)
            {
                foreach (Sarcina s in sarcinaCtr.getAll())
                {
                    Console.WriteLine(s);
                }
            }
        }

        static void Main(string[] args)
        {
            IValidator<Post> validatorPost = new ValidatorPost();
            RepositoryFromFilePost repoPost = new RepositoryFromFilePost(@"..\..\data\Posturi.txt", validatorPost);
            PostController postController = new PostController(repoPost);

            IValidator<Sarcina> validatorSarcina = new ValidatorSarcina();
            RepositoryFromFileSarcina repoSarcina = new RepositoryFromFileSarcina(@"..\..\data\Sarcine.txt", validatorSarcina);
            SarcinaController sarcinaController = new SarcinaController(repoSarcina);

            IValidator<ElementFisa> validatorElementFisa = new ValidatorElementFisa();
            RepositoryFromFileElementFisa repoElementFisa = new RepositoryFromFileElementFisa(@"..\..\data\ElementFisa.txt", validatorElementFisa);
            ElementFisaController elementFisaController = new ElementFisaController(repoElementFisa);

            while (true)
            {
                printMenu();
                int x = ReadInt32(Console.ReadLine());
                if (x == 0)
                {
                    break;
                }
                else if (x == 1)
                {
                    posturiMenu(postController);    
                }
                else if (x == 2)
                {
                    sarcineMenu(sarcinaController);
                }
                else if (x == 3)
                {
                    elementFisaMenu(postController, sarcinaController, elementFisaController);
                }

                repoPost.writeToFile();
                repoSarcina.writeToFile();
                repoElementFisa.writeToFile();
            }
        }
    }
}
