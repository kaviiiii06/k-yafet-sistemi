using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiyafetKiralama.entity.@enum;

namespace KiyafetKiralama.entity
{
    internal class Kullanici : BaseLongEntity
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Eposta { get; set; }
        public Rol Rol { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"Ad: {Ad}, Soyad: {Soyad}, Kullanıcı Adı: {KullaniciAdi}, E-posta: {Eposta}, Rol: {Rol}";
        }
    }
}
