namespace MediTech.Helper
{
    public class Pagention<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public IReadOnlyList<T> Data { get; set; }

        public Pagention(int pageIndex, int pageSize, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;

            Data = data;
        }
    }
}
