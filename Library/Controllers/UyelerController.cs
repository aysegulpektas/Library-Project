using DataAccess;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UyelerController : ControllerBase
    {
        UyeDuzenle kisiDuzenle = new UyeDuzenle();
        [HttpPost("Ekle")]
        public IActionResult Ekle(Uye kisi)
        {
            kisiDuzenle.Ekle(kisi);
            return Ok("İşlem başarılı");
        }
        [HttpGet("TumunuListele")]
        public IActionResult TumunuListele()
        {
            return Ok(kisiDuzenle.Listele());
        }
        [HttpGet("idilelistele")]
        public IActionResult IdileListele(int id)
        {
            return Ok(kisiDuzenle.Listele(p => p.Id == id));
        }
        [HttpGet("adilelistele")]
        public IActionResult AdileListele(string ad)
        {
            return Ok(kisiDuzenle.Listele(p => p.Ad.ToLower().Contains(ad.ToLower())));
        }
        [HttpGet("tcilelistele")]
        public IActionResult Tcilelistele(string tc)
        {
            return Ok(kisiDuzenle.Getir(p => p.TcNo == tc));
        }
        [HttpPost("Guncelle")]
        public IActionResult Guncelle(Uye uye)
        {
            kisiDuzenle.Guncelle(uye);
            return Ok("İşlem başarılı");
        }
        [HttpPost("sil")]
        public IActionResult Sil(Uye uye)
        {
            kisiDuzenle.Sil(uye);
            return Ok("İşlem başarılı");
        }
    }
}
