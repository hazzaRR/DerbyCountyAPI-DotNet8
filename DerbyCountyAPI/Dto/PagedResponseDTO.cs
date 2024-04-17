namespace DerbyCountyAPI.Dto
{
    public class PagedResponseDTO<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public List<T> Data { get; set; }


        public PagedResponseDTO (int pageIndex, int pageSize, int totalRecords, List<T> data)
        {
            PageIndex = pageIndex; 
            PageSize = pageSize;
            TotalRecords = totalRecords;
            TotalPages = (int) Math.Ceiling((decimal)(totalRecords / (decimal) pageSize)); ;
            Data = data;
            HasNextPage = pageIndex < TotalPages;
            HasPreviousPage = pageIndex > 1;
        }



    }
}
