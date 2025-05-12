using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiyafetKiralama.entity;
using KiyafetKiralama.entity.@enum;

namespace KiyafetKiralama.business.@abstract
{
    internal interface ClothesService
    {
        public void save(string name, string description, int stock, Kategori category, string kayitYapanEmail, double price);
        public Kiyafet getClothesById(long id);
        public void delete(long id);
        public void showList();
        public void showListByCategory(Kategori category);
    }
}
