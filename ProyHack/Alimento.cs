using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyHack
{
    public class Alimento
    {
        public int Id { get; set; } 
        public string Nombre {  get; set; }
        public DateTime FechaCaducidad { get; set; }
        public string Categoria { get; set; }
    }
}
