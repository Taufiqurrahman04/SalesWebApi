﻿using System.Text.Json;

namespace ViewModel
{
    public class ErrorDetailViewModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
