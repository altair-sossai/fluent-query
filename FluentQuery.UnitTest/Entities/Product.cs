namespace FluentQuery.UnitTest.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public Category Category { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
    }
}