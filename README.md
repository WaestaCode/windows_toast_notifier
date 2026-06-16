# 🔔 Waesta Windows Toast Notifier

> **Author:** waesta.js | **Platform:** C# (.NET + WinRT)

## 🇬🇧 English

### Overview
Native Windows 10/11 toast notification sender via PowerShell WinRT bridge with professional console logging.

### ✨ Key Features
- **WaestaCore Class:** `WaestaCore.cs` with banner and colored logs
- **WinRT Integration:** Native Action Center notifications
- **Clean Entry Point:** Minimal `Program.cs`
- **Argument Validation:** Clear usage message on missing args

### 🔒 Anti-Tamper Security
Integrity check with `Environment.Exit(0xDEAD)` on failure.

### 📁 Project Structure
```
10_Waesta_Windows_Toast_Notifier/
├── Program.cs
└── WaestaCore.cs
```

### 🛠️ Build & Run
```bash
csc Program.cs WaestaCore.cs
WaestaNotifier.exe "Başlık" "Mesaj içeriği"
```

---

## 🇹🇷 Türkçe

### Genel Bakış
Windows 10/11 Action Center'a native toast bildirimi gönderen C# aracı. WinRT + PowerShell köprüsü kullanır.

### 🛠️ Kullanım
```bash
WaestaNotifier.exe "Waesta" "Sistem hazır!"
```
