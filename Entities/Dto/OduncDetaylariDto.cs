using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class OduncDetaylariDto
    {
        public int Id { get; set; }
        public string UyeAdi { get; set; }
        public string UyeSoyadi { get; set; }
        public string UyeTcNo { get; set; }
        public string KitapBarkodNo { get; set; }
        public string KitapAdi { get; set; }
        public DateTime OduncAlmaTarihi { get; set; }
        public DateTime? GeriVermeTarihi { get; set; }
    }
}
