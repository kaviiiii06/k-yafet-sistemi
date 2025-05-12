using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiyafetKiralama.entity;
using KiyafetKiralama.entity.@enum;

namespace KiyafetKiralama.business.@abstract
{
    internal interface UserService
    {
        public void save(string name,string surname,string username,string password,string email, Rol role);
        public Kullanici userLogin(string userNameOrEmail,string password);
        public Kullanici adminLogin(string userNameOrEmail, string password);
        public Kullanici getUserByEmail(string email);
        public Kullanici getAdminByEmail(string email);
        public Kullanici getUserById(long id);
        public void saveAdmin(string adminEmail, string userEmail);
        public void removeAdmin(string superEmail, string adminEmail);
        public Kullanici superLogin(string userNameOrEmail, string password);
        public void showUserList();
        public void showAdminList();
    }
}
