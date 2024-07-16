
namespace Utils
{
    public class Result<T>
    {
        public bool? Error { get; set; }
        public string? Message { get; set; }
        public T? Values { get; set; }
    }
}