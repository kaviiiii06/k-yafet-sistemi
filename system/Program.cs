using System.Linq;
using System.Runtime.Intrinsics.X86;
using KiyafetKiralama.api;
using KiyafetKiralama.entity;
using KiyafetKiralama.entity.@enum;

namespace KiyafetKiralama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            superEkle();
            adminekle();
            kıyafetekle();
            kullanıcıekle();

            Console.Clear();
            while (true)
            {
                Console.WriteLine("1) Kayıt Ol\n2) Kullanıcı Girişi\n3) Admin Girişi\n4) SuperAdmin Girişi\n5) Çıkış");
                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        KayitOl();
                        break;
                    case "2":
                        KullaniciGirisi();
                        break;
                    case "3":
                        AdminGirisi();
                        break;
                    case "4":
                        SuperGirisi();
                        break;
                    case "5":
                        Console.WriteLine("Çıkış yapıldı.");
                        return;
                    default:
                        Console.WriteLine("Hatalı giriş!!");
                        break;
                }
            }
        }

        static void KayitOl()
        {
            Console.WriteLine("Kayıt olmak için bekleyiniz...");
            Console.WriteLine("-----------------");
            UserController userController = new UserController();
            Console.WriteLine("Adınızı giriniz.");
            string name=Console.ReadLine();
            Console.WriteLine("Soyadınızı giriniz.");
            string surname=Console.ReadLine();
            Console.WriteLine("Username giriniz.");
            string username=Console.ReadLine();
            Console.WriteLine("Email adresinizi giriniz.");
            string email = Console.ReadLine().ToLower();
            Console.WriteLine("Şifre giriniz.");
            string password=Console.ReadLine();
            userController.save(name, surname, username, password, email, Rol.Musteri);
        }

        static void KullaniciGirisi()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Kullanıcı adı veya E-mail:");
                string input = Console.ReadLine();
                Console.WriteLine("Şifre: ");
                string password = Console.ReadLine();
                UserController userController = new UserController();
                Kullanici user1 = userController.userLogin(input, password);
                if (user1 != null)
                {
                    KullaniciMenu(user1.Id);
                    return;
                }
                else
                {
                    Console.WriteLine("Giriş Yapılamadı. Tekrar deneyiniz.");
                }
            }
        }

        static void KullaniciMenu(long id)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("1)Kıyafet Menüsü");
                Console.WriteLine("2)Kiralama Menüsü");
                Console.WriteLine("3) Ana Menü");
                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        KıyafetMenusu(id);
                        break;
                    case "2":
                        KiralamaMenusu(id);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim yaptınız. Lütfen 1, 2 ya da 3'ü tuşlayınız.");
                        break;
                }
            }
        }

        static void KıyafetMenusu(long id)
        {
            while (true)
            {
                Console.WriteLine("1)Tüm kıyafetler");
                Console.WriteLine("2)Kategoriye göre kıyafetler");
                Console.WriteLine("3)Üst Menü");
                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        ClothesController clothesController = new ClothesController();
                        clothesController.showList();
                        break;
                    case "2":
                        while (true)
                        {
                            Console.WriteLine("1) Abiye");
                            Console.WriteLine("2) Gelinlik");
                            Console.WriteLine("3) TakımElbise");
                            Console.WriteLine("4) Ceket");
                            Console.WriteLine("5) Gömlek");
                            Console.WriteLine("6) Pantolon");
                            Console.WriteLine("7) Etek");
                            Console.WriteLine("8) Bluz");
                            Console.WriteLine("9) Triko");
                            Console.WriteLine("10) Kaban");
                            Console.WriteLine("11) Mont");
                            Console.WriteLine("12) KıyafetSeti");
                            Console.WriteLine("13) Aksesuar");
                            Console.WriteLine("14) Üst Menü");
                            Console.WriteLine("Bir kategori seçiniz.");
                            string secim2 = Console.ReadLine();
                            switch (secim2)
                            {
                                case "1":
                                    ClothesController clothesController1 = new ClothesController();
                                    clothesController1.showListByCategory(Kategori.Abiye); break;
                                case "2":
                                    ClothesController _clothesController = new ClothesController();
                                    _clothesController.showListByCategory(Kategori.Gelinlik); break;
                                case "3":
                                    ClothesController __clothesController = new ClothesController();
                                    __clothesController.showListByCategory(Kategori.TakimElbise); break;
                                case "4":
                                    ClothesController ___clothesController = new ClothesController();
                                    ___clothesController.showListByCategory(Kategori.Ceket); break;
                                case "5":
                                    ClothesController ____clothesController = new ClothesController();
                                    ____clothesController.showListByCategory(Kategori.Gomlek); break;
                                case "6":
                                    ClothesController _____clothesController = new ClothesController();
                                    _____clothesController.showListByCategory(Kategori.Pantolon); break;
                                case "7":
                                    ClothesController ______clothesController = new ClothesController();
                                    ______clothesController.showListByCategory(Kategori.Etek); break;
                                case "8":
                                    ClothesController _______clothesController = new ClothesController();
                                    _______clothesController.showListByCategory(Kategori.Bluz); break;
                                case "9":
                                    ClothesController ________clothesController = new ClothesController();
                                    ________clothesController.showListByCategory(Kategori.Triko); break;
                                case "10":
                                    ClothesController _________clothesController = new ClothesController();
                                    _________clothesController.showListByCategory(Kategori.Kaban); break;
                                case "11":
                                    ClothesController __________clothesController = new ClothesController();
                                    __________clothesController.showListByCategory(Kategori.Mont); break;
                                case "12":
                                    ClothesController ___________clothesController = new ClothesController();
                                    ___________clothesController.showListByCategory(Kategori.KiyafetSeti); break;
                                case "13":
                                    ClothesController ____________clothesController = new ClothesController();
                                    ____________clothesController.showListByCategory(Kategori.Aksesuar); break;
                                case "14":
                                    return;
                                default:
                                    Console.WriteLine("Geçersiz seçim yaptınız. Lütfen 1-14 arası bir sayı giriniz.");
                                    break;
                            }
                        }
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim yaptınız. Lütfen 1, 2 ya da 3'ü tuşlayınız.");
                        break;
                }
            }
        }

        static void KiralamaMenusu(long id)
        {
            while (true)
            {
                Console.WriteLine("1) Kıyafet Kirala");
                Console.WriteLine("2) Kiralama Taleplerim");
                Console.WriteLine("3) Yapılan Kiralamalar");
                Console.WriteLine("4) Kiralama iadesi");
                Console.WriteLine("5) Üst Menü");
                string secim = Console.ReadLine();
                switch (secim) 
                {
                    case "1":
                        ClothesController clothesController1 = new ClothesController();
                        clothesController1.showList();
                       
                        long clothId;
                        while (true)
                        {
                            Console.WriteLine("Kiralamak istediğiniz kıyafetin ID'si: ");
                            string input = Console.ReadLine();
                            try
                            {
                                clothId = Convert.ToInt64(input);
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Geçersiz ID girdiniz. Lütfen sadece rakam kullanınız.");
                            }
                        }
                        int kiralamaGun;
                        while (true)
                        {
                            Console.WriteLine("Kaç gün kiralamak istiyorsunuz?");
                            string input = Console.ReadLine();
                            try
                            {
                                kiralamaGun = Convert.ToInt32(input);
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Geçersiz gün sayısı girdiniz. Lütfen sadece rakam kullanınız.");
                            }
                        }
                        Console.WriteLine("Kiralama notu giriniz.");
                        string note = Console.ReadLine();
                        RentController rentController = new RentController();
                        rentController.requestRent(id, clothId, kiralamaGun, note);
                        break;
                    case "2":
                        RentController rentController1 = new RentController();
                        rentController1.showRequestRentList(id);
                        break;
                    case "3":
                        RentController rentController2 = new RentController();
                        rentController2.showRentList(id);
                        break;
                    case "4":
                        RentController rentController3 = new RentController();
                        rentController3.showRentList(id);
                        Console.WriteLine("İade etmek istediğiniz kıyafetin ID'si: ");
                        string input2 = Console.ReadLine();
                            try
                            {
                            long rentId = Convert.ToInt64(input2);
                            rentController3.returnRents(rentId);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Geçersiz ID girdiniz. Lütfen sadece rakam kullanınız.");
                            }
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim yaptınız. Lütfen 1-5 arası bir sayı giriniz.");
                        break;
                }
            }
        }

        static void AdminGirisi()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Kullanıcı adı veya E-mail:");
                string input = Console.ReadLine();
                Console.WriteLine("Şifre: ");
                string password = Console.ReadLine();
                UserController userController = new UserController();
                Kullanici user1 = userController.adminLogin(input, password);
                if (user1 != null)
                {
                    AdminMenu(user1.Eposta);
                    return;
                }
                else
                {
                    Console.WriteLine("Giriş Yapılamadı. Tekrar deneyiniz.");
                }
            }
        }

        static void AdminMenu(string email)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("1)Kıyafet Menüsü");
                Console.WriteLine("2)Kiralama Menüsü");
                Console.WriteLine("3) Ana Menü");
                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        AdminKiyafetMenusu(email);
                        break;
                    case "2":
                        AdminKiralamaMenusu(email);
                        break;
                    case "3": 
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim yaptınız. Lütfen 1, 2 ya da 3'ü tuşlayınız.");
                        break;
                }
            }
        }

        static void AdminKiyafetMenusu(string email)
        {
            while (true)
            {
                Console.WriteLine("1)Kıyafet Ekle");
                Console.WriteLine("2)Kıyafet Sil");
                Console.WriteLine("3)Kıyafet Listele");
                Console.WriteLine("4)Üst Menü");
                string secim = Console.ReadLine();
                switch (secim) 
                {
                    case "1":
                        Console.WriteLine("Kıyafet adı: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Kıyafet açıklaması: ");
                        string description = Console.ReadLine();
                        Console.WriteLine("Stok miktarı: ");
                        string stock = Console.ReadLine();
                        Console.WriteLine("Fiyat: ");
                        string price = Console.ReadLine();
                        Console.WriteLine("Kategori: ");
                        Console.WriteLine("1) Abiye");
                        Console.WriteLine("2) Gelinlik");
                        Console.WriteLine("3) TakımElbise");
                        Console.WriteLine("4) Ceket");
                        Console.WriteLine("5) Gömlek");
                        Console.WriteLine("6) Pantolon");
                        Console.WriteLine("7) Etek");
                        Console.WriteLine("8) Bluz");
                        Console.WriteLine("9) Triko");
                        Console.WriteLine("10) Kaban");
                        Console.WriteLine("11) Mont");
                        Console.WriteLine("12) KıyafetSeti");
                        Console.WriteLine("13) Aksesuar");
                        string kategori = Console.ReadLine();
                        Kategori category = Kategori.Abiye;
                        switch (kategori)
                        {
                            case "1":
                                category = Kategori.Abiye;
                                break;
                            case "2":
                                category = Kategori.Gelinlik;
                                break;
                            case "3":
                                category = Kategori.TakimElbise;
                                break;
                            case "4":
                                category = Kategori.Ceket;
                                break;
                            case "5":
                                category = Kategori.Gomlek;
                                break;
                            case "6":
                                category = Kategori.Pantolon;
                                break;
                            case "7":
                                category = Kategori.Etek;
                                break;
                            case "8":
                                category = Kategori.Bluz;
                                break;
                            case "9":
                                category = Kategori.Triko;
                                break;
                            case "10":
                                category = Kategori.Kaban;
                                break;
                            case "11":
                                category = Kategori.Mont;
                                break;
                            case "12":
                                category = Kategori.KiyafetSeti;
                                break;
                            case "13":
                                category = Kategori.Aksesuar;
                                break;
                            default:
                                Console.WriteLine("Geçersiz kategori seçimi.");
                                return;
                        }
                        ClothesController clothesController = new ClothesController();
                        clothesController.save(name, description, Convert.ToInt32(stock), category, email, Convert.ToDouble(price));
                        break;
                    case "2":
                        ClothesController clothesController1 = new ClothesController();
                        clothesController1.showList();
                        Console.WriteLine("Silmek istediğiniz kıyafetin ID'si: ");
                            string input = Console.ReadLine();
                            try
                            {
                            long id = Convert.ToInt64(input);
                            clothesController1.delete(id);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Geçersiz ID girdiniz. Lütfen sadece rakam kullanınız.");
                            }
                        break;
                    case "3":
                        ClothesController clothesController2 = new ClothesController();
                        clothesController2.showList();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim yaptınız. Lütfen 1-4 arası bir sayı giriniz.");
                        break;
                }
            }
        }

        static void AdminKiralamaMenusu(string email)
        {
            while (true)
            {
                Console.WriteLine("1)Kiralama Talepleri");
                Console.WriteLine("2)Yapılan Kiralamalar");
                Console.WriteLine("3)Üst Menü");
                string secim = Console.ReadLine();
                switch (secim) 
                {
                    case "1":
                        RentController rentController = new RentController();
                        rentController.showRequestRentList();
                        Console.WriteLine("Onaylamak istediğiniz kiralama ID'si: ");
                            string input = Console.ReadLine();
                            try
                            {
                            long id = Convert.ToInt64(input);
                            rentController.confirm(id);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Geçersiz ID girdiniz. Lütfen sadece rakam kullanınız.");
                            }
                        break;
                    case "2":
                        RentController rentController1 = new RentController();
                        rentController1.showRentList();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim yaptınız. Lütfen 1-3 arası bir sayı giriniz.");
                        break;
                }
            }
        }

        static void SuperGirisi()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Kullanıcı adı veya E-mail:");
                string input = Console.ReadLine();
                Console.WriteLine("Şifre: ");
                string password = Console.ReadLine();
                UserController userController = new UserController();
                Kullanici user1 = userController.superLogin(input, password);
                if (user1 != null)
                {
                    SuperMenu(user1.Eposta);
                    return;
                }
                else
                {
                    Console.WriteLine("Giriş Yapılamadı. Tekrar deneyiniz.");
                }
            }
        }

        static void SuperMenu(string email)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("1)Admin Ekle");
                Console.WriteLine("2)Admin Sil");
                Console.WriteLine("3)Ana Menü");
                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        Console.WriteLine("Admin email: ");
                        string adminEmail = Console.ReadLine();
                        UserController userController = new UserController();
                        userController.saveAdmin(email, adminEmail);
                        break;
                    case "2":
                        Console.WriteLine("Admin email: ");
                        string adminEmail2 = Console.ReadLine();
                        UserController userController1 = new UserController();
                        userController1.removeAdmin(email, adminEmail2);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim yaptınız. Lütfen 1-3 arası bir sayı giriniz.");
                        break;
                }
            }
        }

        static void kıyafetekle()
        {
            ClothesController clothesController = new ClothesController();
            clothesController.save("Abiye", "Siyah abiye", 5, Kategori.Abiye, "admin@admin.com", 100);
            clothesController.save("Gelinlik", "Beyaz gelinlik", 3, Kategori.Gelinlik, "admin@admin.com", 200);
            clothesController.save("Takım Elbise", "Siyah takım elbise", 4, Kategori.TakimElbise, "admin@admin.com", 150);
            clothesController.save("Ceket", "Deri ceket", 6, Kategori.Ceket, "admin@admin.com", 80);
            clothesController.save("Gömlek", "Beyaz gömlek", 10, Kategori.Gomlek, "admin@admin.com", 50);
        }

        static void superEkle()
        {
            UserController userController = new UserController();
            userController.save("Super", "Admin", "superadmin", "1234", "super@admin.com", Rol.Personel);
        }

        static void adminekle()
        {
            UserController userController = new UserController();
            userController.save("Admin", "User", "admin", "1234", "admin@admin.com", Rol.Admin);
        }

        static void kullanıcıekle()
        {
            UserController userController = new UserController();
            userController.save("Kullanıcı", "Test", "kullanici", "1234", "kullanici@test.com", Rol.Musteri);
        }
    }
}
