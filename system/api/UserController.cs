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
    internal class UserController
    {
        UserService _userService;
        public UserController()
        {
            _userService = new UserServiceImpl();
        }
        public void save(string name, string surname, string username, string password, string email, Rol role)
        {
            _userService.save(name,surname, username, password, email, role);
        }
        public Kullanici adminLogin(string userNameOrEmail, string password)
        {
           return _userService.adminLogin(userNameOrEmail, password);
        }
        public Kullanici userLogin(string userNameOrEmail, string password)
        {
            return _userService.userLogin(userNameOrEmail, password);
        }
        public Kullanici getUserByEmail(string email)
        {
            return _userService.getUserByEmail(email);
        }
        public Kullanici getAdminByEmail(string email)
        {
            return _userService.getAdminByEmail(email);
        }
        public Kullanici getUserById(long id)
        {
            return _userService.getUserById(id);
        }
        public void saveAdmin(string adminEmail, string userEmail)
        {
            _userService.saveAdmin(adminEmail, userEmail);
        }
        public void removeAdmin(string superEmail, string adminEmail)
        {
            _userService.removeAdmin(superEmail, adminEmail);
        }
        public Kullanici superLogin(string userNameOrEmail, string password)
        {
           return _userService.superLogin(userNameOrEmail, password);
        }
        public void showUserList()
        {
            _userService.showUserList();
        }
        public void showAdminList()
        {
            _userService.showAdminList();
        }
    }
}
