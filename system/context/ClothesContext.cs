using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiyafetKiralama.entity;
using KiyafetKiralama.entity.@enum;

namespace KiyafetKiralama.context
{
    internal class ClothesContext : List
    {
        public void save(Kiyafet clothes)
        {
            cloth.Add(clothes);
        }
        public Kiyafet getClothesById(long id)
        {
            return cloth.FirstOrDefault(x => x.Id == id);
        }
        public Kiyafet getClothesByName(string name)
        {
            return cloth.FirstOrDefault(x => x.Ad.Equals(name));
        }
        public void delete(Kiyafet clothes)
        {
            cloth.Remove(clothes);
        }
        public List<Kiyafet> getList()
        {
            return cloth;
        }
        public void showList()
        {
            for (int i = 0; i < getList().Count; i++)
            {
                Console.WriteLine(getList()[i]);
            }
        }
        public List<Kiyafet> getListByCategory(Kategori category)  
        {
            return cloth.Where(x => x.Kategori == category).ToList();
        }
        public void showListByCategory(Kategori category)
        {
            List<Kiyafet> a = getListByCategory(category);
            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }
        }
    }
}
