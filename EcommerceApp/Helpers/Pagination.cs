namespace EcommerceApp.Helpers
{
    public class Pagination<T> where T : class
    {
        public Pagination(int pageindex , int pagesize ,int count , IReadOnlyList<T> data)
        {
            PageIndex=pageindex;
            PageSize=pagesize;
            TotalCount = count;
            Data = data;


        }
        public int PageIndex { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
