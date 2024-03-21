using System.Text.Json;

namespace ViewModel
{
    public class SingleResponseViewModel<T> where T : class
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
