# Notifier Manager

**English** · [Türkçe](./README.tr.md)

A notification management application developed for Windows.
With this application, you can create, edit, and manage your notifications.

## Features

### Basic Features
- 📝 Create and edit notifications
- 🗂️ Category management
- 🔔 Notification priority levels
- 🖥️ Run in the system tray

### Notification Features
- ⏰ Scheduled notifications
- 🔁 Recurring notifications (Daily, Weekly, Monthly)
- 🔊 Notification sound support
- 🎨 Customizable notification appearance

### Management Features
- 📊 View notification statistics
- 💾 Export/import data
- 🚀 Start automatically when Windows starts
- 🌈 Category-based coloring

## Technologies
- .NET Framework 4.8
- Windows Forms
- Entity Framework 6.5.1
- LocalDB (SQL Server)
- Newtonsoft.Json

## Installation

1. Clone the project:
   ```bash
   git clone https://github.com/Norethion/NotifierManager.git
   ```

2. Open it in Visual Studio.

3. Restore the NuGet packages:
   ```bash
   nuget restore NotifierManager.sln
   ```

4. Build and run the project.

## Usage

1. Create at least one category when you first use the application.
2. Add a notification with the "Yeni Bildirim" button.
3. You can edit or delete notifications.
4. You can view notification data in the Statistics section.
5. You can customize application preferences in the Settings section.

## Contributing

1. Fork this repository.
2. Create a new feature branch:
   ```bash
   git checkout -b yeni-ozellik
   ```
3. Commit your changes:
   ```bash
   git commit -am 'Yeni özellik: Açıklama'
   ```
4. Push to your branch:
   ```bash
   git push origin yeni-ozellik
   ```
5. Create a new Pull Request.

## Developer
[Norethion-AEA]

## License

This project is licensed under [MIT]. For more information, see the [LICENSE](./LICENSE) file.

---

*Footnote: This project was written entirely using claude.ai.*
