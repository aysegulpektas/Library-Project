using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class Kitap
    {
        public int Id { get; set; }
        public string KitapAdi { get; set; }
        public string Yazar { get; set; }
        public string BarkodNo { get; set; }

    }
}
