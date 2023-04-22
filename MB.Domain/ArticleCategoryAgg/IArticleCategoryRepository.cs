namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        void Add(ArticleCategory entity);
        List<ArticleCategory> GetAll();
    }
}
