var anasayfaBtn = document.getElementById("anasayfaBtn");
var uyelerBtn = document.getElementById("uyeDuzenleBtn");
var kitaplarBtn = document.getElementById("kitapDuzenleBtn");
var odunclerBtn = document.getElementById("oduncBtn");
var uyeSorgulaBtn = document.getElementById("uyeSorgulaBtn");
anasayfaBtn.addEventListener("click", function () {
    window.location.replace("/index.html");
})
uyelerBtn.addEventListener("click", function () {
    window.location.replace("/uyeislemleri.html");
});
kitaplarBtn.addEventListener('click',function () {
    window.location.replace("/kitapislemleri.html");
});
odunclerBtn.addEventListener('click', function () {
    window.location.replace("/oduncislemleri.html");
})
uyeSorgulaBtn.addEventListener('click', function () {
    window.location.replace("/uyedetay.html");
})