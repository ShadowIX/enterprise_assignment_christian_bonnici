using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace BusinessLogic
{
    public class ArticlesBL
    {
        ArticlesRepository ar = new ArticlesRepository();

        public void CreateArticle(article u)
        {
            ar.Addarticle(u);
        }

        public void Removearticle(int u)
        {
            ar.Removearticle(u);
        }

        public void Updatearticle(article au)
        {
            ar.Updatearticle(au);
        }

        public void UpdateImage(String path, int Article_id)
        {
            ar.Updatearticle(path, Article_id);
        }


        public IQueryable<article> Getarticles()
        {
            return ar.Getarticles();
        }

        public IQueryable<article> Getarticles(string keyword)
        {
            return ar.Getarticles(keyword);
        }


        public article Getarticle(int articleID)
        {
            return new ArticlesRepository().Getarticle(articleID);
        }

    }
}
