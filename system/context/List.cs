using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiyafetKiralama.entity;

namespace KiyafetKiralama.context
{
    internal class List
    {
        protected static List<Kullanici> users = new List<Kullanici>();
        protected static List<Kullanici> admins = new List<Kullanici>();
        protected static List<Kiyafet> cloth = new List<Kiyafet>();
        protected static List<Kiralama> rents = new List<Kiralama>();
        protected static List<Kiralama> requestRents = new List<Kiralama>();
    }
}
