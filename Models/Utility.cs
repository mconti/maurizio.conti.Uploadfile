using System;
using System.IO;

namespace maurizio.conti.Uploadfile.Models
{
    public static class MyServer 
    {
        public static string MapPath(string path)
        {
            return Path.Combine(
                (string)AppDomain.CurrentDomain.GetData("ContentRootPath"), 
                path);
        }
    }
}