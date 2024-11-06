using System.Reflection.Emit;
using static gettersetter.Kutuphane;

namespace gettersetter
{

    class BankaHesabi
    {
        /*Bir BankaHesabi sınıfı oluşturun ve şu özellikleri ekleyin:
Özellikler:
HesapNumarasi (string), Bakiye (decimal)
Get/Set:
Bakiye özelliği için sadece sınıf içinden erişilebilen bir set metodu
yazın.
Yapıcı
Metot: Hesap numarasını ve ilk bakiyeyi alarak başlatan bir yapıcı metot
yazın.
Metotlar:
ParaYatir(decimal miktar) ve ParaCek(decimal miktar) metotları yazın. Para
çekme işleminde bakiye yetersizse işlem yapılmamalı.*/


        private string HesapNumarasi { get; set; }
        private decimal Bakiye { get; set; }

        public string hesapNo
        {
            get { return HesapNumarasi; }
            set { HesapNumarasi = value; }
        }

        public decimal bakiye {
            get { return Bakiye; }
            private set { Bakiye = value; } }

        public BankaHesabi(string hesapNo, decimal bakiye) {
            HesapNumarasi = hesapNo;
            Bakiye = bakiye;
            
        }
        public void ParaYatir(decimal miktar)
        {
           Bakiye += miktar;
            Console.WriteLine($"{miktar}'tl yüklediniz. Güncel bakiyeniz {Bakiye}'tl.");
            
        }
        public void ParaCek(decimal miktar)
        {
            if (miktar < Bakiye && miktar != 0)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar}'tl çektiniz. Güncel bakiyeniz {Bakiye}'tl.");
            }
            else throw new ArgumentException("Çekilecek para bakiyeden fazla veya sıfır olamaz.");
            
        }

    }


    class Urun
    {
        /*Bir Urun sınıfı oluşturun ve özellikleri tanımlayın:
 Özellikler: Ad (string), Fiyat (decimal), Indirim (decimal)
 Get/Set: İndirim için get/set metodları kullanın. İndirimi 0-50% arasında sınırlandırın.
 Yapıcı Metot: Ad ve fiyat bilgilerini parametre olarak alıp başlatan bir yapıcı metot
tanımlayın.
 Metot: IndirimliFiyat() metodu, indirimli fiyatı döndürsün.*/
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        private decimal Indirim { get; set; }

        public Urun(string ad, decimal fiyat, decimal indirim)
        {
            Ad = ad;
            Fiyat = fiyat;
            Indirim = indirim;
        }

        public decimal indirim
        {
            get { return Indirim; }
            set { if (value > 0 && value <= 50)
                {
                    Indirim = value;
                    Console.WriteLine($" indirim oranınız %{Indirim}");
                   
                }
                else throw new ArgumentException(" lütfen belitilen oranların dışına çıkmayın");
            }

        }
        public void IndirimliFiyat()
        {
            decimal IndirimMiktari = Fiyat * Indirim / 100;
            decimal SonFiyat = Fiyat - IndirimMiktari;
            Console.WriteLine($" indirmli fiyatınız {SonFiyat}, inen miktar {IndirimMiktari}");
        }
    }

    class Kisi
    {
        /*Bir Kisi sınıfı oluşturun ve kişilerin adres defterinde kayıtlarını
tutmak için aşağıdaki özellik ve metotları ekleyin:
Özellikler:
Ad, Soyad, TelefonNumarasi (string türünde)
Yapıcı
Metot: Ad, soyad ve telefon numarasını alarak başlatan bir yapıcı metot
tanımlayın.
Metot:
KisiBilgisi() – Bu metot, kişinin tam adını ve telefon numarasını
döndürsün.*/



        public string Ad { get; set;}
        public string Soyad { get; set; }
        private string TelefonNumarasi{ get; set; }

        public Kisi(string ad, string soyad, string telefonNumarasi)
        {
            Ad = ad;
            Soyad = soyad;
            TelefonNumarasi = telefonNumarasi;


        }

        public string telefonNumarasi { get { return TelefonNumarasi; } 
            set {

                if (TelefonNumarasi.Length == 11)
                    TelefonNumarasi = value;
                else throw new ArgumentException("telefon numarası 11 haneli olmalı");
            } }

        public void KisiBilgisi() {
            Console.WriteLine($"İsim: {Ad} Soyisim: {Soyad} telefon numarasi: {TelefonNumarasi}");
        }

    }


    class AracKiralama
    {/*Bir KiralikArac sınıfı oluşturun. Bu sınıfta araç kiralama işlemleri için özellikler ve metotlar
tanımlayın:
 Özellikler: Plaka (string), GunlukUcret (decimal), MusaitMi (bool)
 Yapıcı Metot: Plaka ve günlük kiralama ücretini alarak başlatan bir yapıcı metot
yazın. MusaitMi varsayılan olarak true olmalı.
 Metotlar: AraciKirala(), AraciTeslimEt() – Bu metotlar aracın uygunluk durumunu
değiştirsin.*/

        private string Plaka { get; set; }
        private decimal GunlukUcret { get; set; }
        public bool MusaitMi { get; set; }

        public string plaka
        {
            get { return Plaka; }
            private set { Plaka = value; }
        }

        public decimal ucret { get { return GunlukUcret; } 
           private set { GunlukUcret = value; } }


        public AracKiralama(string plaka, decimal gunlukUcret)
        {
            Plaka = plaka;
            GunlukUcret = gunlukUcret;
            MusaitMi = true;
        }

        public void AracKirala() {

            Console.WriteLine($"Araç kiralanmıştır, günlük ücret {GunlukUcret}'tl dir. Müsait araç yoktur");
            MusaitMi = false;
        }

        public void AraciTeslimEt() {
            Console.WriteLine($"Araç teslim edilmiştir. Araç müsaittir");
            MusaitMi = true;

        }

        

    }

    class Kutuphane
    {
        /*Bir Kutuphane sınıfı oluşturun ve bu sınıfta kitap ekleme ve listeleme
özelliklerini ekleyin:
Özellik:
Kitaplar (List<Kitap> türünde)
Yapıcı
Metot: Kitap listesi boş olarak başlatılsın.
Metotlar:
KitapEkle(Kitap yeniKitap) – Bu metot kitap eklesin ve KitaplariListele()
metodu tüm kitapları ekrana yazdırsın. this anahtar kelimesini kullanarak
eklenen kitabın kütüphaneye ait olduğunu belirtin.*/
        public class Kitap
        {
            public string KitapAdi { get; set; }
            public string YazarAdi { get; set; }

            // Kitap sınıfının yapıcı metodu
            public Kitap(string kitapAdi, string yazarAdi)
            {
                KitapAdi = kitapAdi;
                YazarAdi = yazarAdi;
            }
        }

        // Kütüphaneyi temsil eden sınıf
        private List<Kitap> kitaplar;

        // Kutuphane sınıfının yapıcı metodu
        public Kutuphane()
        {
            kitaplar = new List<Kitap>(); // Başlangıçta boş kitap listesi
        }

        // Kitap ekleme metodu
        public void KitapEkle(string kitapAdi, string yazarAdi)
        {
            Kitap yeniKitap = new Kitap(kitapAdi, yazarAdi); // Yeni kitap oluşturuluyor
            kitaplar.Add(yeniKitap); // Kitap listeye ekleniyor
            Console.WriteLine($"{kitapAdi} kitabı, {yazarAdi} tarafından kütüphaneye eklendi.");
        }

        // Kitapları listeleme metodu
        public void KitaplariListele()
        {
            if (kitaplar.Count == 0)
            {
                Console.WriteLine("Henüz hiç kitap eklenmedi.");
            }
            else
            {
                Console.WriteLine("Kütüphanedeki kitaplar:");
                foreach (var kitap in kitaplar)
                {
                    Console.WriteLine($"kitap adı: {kitap.KitapAdi} | Yazar: {kitap.YazarAdi}");
                }
            }
        }

        // Kullanıcıdan kitap bilgilerini alıp ekleyen metod
        public void KitapBilgileriniAlVeEkle()
        {
            Console.Write("Kitap adı nedir? ");
            string kitapAdi = Console.ReadLine(); // Kitap adı alınır

            Console.Write("Yazar adı kimdir? ");
            string yazarAdi = Console.ReadLine(); // Yazar adı alınır

            // Kitap bilgileriyle kitap eklenir
            KitapEkle(kitapAdi, yazarAdi);
        }
    } 


        class program
        {
            public static void Main(string[] args)
            {
                AracKiralama araba = new AracKiralama("26 ab 578", 2500);
                araba.AracKirala();
                araba.AraciTeslimEt();
                araba.AracKirala();

                BankaHesabi banka = new BankaHesabi("771727818", 1250);
                banka.ParaYatir(5467);
                banka.ParaCek(300);

                Kisi kisi = new Kisi("leyla", "Akdoğan", "05473822989");
                kisi.KisiBilgisi();


                Kutuphane kitap = new Kutuphane();
                kitap.KitapEkle("jdnvj", "dnfnfn");
                kitap.KitaplariListele();
                

                Urun urun = new Urun("kalem", 45, 60);
            
            urun.IndirimliFiyat();
            }
        }
    }

