using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace antrenman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string user_admin = "admin";
            string admin_pass = "123";
            string member = "member";
            string member_pass = "123";
            string[] urunler = new string[3];
            int[] fiyatlar = new int[3];
            string[] products = { "Sigara", "elma", "Cips" };
            int[] price = { 40, 32, 20 };
            int secilen_urun_sayisi = 0;
            int bakiye = 200;
            string[] secilenUrunler = new string[3];
            int kalan = 0;

            bool run = true;

            while (run)
            {


                Console.WriteLine("1- Admin Girişi");
                Console.WriteLine("2- Üye Girişi");
                Console.WriteLine("0- Çıkış");
                int secim = int.Parse(Console.ReadLine());

                if (secim == 0)
                {
                    run = false;
                }
                else if (secim == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Admin Girişi");
                    Console.WriteLine("Kullanici adi : ");
                    string user = Console.ReadLine();
                    Console.WriteLine("Şifre :");
                    string pass = Console.ReadLine();


                    if (user == user_admin && pass == admin_pass)
                    {
                        Console.WriteLine("Kullanici girişi Başarılı");
                        Console.WriteLine();
                        Console.WriteLine("ürün eklemek için - 1 ");
                        Console.WriteLine("Ürünleri Güncellemek için - 2");
                        int secim1 = int.Parse(Console.ReadLine());
                        if (secim1 == 1)
                        {
                            Console.WriteLine("Ürün ekleme: ");
                            for (int i = 0; i < urunler.Length; i++)
                            {
                                Console.WriteLine($"\n{i + 1}. Ürün Bilgileri");
                                Console.WriteLine("Ürün adı :");
                                urunler[i] = Console.ReadLine();
                                Console.WriteLine("Fiyatı : ");
                                fiyatlar[i] = int.Parse(Console.ReadLine());


                            }
                            Console.Clear();
                            Console.WriteLine("Ürünler");
                            Console.WriteLine();
                            for (int i = 0; i < fiyatlar.Length; i++)
                            {
                                Console.WriteLine($"{i + 1}. {urunler[i]} {fiyatlar[i]} TL ");
                            }
                            Console.WriteLine("Ürünler eklendi");
                            Console.WriteLine("Giriş ekranına dönülüyor");
                            Thread.Sleep(2000);
                        }
                        else if (secim1 == 2)
                        {
                            Console.WriteLine("Girilen ürünleri Güncellemek için 1");
                            Console.WriteLine("Sistem ürünlerini Güncellemek için 2");
                            string select = Console.ReadLine();
                            if (select == "1")
                            {
                                for (int i = 0; i < fiyatlar.Length; i++)
                                {
                                    Console.WriteLine($"\n{i + 1}. Ürün Bilgileri");
                                    Console.WriteLine("Ürün Adı : ");
                                    urunler[i] = Console.ReadLine();
                                    Console.WriteLine("Fiyatı :");
                                    fiyatlar[i] = Convert.ToInt32(Console.ReadLine());

                                }
                                Console.Clear();
                                Console.WriteLine("Ürünler Listesi");
                                Console.WriteLine();
                                for (int i = 0; i < urunler.Length; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {urunler[i]} : {fiyatlar[i]} Tl");
                                }

                                Console.WriteLine("İşlem başarılı");
                                Console.WriteLine("Giriş ekranına dönülüyor");
                                Thread.Sleep(2000);
                                Console.WriteLine();
                            }
                            if (select == "2")
                            {
                                Array.Clear(products, 0, products.Length);
                                Array.Clear(price, 0, price.Length);
                                string[] pro2 = new string[products.Length];
                                int[] pri2 = new int[price.Length];

                                for (int i = 0; i < fiyatlar.Length; i++)
                                {
                                    Console.WriteLine("Ürün adı :");
                                    pro2[i] = Console.ReadLine();
                                    Console.WriteLine("Ürün fiyatı : ");
                                    pri2[i] = int.Parse(Console.ReadLine());
                                }
                                Console.WriteLine("Sistem Ürünleri Güncellendi");
                                Console.Clear();

                                Console.WriteLine("Ürünler Listesi");
                                for (int i = 0; i < pri2.Length; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {pro2[i]} : {pri2[i]} Tl");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Giriş Başarısız Bir daha deneyin");
                    }
                }
                else if (secim == 3)
                {
                    break;
                }
                else if (secim == 2)
                {
                    Console.WriteLine("Kullanici Girişi ");
                    Console.WriteLine();
                    Console.WriteLine("Kullanici Adı:");
                    string kullaniciadi = Console.ReadLine();
                    Console.WriteLine("Şifre :");
                    string ksifre = Console.ReadLine();

                    if (member == kullaniciadi && member_pass == ksifre)
                    {
                        Console.WriteLine("Giriş Başarılı");
                        Console.WriteLine("Ürünlere yönlendiriliyorsunuz");
                        Thread.Sleep(2000);

                        Console.WriteLine("Adminin girdiği ürünler için 1 ");
                        Console.WriteLine("Sistem ürünleri için 2 ");
                        int ksecim = Convert.ToInt32(Console.ReadLine());

                        if (ksecim == 1)
                        {
                            for (int i = 0; i < urunler.Length; i++)
                            {
                                Console.WriteLine($"{i + 1}. {urunler[i]} : {fiyatlar[i]} Tl");
                            }
                            Console.WriteLine("\nÜrün seçmek için numarasını girin (1-3), B tuşuna basarak alışverişi tamamlayın: ");


                            bool alısveris = false;
                            while (!alısveris)
                            {
                                string secim1 = Console.ReadLine();

                                if (secim1.ToUpper() == "B")
                                {
                                    alısveris = true;
                                    Console.WriteLine("");
                                    break;
                                }
                                int urun_Secim = Convert.ToInt16(secim1);
                                if (urun_Secim >= 1 && urun_Secim <= 3)
                                {
                                    int secilenUrunİndex = urun_Secim - 1;
                                    int secilenUrunFiyat = fiyatlar[secilenUrunİndex];

                                    if (secilen_urun_sayisi < 3 && secilenUrunFiyat <= bakiye)
                                    {
                                        secilenUrunler[secilen_urun_sayisi] = urunler[secilenUrunİndex];
                                        secilen_urun_sayisi++;
                                        kalan = bakiye - secilenUrunFiyat;
                                        Console.WriteLine("Güncel Bakiye: " + kalan);
                                    }
                                    else if (secilen_urun_sayisi >= 3)
                                    {
                                        Console.WriteLine("En fazla 3 ürün seçebilirsiniz!");
                                        Console.WriteLine("Menü için b ye basınız");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Bakiyeniz yetersiz. Ürün seçilemedi.");

                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Geçersiz ürün seçimi ");
                                }
                            }

                        }
                        else if (ksecim == 2)
                        {
                            for (int i = 0; i < products.Length; i++)
                            {
                                Console.WriteLine($"{i + 1}. {products[i]} : {price[i]} Tl");
                            }
                            Console.WriteLine("\nÜrün seçmek için numarasını girin (1-3), B tuşuna basarak alışverişi tamamlayın: ");
                            bool alısveris = false;

                            while (!alısveris)
                            {
                                string secim1 = Console.ReadLine();

                                if (secim1.ToUpper() == "B")
                                {
                                    alısveris = true;
                                    Console.WriteLine("");
                                    break;
                                }

                                int urunSecim = Convert.ToInt32(secim1);

                                if (urunSecim >= 1 && urunSecim <= 3)
                                {
                                    int secilenUrunİndex = urunSecim - 1;
                                    int secilenUrunFiyat = price[secilenUrunİndex];

                                    if (secilen_urun_sayisi < 3 && secilenUrunFiyat <= bakiye)
                                    {
                                        secilenUrunler[secilen_urun_sayisi] = products[secilenUrunİndex];
                                        secilen_urun_sayisi++;
                                        kalan = bakiye - secilenUrunFiyat;
                                        Console.WriteLine("Ürün seçildi!");
                                        Console.WriteLine("Güncel Bakiye: " + kalan);
                                    }
                                    else if (secilen_urun_sayisi >= 3)
                                    {
                                        Console.WriteLine("En fazla 3 ürün seçebilirsiniz!");
                                        Console.WriteLine("Menü için b ye basınız");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Bakiyeniz yetersiz. Ürün seçilemedi.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Geçersiz ürün seçimi ");
                                }
                            }
                        }

                    }


                }


            }
        }
    }
}



