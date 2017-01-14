using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10.repository;
using Laborator1.Domain;

namespace Lab10.controller
{
    class PostController
    {
        private IRepository<Post, String> repo;

        public PostController(IRepository<Post, String> r)
        {
            this.repo = r;
        }

        public void addItem(Post p)
        {
            try
            {
                repo.add(p);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<Post> getAll()
        {
            return repo.getAll();
        }

        public Post removeItem(String index)
        {
            if (repo.findById(index) != null)
            {
                return repo.delete(index);
            }
            return default(Post);
        }

        public Post getItemWithId(String id)
        {
            return repo.findById(id);
        }

        public void updateItem(String index, Post newElem)
        {
            if (repo.findById(index) != null)
            {
                repo.update(index, newElem);
            }
            else
            {
                throw new Exception("Nu exista item-ul de la index-ul " + index);
            }
        }
    }
}
