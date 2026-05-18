# 📚 MyPersonalLibrary (Kişisel Kütüphane Yönetim Sistemi)

MyPersonalLibrary, okuma alışkanlıklarınızı takip etmek, kitaplığınızdaki kitapları yönetmek ve okuma süreçlerinizi (başlama/bitirme tarihleri, puanlama) kayıt altına almak için tasarlanmış **Katmanlı Mimari (N-Tier Architecture)** tabanlı bir masaüstü uygulamasıdır.

Bu proje, yazılım geliştirme prensiplerine (OOP, SOLID) ve temiz kod (Clean Code) standartlarına uygun olarak geliştirilmiştir. Projede geleneksel ADO.NET yönteminden modern Entity Framework Core (ORM) teknolojisine başarılı bir geçiş (refactoring) simüle edilmiştir.

---



## 🏗️ Proje Mimarisi & Katmanlar

Proje, bağımlılıkları en aza indirmek (Loose Coupling) amacıyla 4 ana katmandan oluşturulmuştur:

1. **`MyPersonalLib.Entities`:** Veritabanı tablolarının C# tarafındaki karşılığı olan somut nesneleri (`Book` sınıfı) barındırır.
2. **`MyPersonalLib.DataAccess`:** Veritabanı işlemlerinin yapıldığı katmandır. `IBookDal` arayüzü ile soyutlanmıştır. İçerisinde hem **ADO.NET** (`AdoNetBookDal`) hem de **Entity Framework Core** (`EfBookDal`) implementasyonlarını barındırır.
3. **`MyPersonalLib.Business`:** UI ile DataAccess arasında köprü görevi gören iş mantığı katmanıdır (`BookManager`).
4. **`MyPersonalLib.UI`:** Kullanıcının etkileşime girdiği **Windows Forms** arayüzüdür.

> **💡 Gevşek Bağlılık Başarısı:** İş mantığı (Business) ve Arayüz (UI) katmanlarındaki tek bir satır koda dokunulmadan, sadece bağımlılık enjeksiyonu esnasında `new AdoNetBookDal()` ifadesi `new EfBookDal()` olarak değiştirilerek tüm proje başarıyla Entity Framework'e taşınabilmiştir.

---

## 🛠️ Kullanılan Teknolojiler

* **Dil:** C#
* **Veri Tabanı:** Microsoft SQL Server (LocalDB)
* **Veri Erişimi (ORM):** * ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataReader`)
  * Entity Framework Core (`DbContext`, LINQ)
* **Arayüz:** Windows Forms (WinForms)

---

## 🚀 Öne Çıkan Özellikler

* **Esnek Tarih Yönetimi:** Yeni eklenen kitaplar "Henüz Başlanmadı" statüsünde eklenebilir.
* **Güvenli Sorgular:** ADO.NET katmanında parametrik sorgular kullanılmıştır.

---

## 📅 Yol Haritası (Roadmap)

- [x] Katmanlı mimari altyapısının kurulması.
- [x] ADO.NET ile CRUD işlemlerinin tamamlanması.
- [x] Entity Framework Core entegrasyonu ve kodun refactor edilmesi.
- [ ] UI katmanının masaüstünden modern **ASP.NET Core MVC** (Web) mimarisine taşınması.