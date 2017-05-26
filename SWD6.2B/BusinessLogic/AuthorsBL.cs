using Common;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public enum RegistrationEnum { Success, EmailExists, ErrorOccurred }
    public class AuthorsBL
    {
        AuthorsRepository ur = new AuthorsRepository();

        public RegistrationEnum Register(author u)
        {
            AuthorsRepository ur = new AuthorsRepository();
            if (ur.GetAuthor(u.email) == null)
            {
                try
                {         
                    ur.AddAuthor(u);
                }
                catch
                {
                    return RegistrationEnum.ErrorOccurred;
                }
                return RegistrationEnum.Success;
            }
            else
            {
                return RegistrationEnum.EmailExists;

            }
        }

        public bool checkIfUserExists(string email)
        {
            return ur.DoesAuthornameExist(email);
        }

        public author getAuthorById(int authorID)
        {
            return ur.GetAuthorbyID(authorID);
        }

        public int GetArticlesCount()
        {
            IQueryable<article> myArticles = ur.GetArticlesCount();
            int counter = 0;
            foreach (article art in myArticles)
            {
                counter++;
            }
            return counter;
        }

        public int GetAuthorID(author auth)
        {
            return ur.GetAuthorID(auth);
        }

        public bool Login(string email, string password)
        {

            author au = GetAuthor(email);
            if (au != null)
            {
                if (password == au.password)
                {
                    return new AuthorsRepository().AuthenticateUser(email, password);
                }
            }

            return false;
        }

        public void RemoveAuthor(int u)
        {
            ur.RemoveAuthor(u);
        }

        public void UpdateAuthor(author au)
        {
            ur.UpdateAuthor(au);
        }

        public IQueryable<author> GetAuthors()
        {
            return ur.GetAuthors();
        }

        public IQueryable<author> GetAuthors(string keyword)
        {
            return ur.GetAuthors(keyword);
        }


        public author GetAuthor(string email)
        {
            return new AuthorsRepository().GetAuthor(email);
        }

    }
}