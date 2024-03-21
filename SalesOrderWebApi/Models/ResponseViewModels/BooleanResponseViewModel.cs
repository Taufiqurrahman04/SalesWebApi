using System.Text.Json;

namespace Models.ViewModels
{
    public class BooleanResponseViewModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
