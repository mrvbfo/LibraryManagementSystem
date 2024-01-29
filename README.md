# Kütüphane Veritabanı Yönetim Sistemi
Kütüphane Veritabanı Sisteminde kitaplar, yazarlar, üyeler, yayınevi ve kütüphaneciler arasındaki ilişkiler izlenebilmekte ve bilgiler kaydedilmektedir.
## Sistemin Genel Özellikleri
### Kullanılan Teknolojiler
Bu projeyi, Windows Forms C# ve MySql kullanarak geliştirdim. Kütüphane yönetim sistemi, kullanıcı dostu bir arayüz sunmak amacıyla C# Windows Form uygulama altyapısı üzerine inşa edilmiştir. Bu sayede kullanıcılar kütüphane yönetimini etkili bir şekilde yönetebilirler. C# programlama dilini kullanarak MySQL veritabanı ile etkileşimli bir bağlantı kurmuş ve bu sayede kapsamlı sorgulama işlemleri gerçekleştirebilmektedir. Bu entegrasyon, kullanıcıların kitap arama, üye bilgilerini sorgulama, ödünç alma durumu kontrolü gibi işlemleri hızlı ve güvenilir bir şekilde gerçekleştirmelerine olanak tanımaktadır.
### Sistemin ER diyagramı
<img src="https://github.com/mrvbfo/LibraryManagementSystem/blob/main/images/LibraryER.png" alt="alt text" width="700" height="700">

## Giriş Ekranı 
Sadece kütüphanecilerin sisteme giriş yapabilmesini sağlar. Kütüphaneciler tarafindan sisteme email ve şifre ile giriş yapılabilir.
<img src="https://github.com/mrvbfo/LibraryManagementSystem/blob/main/images/giris.png" alt="alt text" width="600" height="400">

## Menü Ekranı
Sistemdeki tüm işlemler bu ekrandan seçim yapılarak gerçekleştirilir.
<img src="https://github.com/mrvbfo/LibraryManagementSystem/blob/main/images/men%C3%BC.png" alt="alt text" width="600" height="400">

## Üye Yönetimi
Kullanıcı ekleme, güncelleme ve silme işlemleri yapılır. Kullanıcıların yönetimi için bir kütüphaneci seçilir.
<img src="https://github.com/mrvbfo/LibraryManagementSystem/blob/main/images/member.png" alt="alt text" width="600" height="400">

## Kütüphaneci Yönetimi
Kütüphaneci ekleme, silme ve güncelleme imkanı sunar.
<img src="https://github.com/mrvbfo/LibraryManagementSystem/blob/main/images/librarian.png" alt="alt text" width="600" height="400">

## Kitap Yönetimi
Kitap eklemek, güncellemek ve silmek mümkündür. Bu işlem yapılırken kitap yönetimi için kütüphaneci seçilir.
<img src="https://github.com/mrvbfo/LibraryManagementSystem/blob/main/images/book.png" alt="alt text" width="600" height="400">

## Kitap Ödünç Verme
Kullanıcıların kitap ödünç alma işlemleri gerçekleştirilir. Borrow ve Books tablosu üzerinden sorgular yapılır. Ödünç verilmiş ama iadesi yapılmamış bir kitabın tekrar ödünç verilmesi ve borcunu ödememiş kullanıcılara kitap ödünç verilmesi engellenir. Ödünç verilmiş kitap için book_status değeri 2’dir.

<img src="https://github.com/mrvbfo/LibraryManagementSystem/blob/main/images/issue.png" alt="alt text" width="600" height="400">

## Kitap Arama
Kitap adına göre, yayınevine ve yazar adına göre arama işlemleri gerçekleştirilir.
<img src="https://github.com/mrvbfo/LibraryManagementSystem/blob/main/images/booksearch.png" alt="alt text" width="600" height="400">

## Borç Ödeme
Borrow ve Member tablosu üzerinden sorgular yapılarak borçlu olan kullanıcılar listelenir. Borç ödenecek kullanıcıya çift tıklanarak basit bir şekilde ödeme yapılabilir.

<img src="https://github.com/mrvbfo/LibraryManagementSystem/blob/main/images/borrow.png" alt="alt text" width="600" height="400">

## Kitap İade İşlemi
Kitap iade etme işlemleri gerçekleştirilir. Borrow tablosu üzerinden sorgu yapılır ve ödünç verilmiş kitaplar listelenir. Kitap iadesi yapılırken gecikme ücreti(delay_fine) hesaplanır. Hesaplama işlemi gecikilen gün sayısının 100 katı olacak şekilde SQL sorgusu üzerinden yapılır. İade yapılmış bir kitap için book_status değeri 1’dir.

<img src="https://github.com/mrvbfo/LibraryManagementSystem/blob/main/images/return.png" alt="alt text" width="600" height="400">

## Kitap Listeleri
Tüm kitaplar, ödünç verilmiş kitaplar, mevcut alınabilir kitaplar listelenir.
<img src="https://github.com/mrvbfo/LibraryManagementSystem/blob/main/images/booklist.png" alt="alt text" width="600" height="400">

