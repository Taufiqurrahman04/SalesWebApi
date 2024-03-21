using System.Text.Json;

namespace ViewModel
{
    public class ListResponseViewModel<T> where T : class
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public IEnumerable<T> Datas { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
