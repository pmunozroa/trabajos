using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certamen2.Models
{
    internal record Marca
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
    }
}
