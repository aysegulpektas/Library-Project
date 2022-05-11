using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class Odunc
    {
        public int Id { get; set; }
        public int UyeId { get; set; }
        public int KitapId { get; set; }
        public DateTime OduncAlmaTarihi { get; set; }
        public DateTime? GeriVermeTarihi { get; set; }

    }
}
