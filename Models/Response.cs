using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremierAPI.Models
{
    public class Response<T>
    {
#nullable enable
        public List<T>? ManyData { get; set; }
        public T? Data { get; set; }
        public StatusCodeResult? Status { get; set; }
    }
}
