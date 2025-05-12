using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiyafetKiralama.entity;
using KiyafetKiralama.entity.@enum;

namespace KiyafetKiralama.context
{
    internal class UserContext : List
    {
        public void save(Kullanici user)
        {
            if (user.Rol == Rol.Admin || user.Rol == Rol.Personel)
            {
                admins.Add(user);
            }
            if (user.Rol == Rol.Musteri)
            {
                users.Add(user);
            }
        }
        public void remove(Kullanici user)
        {
            if (user.Rol == Rol.Admin)
            {
                admins.Remove(user);
            }
            if (user.Rol == Rol.Musteri)
            {
                users.Remove(user);
            }
        }
        public Kullanici getUserByEmail(string email)
        {
            return users.FirstOrDefault(x => x.Eposta.Equals(email));
        }
        public Kullanici getSuperByEmail(string email)
        {
            return admins.FirstOrDefault(x => x.Eposta.Equals(email) && x.Rol == Rol.Personel);
        }
        public Kullanici getAdminByEmail(string email)
        {
            return admins.FirstOrDefault(x => x.Eposta.Equals(email));
        }
        public Kullanici getAdminByUsername(string username)
        {
            return admins.FirstOrDefault(x => x.Eposta.Equals(username));
        }
        public Kullanici getUserByUsername(string username)
        {
            return admins.FirstOrDefault(x => x.Eposta.Equals(username));
        }
        public List<Kullanici> getUserList()
        {
            return users;
        }
        public List<Kullanici> getAdminList()
        {
            return admins;
        }
        public void showUserList()
        {
            for (int i = 0; i < getUserList().Count; i++)
            {
                Console.WriteLine(getUserList()[i]);
            }
        }
        public void showAdminList()
        {
            for (int i = 0; i < getAdminList().Count; i++)
            {
                Console.WriteLine(getAdminList()[i]);
            }
        }
        public Kullanici getAdminByUsernameOrEmail(string input)
        {
            return admins.FirstOrDefault(x => x.KullaniciAdi.Equals(input) || x.Eposta.Equals(input));
        }
        public Kullanici getUserByUsernameOrEmail(string input)
        {
            return users.FirstOrDefault(x => x.KullaniciAdi.Equals(input) || x.Eposta.Equals(input));
        }
        public Kullanici getSuperByUsernameOrEmail(string input)
        {
            return admins.FirstOrDefault(x => (x.KullaniciAdi.Equals(input) || x.Eposta.Equals(input)) && x.Rol == Rol.Personel);
        }
        public Kullanici getUserById(long id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }
    }
}
