using DataAccess;
using Entities;
using Entities.Dto;
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
    public class OdunclerController : ControllerBase
    {
        OduncDuzenle oduncDuzenle = new OduncDuzenle();
        KitapDuzenle kitapDuzenle = new KitapDuzenle();
        UyeDuzenle uyeDuzenle = new UyeDuzenle();
        [HttpPost("Ekle")]

        public IActionResult Ekle(OduncEkleDto oduncEkleDto)
        {
            Kitap kitap = kitapDuzenle.Getir(p => p.BarkodNo == oduncEkleDto.BarkodNo);
            Uye uye = uyeDuzenle.Getir(p => p.TcNo == oduncEkleDto.TcNo);
            if (kitap == null)
            {

                return BadRequest(new { error = new { message = "Kitap bulunamadı" } });
            }
            if (uye == null)
            {
                return BadRequest(new { error = new { message = "Üye bulunamadı" } });
            }

            Odunc odunc = new Odunc();
            odunc.OduncAlmaTarihi = DateTime.Now;
            odunc.KitapId = kitap.Id;
            odunc.UyeId = uye.Id;
            oduncDuzenle.Ekle(odunc);
            return Ok("İşlem başarılı");
        }
        [HttpGet("TumunuListele")]
        public IActionResult TumunuListele()
        {
            return Ok(oduncDuzenle.Listele());
        }
        [HttpGet("oduncdetaylari")]
        public IActionResult OduncDetaylari(string tc = null)
        {
            if(tc == null)
                return Ok(oduncDuzenle.DetayListele());
            else
                return Ok(oduncDuzenle.DetayListele(p=>p.UyeTcNo == tc));
        }
        [HttpGet("idilelistele")]
        public IActionResult IdileListele(int id)
        {
            return Ok(oduncDuzenle.Listele(p => p.Id == id));
        }
        [HttpPost("Guncelle")]
        public IActionResult Guncelle(Odunc odunc)
        {
            oduncDuzenle.Guncelle(odunc);
            return Ok("İşlem başarılı");
        }
        [HttpPost("Sil")]
        public IActionResult Sil(Odunc odunc)
        {
            oduncDuzenle.Sil(odunc);
            return Ok("İşlem başarılı");
        }
        [HttpPost("gerigetirildi")]
        public IActionResult GeriGetirildi(Odunc odunc)
        {
            Odunc odunc1 = oduncDuzenle.Getir(p => p.Id == odunc.Id);
            odunc1.GeriVermeTarihi = DateTime.Now;
            oduncDuzenle.Guncelle(odunc1);
            return Ok("Kitap Geri alındı");
        }
    }
}
