using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
   public class Retenue
    {

        [Key]
        public int Id { get; set; }
        public String Numero { get; set; }
        public decimal MontantRetenue { get; set; }
        public decimal MontantReglement{ get; set; }
        public string Commentaire { get; set; }
    }
}
