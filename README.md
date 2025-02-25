# HepsiApi-OnionCQRS

Bu proje, Onion Architecture ve CQRS prensipleri kullanılarak geliştirilmiş bir ASP.NET Core Web API uygulamasıdır. MediatR kütüphanesi ile komut ve sorguların ayrıştırılması sağlanmıştır.

## 📌 Proje Yapısı

Proje, katmanlı bir mimariye sahiptir:

- **Core Katmanı**: İş mantığını ve domain modellerini içerir.
- **Infrastructure Katmanı**: Veri erişim ve diğer altyapı işlemlerini yönetir.
- **Application Katmanı**: CQRS komutlarını ve sorgularını barındırır.
- **Presentation Katmanı**: API'nin sunum katmanıdır, HTTP isteklerini karşılar.

## 🚀 Kullanılan Teknolojiler

- ASP.NET Core Web API
- Entity Framework Core
- MediatR
- AutoMapper
- Onion Architecture
- CQRS

## ⚙️ Kurulum

Projeyi çalıştırmak için aşağıdaki adımları takip edebilirsiniz:

1. **Projeyi klonlayın:**
   ```sh
   git clone https://github.com/bhmberkan/HepsiApi-OnionCQRS.git
   ```
2. **Bağımlılıkları yükleyin:**
   ```sh
   dotnet restore
   ```
3. **Veritabanını oluşturun:**
   ```sh
   dotnet ef database update
   ```
4. **Projeyi çalıştırın:**
   ```sh
   dotnet run
   ```

## 📌 API Kullanımı

### 1. Ürün Listesi Getirme
```http
GET /api/products
```
### 2. Yeni Ürün Ekleme
```http
POST /api/products
Content-Type: application/json
{
  "name": "Ürün Adı",
  "price": 100.0
}
```

### 3. Ürün Güncelleme
```http
PUT /api/products/{id}
Content-Type: application/json
{
  "name": "Yeni Ürün Adı",
  "price": 150.0
}
```

### 4. Ürün Silme
```http
DELETE /api/products/{id}
```

## 📌 Katkıda Bulunma

Projeye katkıda bulunmak için **pull request** açabilirsiniz. Hata bildirimi veya yeni özellik önerileri için **issues** sekmesini kullanabilirsiniz.

## 📜 Lisans

Bu proje MIT lisansı ile lisanslanmıştır. Daha fazla bilgi için [LICENSE](LICENSE) dosyasını inceleyebilirsiniz.

## 📷  Fotograflar
![image](https://github.com/user-attachments/assets/9deb63a1-ac51-4746-9c4e-f8ebc346d5f7)
<br>
![image](https://github.com/user-attachments/assets/75df4e03-0fca-40bc-ae0b-c9f637049f68)
<br>
![image](https://github.com/user-attachments/assets/007397be-5169-496b-825a-c4e629d26d2b)
<br>
![image](https://github.com/user-attachments/assets/c9d316d9-93c6-46b3-b401-072e99078ac7)
<br>
![image](https://github.com/user-attachments/assets/f02aad10-64ac-426b-bad5-fb5152367c37)
<br>
![image](https://github.com/user-attachments/assets/575a20df-9312-4d55-bd18-557f11bad3e8)
<br>
![image](https://github.com/user-attachments/assets/9135936e-8f80-4ce9-9688-03945d7150eb)
<br>


---

📌 **Berkan Burak Turgut** tarafından geliştirilmiştir. Destek olmak için ⭐ vererek projeyi beğenebilirsiniz!





