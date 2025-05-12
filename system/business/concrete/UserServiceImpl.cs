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
    internal class UserServiceImpl : UserService
    {
        private UserContext userContext = new UserContext();
        public void save(string name, string surname, string username, string password, string email, Rol role)
        {
            if (userContext.getUserByEmail(email) == null && userContext.getUserByUsername(username) == null)
            {
                Kullanici user = new Kullanici();
                user.Id = GenerateId.generateUserId();
                user.Ad = name;
                user.Soyad = surname;
                user.KullaniciAdi = username;
                user.Sifre = password;
                user.Eposta = email;
                user.Rol = role;
                userContext.save(user);
                Console.WriteLine("Kayıt başarılı.");
            }
            else
            {
                Console.WriteLine("Bu email veya kullanıcı adı zaten kullanılıyor.");
            }
        }
        public void saveAdmin(string superEmail, string adminEmail)
        {
            Kullanici super = userContext.getSuperByEmail(superEmail);
            if (super != null)
            {
                Kullanici admin = userContext.getUserByEmail(adminEmail);
                if (admin != null)
                {
                    admin.Rol = Rol.Admin;
                    userContext.save(admin);
                    Console.WriteLine("Admin başarıyla eklendi.");
                }
                else
                {
                    Console.WriteLine("Kullanıcı bulunamadı.");
                }
            }
            else
            {
                Console.WriteLine("Super admin yetkisi yok.");
            }
        }
        public void removeAdmin(string superEmail, string adminEmail)
        {
            Kullanici super = userContext.getSuperByEmail(superEmail);
            if (super != null)
            {
                Kullanici admin = userContext.getAdminByEmail(adminEmail);
                if (admin != null)
            {
                    admin.Rol = Rol.Musteri;
                    userContext.save(admin);
                    Console.WriteLine("Admin başarıyla silindi.");
                }
                else
            {
                    Console.WriteLine("Admin bulunamadı.");
                }
            }
            else
            {
                Console.WriteLine("Super admin yetkisi yok.");
            }
        }
        public void showUserList()
        {
            userContext.showUserList();
        }
        public void showAdminList()
        {
            userContext.showAdminList();
        }
        public Kullanici adminLogin(string input, string password)
        {
            Kullanici admin = userContext.getAdminByUsernameOrEmail(input);
            if (admin != null && admin.Sifre.Equals(password))
            {
                return admin;
            }
                return null;
        }
        public Kullanici userLogin(string input, string password)
        {
            Kullanici user = userContext.getUserByUsernameOrEmail(input);
            if (user != null && user.Sifre.Equals(password))
            {
                return user;
            }
                return null;
        }
        public Kullanici superLogin(string input, string password)
        {
            Kullanici super = userContext.getSuperByUsernameOrEmail(input);
            if (super != null && super.Sifre.Equals(password))
            {
                return super;
            }
                return null;
        }
        public Kullanici getUserByEmail(string email)
        {
            return userContext.getUserByEmail(email);
        }
        public Kullanici getAdminByEmail(string email)
        {
            return userContext.getAdminByEmail(email);
        }
        public Kullanici getUserById(long id)
        {
            return userContext.getUserById(id);
        }
    }
}
