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
    public class KitaplarController : ControllerBase
    {
        KitapDuzenle kitapDuzenle = new KitapDuzenle();
        [HttpPost("Ekle")]
        public IActionResult Ekle(Kitap kitap)
        {
            if(kitapDuzenle.Getir(p=>p.BarkodNo == kitap.BarkodNo) != null)
            {
                return BadRequest(new { error = new { message = "Bu barkod numarası mevcut" } });
            }
            if (kitap.BarkodNo == null || kitap.KitapAdi == null || kitap.Yazar == null)
            {
                return BadRequest(new { error = new { message = "Tüm alanları eksiksiz doldurun"} });
            }
            kitapDuzenle.Ekle(kitap);

            return Ok("İşlem başarılı");
        }
        [HttpGet("TumunuListele")]
        public IActionResult TumunuListele()
        {
            return Ok(kitapDuzenle.Listele());
        }
        [HttpGet("idilelistele")]
        public IActionResult IdileListele(int id)
        {
            return Ok(kitapDuzenle.Listele(p => p.Id == id));
        }
        [HttpGet("adilelistele")]
        public IActionResult AdileListele(string ad)
        {
            return Ok(kitapDuzenle.Listele(p => p.KitapAdi.ToLower().Contains(ad.ToLower())));
        }
        [HttpPost("Guncelle")]
        public IActionResult Guncelle(Kitap kitap)
        {
            kitapDuzenle.Guncelle(kitap);
            return Ok("İşlem başarılı");
        }
        [HttpPost("Sil")]
        public IActionResult Sil(Kitap kitap)
        {
            kitapDuzenle.Sil(kitap);
            return Ok("İşlem başarılı");
        }
    }
}
