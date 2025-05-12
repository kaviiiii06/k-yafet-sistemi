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
    internal class RentServiceImpl : RentService
    {
        private RentContext rentContext = new RentContext();
        private ClothesContext clothesContext = new ClothesContext();
        private UserContext userContext = new UserContext();

        public void requestRent(long userId, long clothesId, int kiralamaGun, string note)
        {
            Kullanici user = userContext.getUserById(userId);
            Kiyafet clothes = clothesContext.getClothesById(clothesId);
            if (user != null && clothes != null)
            {
                if (clothes.Stok > 0)
                {
                    Kiralama rent = new Kiralama();
                    rent.Id = GenerateId.generateRentId();
                    rent.KiralayanKullanici = user;
                    rent.KiralananKiyafet = clothes;
                    rent.KiralananGun = kiralamaGun;
                    rent.KiralamaNotu = note;
                    rent.OnaylandiMi = false;
                    rent.IadeEdildiMi = false;
                    rent.KiralamaBaslangicTarihi = DateTime.Now;
                    rent.KiralamaBitisTarihi = DateTime.Now.AddDays(kiralamaGun);
                    rent.ToplamUcret = clothes.GunlukFiyat * kiralamaGun;
                    rentContext.save(rent);
                    Console.WriteLine("Kiralama talebi başarıyla oluşturuldu.");
                }
                else
                {
                    Console.WriteLine("Bu kıyafet stokta bulunmamaktadır.");
                }
            }
            else
            {
                Console.WriteLine("Kullanıcı veya kıyafet bulunamadı.");
        }
        }

        public void confirm(long rentId)
        {
            Kiralama rent = rentContext.getRentById(rentId);
            if (rent != null)
            {
                if (!rent.OnaylandiMi)
                {
                        rent.OnaylandiMi = true;
                    rentContext.save(rent);
                    Console.WriteLine("Kiralama başarıyla onaylandı.");
                }
                else
                {
                    Console.WriteLine("Bu kiralama zaten onaylanmış.");
                }
            }
            else
            {
                Console.WriteLine("Kiralama bulunamadı.");
            }
        }

        public void returnRents(long rentId)
        {
            Kiralama rent = rentContext.getRentById(rentId);
            if (rent != null)
            {
                if (rent.OnaylandiMi && !rent.IadeEdildiMi)
                {
                    rent.IadeEdildiMi = true;
                    rent.IadeTarihi = DateTime.Now;
                    rentContext.save(rent);
                    Console.WriteLine("Kiralama başarıyla iade edildi.");
                }
                else
                {
                    Console.WriteLine("Bu kiralama henüz onaylanmamış veya zaten iade edilmiş.");
                }
            }
            else
            {
                Console.WriteLine("Kiralama bulunamadı.");
            }
        }

        public List<Kiralama> getListByUserId(long userId)
        {
            return rentContext.getListByUserId(userId);
            }

        public void showRequestRentList()
        {
            List<Kiralama> rents = rentContext.getList();
            for (int i = 0; i < rents.Count; i++)
            {
                if (!rents[i].OnaylandiMi)
            {
                    Console.WriteLine(rents[i]);
            }
        }
        }

        public void showRequestRentList(long userId)
        {
            List<Kiralama> rents = rentContext.getListByUserId(userId);
            for (int i = 0; i < rents.Count; i++)
                {
                if (!rents[i].OnaylandiMi)
            {
                    Console.WriteLine(rents[i]);
            }
        }
        }

        public void showRentList()
        {
            List<Kiralama> rents = rentContext.getList();
            for (int i = 0; i < rents.Count; i++)
            {
                if (rents[i].OnaylandiMi)
            {
                    Console.WriteLine(rents[i]);
            }
        }
        }

        public void showRentList(long userId)
        {
            List<Kiralama> rents = rentContext.getListByUserId(userId);
            for (int i = 0; i < rents.Count; i++)
                {
                if (rents[i].OnaylandiMi)
                {
                    Console.WriteLine(rents[i]);
                    }
                }
        }
    }
}
