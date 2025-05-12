using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiyafetKiralama.entity;

namespace KiyafetKiralama.business.@abstract
{
    internal interface RentService
    {
        public void requestRent(long userId, long clothesId, int kiralamaGun, string note);
        public void confirm(long rentId);
        public void returnRents(long rentId);
        public List<Kiralama> getListByUserId(long userId);
        public void showRequestRentList();
        public void showRequestRentList(long userId);
        public void showRentList();
        public void showRentList(long userId);
    }
}
