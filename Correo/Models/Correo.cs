using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Correo.Models
{
    public class Correo
    {
        public String Asunto { get; set; }
        [DataType(DataType.EmailAddress)]
        public String Destino { get; set; }
        public String Mensaje { get; set; }
    }
}