using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace maurizio.conti.Uploadfile.Models
{
    public class PersoneCSV : List<Persona>
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Descrizione { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public long FileLength { get; set; }
        public byte[] RawData { set; get; }

        public PersoneCSV()
        {}

        public PersoneCSV( PersoneFormFile formFile )
        {
            if( formFile != null) 
            {
                Descrizione = formFile.Descrizione;

                Data = DateTime.Now;
                ContentType = formFile.MioFormFile.ContentType;
                FileName = formFile.MioFormFile.FileName;
                FileLength = formFile.MioFormFile.Length;
                
                using (var memStream = new MemoryStream())
                {
                    formFile.MioFormFile.CopyTo( memStream );
                    memStream.Seek(0,0);

                    StreamReader sr = new StreamReader( memStream );
                    
                    if( !sr.EndOfStream ) {
                        string riga = sr.ReadLine();

                        while( !sr.EndOfStream )
                        {
                            riga = sr.ReadLine();
                            string[] campi = riga.Split(new char[] { ';', ',', '.' });
                            int id = Convert.ToInt32(campi[0]);

                            try
                            {
                                string ruolo = campi[1];
                                if (ruolo=="ITP")
                                {
                                    ITP pers = new ITP
                                    {
                                        ID = Convert.ToInt32(campi[0]),
                                        Nome = campi[2],
                                        Cognome = campi[3],
                                        Ore = Convert.ToInt32(campi[4])
                                    };
                                    Add(pers);
                                }
                                else
                                {
                                    IDT pers = new IDT
                                    {
                                        ID = Convert.ToInt32(campi[0]),
                                        Nome = campi[2],
                                        Cognome = campi[3],
                                        Ore = Convert.ToInt32(campi[4])
                                    };

                                    // Add esiste perchè l'abbiamo ereditata da List<T>
                                    // Qui inseriamo un IDT
                                    Add(pers);
                                }
                            }
                            catch (Exception err) { Console.WriteLine(err.Message); }
                        }
                    }
                }
            }
        }
    }
}