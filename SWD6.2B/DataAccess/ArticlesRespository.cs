using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ArticlesRepository : ConnectionClass
    {
        public ArticlesRepository():base()
        {
        }
        public IQueryable<article> Getarticles()
        {
            return Entity.articles;
        }

        public IQueryable<article> GetarticlesByAuthor(int author_id)
        {
            return Entity.articles.Where(x => x.authorID == author_id);
        }

        public IQueryable<article> Getarticles(string title)
        {
            return Entity.articles.Where(x => x.article_name == title);
        }


        public void Addarticle(article u)
        {
            Entity.articles.Add(u);
            Entity.SaveChanges();
        }

        public void Updatearticle(string path, int article_id)
        {
            article arth = Getarticle(article_id);
            arth.imageUrl = path;
            Entity.SaveChanges();
        }

        public article Getarticle(int art_id)
        {
            return Entity.articles.SingleOrDefault(x => x.articleID == art_id);
        }

        public void Removearticle(int article_id)
        {
            article au = Getarticle(article_id);
            Entity.articles.Remove(au);
            Entity.SaveChanges();
        }

        public void Updatearticle(article au)
        {
            Entity.Entry(Getarticle(au.articleID)).CurrentValues.SetValues(au);
            Entity.SaveChanges();
        }

        public IQueryable<article> getFeaturedArticles()
        {
            return Entity.articles.Where(x => x.isfeatured == true);
        }
    }
}
