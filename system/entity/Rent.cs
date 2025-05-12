using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiyafetKiralama.entity
{
    internal class Kiralama : BaseLongEntity
    {
        public Kullanici KiralayanKullanici { get; set; }
        public Kiyafet KiralananKiyafet { get; set; }
        public DateTime KiralamaBaslangicTarihi { get; set; }
        public DateTime KiralamaBitisTarihi { get; set; }
        public int KiralananGun { get; set; }
        public double ToplamUcret { get; set; }
        public bool OnaylandiMi { get; set; }
        public bool IadeEdildiMi { get; set; }
        public string KiralamaNotu { get; set; }
        public DateTime? IadeTarihi { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"Kiralayan: {KiralayanKullanici.Ad}, " +
                   $"Kıyafet: {KiralananKiyafet.Ad}, " +
                   $"Başlangıç: {KiralamaBaslangicTarihi:dd.MM.yyyy}, " +
                   $"Bitiş: {KiralamaBitisTarihi:dd.MM.yyyy}, " +
                   $"Gün: {KiralananGun}, " +
                   $"Toplam Ücret: {ToplamUcret:C2}, " +
                   $"Onay: {(OnaylandiMi ? "Onaylandı" : "Bekliyor")}, " +
                   $"İade: {(IadeEdildiMi ? "İade Edildi" : "İade Edilmedi")}" +
                   $"{(IadeTarihi.HasValue ? $", İade Tarihi: {IadeTarihi.Value:dd.MM.yyyy}" : "")}";
        }
    }
}
