using BrowseClimate.Models;
using BrowseClimate.Repositories.ArticleRepositories;
using BrowseClimate.Services.ArticleServices;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowseClimateTestProject.ArticleServiceTests
{
    public class ArticleServiceTest
    {


        [Fact]
        public void CreateArticle_SuccessfullyCreateArticle()
        {

            Article article = ValidArticle();
            var repo = new Mock<IArticleRepository>();
            repo.Setup(x => x.CreateArticle(It.IsAny<Article>())).Returns(Task.FromResult(1));
            var _sut = new ArticleService(repo.Object);

            var exception = Record.ExceptionAsync(() => _sut.CreateArticle(article));

            Assert.Null(exception.Exception);

        }


        [Fact]
        public void CreateArticle_ThrowsErrorIfEmptyFields()
        {

            Article article = ValidArticle();
            article.Title = ""; 
            var repo = new Mock<IArticleRepository>();
            repo.Setup(x => x.CreateArticle(It.IsAny<Article>())).Returns(Task.FromResult(1));
            var _sut = new ArticleService(repo.Object);

           Assert.ThrowsAsync<ArgumentException>(() =>_sut.CreateArticle(article));

        }


        public Article ValidArticle()
        {
            Article article = new Article();
            
            article.Id = 1;
            article.Title = "Title"; 
            article.Description = "Description";
            article.Content = "Content";

            return article;


        }


        public Article ValidArticle2()
        {
            Article article2 = new Article();

            article2.Id = 2;
            article2.Title = "Title2";
            article2.Description = "Description2";
            article2.Content = "Content2";

            return article2;

        }
    }
}
