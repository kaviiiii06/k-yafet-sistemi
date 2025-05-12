using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiyafetKiralama.business.@abstract;
using KiyafetKiralama.context;
using KiyafetKiralama.entity;
using KiyafetKiralama.entity.@enum;
using KiyafetKiralama.util;

namespace KiyafetKiralama.business.concrete
{
    internal class ClothesServiceImpl : ClothesService
    {
        private ClothesContext clothesContext = new ClothesContext();
        private UserContext userContext = new UserContext();

        public void save(string name, string description, int stock, Kategori category, string kayitYapanEmail, double price)
        {
            Kullanici admin = userContext.getAdminByEmail(kayitYapanEmail);
            if (admin != null)
            {
                Kiyafet clothes = new Kiyafet();
                clothes.Id = GenerateId.generateClothesId();
                clothes.Ad = name;
                clothes.Aciklama = description;
                clothes.Stok = stock;
                clothes.Kategori = category;
                clothes.KayitYapan = admin;
                clothes.GunlukFiyat = price;
                clothes.MusaitMi = true;
                clothes.Durum = "Yeni";
                clothesContext.save(clothes);
                Console.WriteLine("Kıyafet başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Bu işlem için yetkiniz bulunmamaktadır.");
                }
            }

        public void delete(long id)
        {
            Kiyafet clothes = clothesContext.getClothesById(id);
            if (clothes != null)
            {
                clothesContext.delete(clothes);
                Console.WriteLine("Kıyafet başarıyla silindi.");
            }
            else
            {
                Console.WriteLine("Kıyafet bulunamadı.");
            }
        }

        public Kiyafet getClothesById(long id)
        {
            return clothesContext.getClothesById(id);
        }

        public void showList()
        {
            List<Kiyafet> clothes = clothesContext.getList();
            for (int i = 0; i < clothes.Count; i++)
            {
                Console.WriteLine(clothes[i]);
            }
        }

        public void showListByCategory(Kategori category)
        {
            List<Kiyafet> clothes = clothesContext.getListByCategory(category);
            for (int i = 0; i < clothes.Count; i++)
            {
                Console.WriteLine(clothes[i]);
        }
        }
    }
}
