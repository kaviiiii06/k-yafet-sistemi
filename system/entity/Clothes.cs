using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiyafetKiralama.entity.@enum;

namespace KiyafetKiralama.entity
{
    internal class Kiyafet : BaseLongEntity
    {
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public int Stok { get; set; }
        public Kategori Kategori { get; set; }
        public Kullanici KayitYapan { get; set; }
        public double GunlukFiyat { get; set; }
        public string Beden { get; set; }
        public string Marka { get; set; }
        public string Renk { get; set; }
        public bool MusaitMi { get; set; }
        public string Durum { get; set; } // Yeni, İyi, Orta, Kullanılmış

        public override string ToString()
        {
            return base.ToString() + $" Kıyafet Adı: {Ad}, Açıklama: {Aciklama}, Stok: {Stok}, Kategori: {Kategori}" +
                   $" Marka: {Marka}, Beden: {Beden}, Renk: {Renk}, Durum: {Durum}" +
                   $" Günlük Fiyat: {GunlukFiyat:C2}, Müsaitlik: {(MusaitMi ? "Evet" : "Hayır")}";
        }
    }
}
