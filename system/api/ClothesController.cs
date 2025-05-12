using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiyafetKiralama.business.@abstract;
using KiyafetKiralama.business.concrete;
using KiyafetKiralama.context;
using KiyafetKiralama.entity;
using KiyafetKiralama.entity.@enum;

namespace KiyafetKiralama.api
{
    internal class ClothesController
    {
        ClothesService _clothesService;
        public ClothesController()
        {
            _clothesService = new ClothesServiceImpl();
        }
        public void save(string name, string description, int stock, Kategori category, string kayitYapanEmail, double price)
        {
            _clothesService.save(name, description, stock, category, kayitYapanEmail, price);
        }
        public Kiyafet getClothesById(long id)
        {
            return _clothesService.getClothesById(id);
        }
        public void delete(long id)
        {
            _clothesService.delete(id);
        }
        public void showList()
        {
            _clothesService.showList();
        }
        public void showListByCategory(Kategori category)
        {
            _clothesService.showListByCategory(category);
        }
    }
}
