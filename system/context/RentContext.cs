using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using KiyafetKiralama.entity;

namespace KiyafetKiralama.context
{
    internal class RentContext : List
    {
        public void save(Kiralama rent)
        {
            rents.Add(rent);
        }
        public List<Kiralama> getList()
        {
            return rents;
        }
        public List<Kiralama> getListUnacceptedRents()
        {
            return requestRents;
        }
        public Kiralama getRequestRentById(long id)
        {
            return requestRents.FirstOrDefault(x => x.Id == id);
        }
        public void addRequestRent(Kiralama rent)
        {
            requestRents.Add(rent);
        }
        public List<Kiralama> getListByUserId(long userId)
        {
            return rents.Where(x => x.KiralayanKullanici.Id == userId).ToList();
        }
        public Kiralama getRentById(long id)
        {
            return rents.FirstOrDefault(x => x.Id == id);
        }
        public void showRentList(List<Kiralama> a)
        {
            a = getList();
            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }
        }
        public void showRequestRentList(List<Kiralama> a)
        {
            a = getListUnacceptedRents();
            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }
        }
        public void remove(Kiralama rent)
        {
            requestRents.Remove(rent);
        }
    }
}
