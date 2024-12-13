# Notifier Manager

Windows için geliştirilmiş bir bildirim yönetim uygulaması. Bu uygulama ile bildirimlerinizi oluşturabilir, düzenleyebilir ve yönetebilirsiniz.

## Özellikler

### Temel Özellikler
- 📝 Bildirim oluşturma ve düzenleme
- 🗂️ Kategori yönetimi
- 🔔 Bildirim öncelik seviyeleri
- 🖥️ Sistem tepsisinde çalışma özelliği

### Bildirim Özellikleri
- ⏰ Zamanlanmış bildirimler
- 🔁 Tekrarlayan bildirimler (Günlük, Haftalık, Aylık)
- 🔊 Bildirim ses desteği
- 🎨 Özelleştirilebilir bildirim görünümü

### Yönetim Özellikleri
- 📊 Bildirim istatistikleri görüntüleme
- 💾 Verileri dışa/içe aktarma
- 🚀 Windows başlangıcında otomatik başlatma
- 🌈 Kategori bazlı renklendirme

## Teknolojiler
- .NET Framework 4.8
- Windows Forms
- Entity Framework 6.5.1
- LocalDB (SQL Server)
- Newtonsoft.Json

## Kurulum

1. Projeyi klonlayın:
   ```bash
   git clone https://github.com/norethion/notifier-manager.git
   ```

2. Visual Studio'da açın.

3. NuGet paketlerini geri yükleyin:
   ```bash
   nuget restore NotifierManager.sln
   ```

4. Projeyi derleyin ve çalıştırın.

## Kullanım

1. İlk kullanımda en az bir kategori oluşturun.
2. "Yeni Bildirim" butonu ile bildirim ekleyin.
3. Bildirimleri düzenleyebilir veya silebilirsiniz.
4. İstatistikler bölümünden bildirim verilerini görüntüleyebilirsiniz.
5. Ayarlar bölümünden uygulama tercihlerini özelleştirebilirsiniz.

## Katkıda Bulunma

1. Bu depoyu fork edin.
2. Yeni bir özellik dalı oluşturun:
   ```bash
   git checkout -b yeni-ozellik
   ```
3. Değişikliklerinizi commit edin:
   ```bash
   git commit -am 'Yeni özellik: Açıklama'
   ```
4. Dalınıza push yapın:
   ```bash
   git push origin yeni-ozellik
   ```
5. Yeni bir Pull Request oluşturun.

## Geliştirici
[Norethion-AEA]

## Lisans

Bu proje [MIT] altında lisanslanmıştır. Daha fazla bilgi için [LICENSE](./LICENSE) dosyasına bakın.

---

*Dipnot: Bu proje tamamen claude.ai kullanılarak yazılmıştır.*
