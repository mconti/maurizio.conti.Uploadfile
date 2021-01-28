using Microsoft.AspNetCore.Http;

namespace maurizio.conti.Uploadfile.Models
{
    public class PersoneFormFile
    {
        public string Descrizione { set;get; }
        public IFormFile MioFormFile { set; get; }
    }
}