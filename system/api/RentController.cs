using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiyafetKiralama.business.@abstract;
using KiyafetKiralama.business.concrete;
using KiyafetKiralama.context;
using KiyafetKiralama.entity;

namespace KiyafetKiralama.api
{
    internal class RentController
    {
        RentService _rentService;
        public RentController()
        {
            _rentService = new RentServiceImpl();
        }
        public void requestRent(long userId, long clothesId, int kiralamaGun, string note)
        {
            _rentService.requestRent(userId, clothesId, kiralamaGun, note);
        }
        public List<Kiralama> getListByUserId(long userId)
        {
            return _rentService.getListByUserId(userId);
        }
        public void confirm(long rentId)
        {
            _rentService.confirm(rentId);
        }
        public void returnRents(long rentId)
        {
            _rentService.returnRents(rentId);
        }
        public void showRequestRentList()
        {
            _rentService.showRequestRentList();
        }
        public void showRequestRentList(long userId)
        {
            _rentService.showRequestRentList(userId);
        }
        public void showRentList()
        {
            _rentService.showRentList();
        }
        public void showRentList(long userId)
        {
            _rentService.showRentList(userId);
        }
    }
}
