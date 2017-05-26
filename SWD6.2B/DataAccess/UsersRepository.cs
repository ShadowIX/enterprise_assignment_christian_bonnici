using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AuthorsRepository : ConnectionClass
    {
        public AuthorsRepository() : base()
        {
        }
        public IQueryable<author> GetAuthors()
        {
            return Entity.authors;
        }

        public IQueryable<author> GetAuthors(string keyword)
        {
            return Entity.authors.Where(x => x.first_name == keyword);
        }



        public bool DoesAuthornameExist(string Authorname)
        {
            return Entity.authors.SingleOrDefault(x => x.email == Authorname) == null ? false : true;
        }

        public void AddAuthor(author u)
        {
            Entity.authors.Add(u);
            Entity.SaveChanges();
        }

        public author GetAuthor(string email)
        {
            return Entity.authors.SingleOrDefault(x => x.email == email);
        }

        public author GetAuthorbyID(int author_id)
        {
            return Entity.authors.SingleOrDefault(x => x.authorID == author_id);
        }

        public IQueryable<article> GetArticlesCount()
        {
            return Entity.articles;
        }

        public int GetAuthorID(author auth)
        {
            author au = GetAuthor(auth.email);
            return au.authorID;
        }

        public void RemoveAuthor(int u)
        {
            author au = GetAuthorbyID(u);
            Entity.authors.Remove(au);
            Entity.SaveChanges();
        }

        public bool AuthenticateUser(string email, string password)
        {
            if (Entity.authors.SingleOrDefault(x => x.email == email &&
                 x.password == password) != null)
                return true;
            else return false;
        }

        public void UpdateAuthor(author au)
        {
            Entity.Entry(GetAuthorbyID(au.authorID)).CurrentValues.SetValues(au);
            Entity.SaveChanges();
        }
    }
    }
