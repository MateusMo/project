namespace laplacedemon.Models.DataModel
{
    public class Page
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 10;

        public Page(int pageNumber)
        {
            this.PageNumber = pageNumber;
        }
    }
}
