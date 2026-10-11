# 🎮 Survival Shooter - Game Hành Động 3D

Game bắn súng sinh tồn 3D được xây dựng trên Unity 6 LTS, dựa trên bộ asset mẫu "Survival Shooter" (Nightmares).

---

## 📋 MỤC LỤC

- [Giới thiệu](#giới-thiệu)
- [Cách cài đặt](#cách-cài-đặt)
- [Cách chơi](#cách-chơi)
- [Controls](#controls)
- [Tính năng game](#tính-năng-game)
- [Mục tiêu](#mục-tiêu)
- [Kỹ thuật](#kỹ-thuật)

---

## 🎯 GIỚI THIỆU

Survival Shooter là game hành động 3D top-down perspective nơi bạn đóng vai người chơi phải chiến đấu chống lại hàng loạt quái vật Zombunny để sinh tồn. Game có cơ chế bắn súng, hệ thống máu, điểm số và điều kiện thắng/thua.

---

## ⚙️ CÁCH CÀI ĐẶT

### Yêu cầu hệ thống:
- **Unity Editor**: 6000.x LTS (Unity 6)
- **Platform**: Windows (StandaloneWindows64)
- **RAM**: Tối thiểu 4GB
- **Đồ họa**: Card đồ họa hỗ trợ DirectX 11

### Các bước cài đặt:

1. **Clone hoặc tải dự án**
   - Tải toàn bộ thư mục dự án về máy
   - Đường dẫn: `Game3D_Survivor Shooter Asset`

2. **Mở dự án trong Unity**
   - Mở Unity Hub
   - Click vào **"Add project from disk"** hoặc **"Open"**
   - Chọn thư mục: `Game3D_Survivor Shooter Asset`
   - Chọn phiên bản Unity 6000.3.14f1 (hoặc phiên bản 6000.x LTS gần nhất)
   - Click **"Open"**

3. **Mở Scene chính**
   - Trong cửa sổ Project, tìm file `MainGame.unity` trong thư mục `Assets`
   - Double-click để mở scene

4. **Chạy game**
   - Click vào nút **Play** (hình tam giác ▶) trên thanh công cụ
   - Hoặc nhấn phím **Ctrl + P**

---

## 🎮 CÁCH CHƠI

### Bắt đầu game:
1. Mở scene `MainGame.unity`
2. Click nút **Play** trong Unity Editor
3. Game sẽ bắt đầu ngay lập tức

### Cơ chế chơi:
- Di chuyển nhân vật để tránh quái vật
- Bắn súng để tiêu diệt quái vật
- Tích điểm bằng cách giết quái
- Tránh bị quái cắn để không mất máu
- Cố gắng đạt điểm mục tiêu (100 điểm) để thắng
- Nếu máu về 0, bạn sẽ thua

---

## 🕹️ CONTROLS

| Phím | Chức năng |
|------|-----------|
| **W** | Di chuyển lên |
| **A** | Di chuyển sang trái |
| **S** | Di chuyển xuống |
| **D** | Di chuyển sang phải |
| **Chuột trái** | Bắn súng |
| **Con trỏ chuột** | Điều khiển hướng bắn |

### Mẹo:
- Sử dụng W, A, S, D để di chuyển nhân vật
- Di chuyển chuột để thay đổi hướng bắn (tia súng sẽ bắn theo hướng chuột)
- Click chuột trái để bắn súng
- Hướng bắn độc lập với hướng di chuyển - bạn có thể di chuyển sang trái nhưng bắn sang phải

---

## ✨ TÍNH NĂNG GAME

### Hệ thống nhân vật (Player):
- ✅ Di chuyển mượt mà với W, A, S, D
- ✅ Bắn súng theo hướng con trỏ chuột
- ✅ Hệ thống máu (Health) với thanh máu UI
- ✅ Hiệu ứng flash màn hình khi bị thương
- ✅ Hoạt ảnh di chuyển (walking animation)

### Hệ thống quái vật (Enemy):
- ✅ AI tự động tìm đường đuổi theo player (NavMesh)
- ✅ Hệ thống máu cho quái
- ✅ Quái tự động cắn player khi đến gần
- ✅ Hiệu ứng chìm xuống sàn khi chết
- ✅ Spawn tự động từ nhiều điểm (SpawnPoints)

### Hệ thống combat:
- ✅ Tia súng vàng (LineRenderer) hiển thị hướng bắn
- ✅ Hit detection chính xác với Raycast
- ✅ Sát thương gây ra cho quái (20 damage mỗi phát)
- ✅ Quái cắn gây sát thương cho player (10 damage mỗi lần)

### Hệ thống UI:
- ✅ Thanh máu (Health Slider) hiển thị máu player
- ✅ Điểm số (Score) hiển thị số quái đã giết
- ✅ Màn hình Game Over khi hết máu
- ✅ Màn hình Win khi đạt điểm mục tiêu
- ✅ Button Restart để chơi lại

### Hệ thống quản lý:
- ✅ EnemyManager: Spawn quái tự động mỗi 3 giây
- ✅ ScoreManager: Quản lý điểm số
- ✅ PlayerHealth: Quản lý máu player
- ✅ WinManager: Kiểm tra điều kiện thắng
- ✅ GameOverManager: Xử lý khi player chết

---

## 🏆 MỤC TIÊU

### Cách thắng:
- Giết quái vật để tích điểm
- Mỗi quái bị giết = **10 điểm**
- Đạt **100 điểm** để thắng game
- Khi thắng, màn hình "YOU WIN!" sẽ hiện lên

### Cách thua:
- Để quái cắn và mất máu
- Máu về 0 = Game Over
- Màn hình "GAME OVER" sẽ hiện lên

### Tips:
- Giữ khoảng cách với quái để tránh bị cắn
- Bắn quái từ xa để bảo vệ máu
- Di chuyển liên tục để quái khó tiếp cận
- Sử dụng hướng bắn linh hoạt để bắn nhiều quái cùng lúc

---

## 🔧 KỸ THUẬT

### Engine & Tools:
- **Unity**: 6000.3.14f1 LTS
- **Language**: C#
- **Render Pipeline**: Built-in Render Pipeline
- **Input System**: Legacy Input Manager

### Script chính:
- `PlayerMovement.cs` - Di chuyển player
- `PlayerShooting.cs` - Bắn súng
- `PlayerHealth.cs` - Quản lý máu player
- `EnemyMovement.cs` - AI di chuyển quái
- `EnemyHealth.cs` - Quản lý máu quái
- `EnemyAttack.cs` - Quái cắn player
- `EnemyManager.cs` - Spawn quái tự động
- `ScoreManager.cs` - Quản lý điểm số
- `WinManager.cs` - Kiểm tra điều kiện thắng
- `GameOverManager.cs` - Xử lý game over
- `CameraFollow.cs` - Camera theo dõi player

### Cấu trúc thư mục:
```
Assets/
├── Scripts/
│   ├── Player/
│   │   ├── PlayerMovement.cs
│   │   ├── PlayerShooting.cs
│   │   └── PlayerHealth.cs
│   ├── Enemy/
│   │   ├── EnemyMovement.cs
│   │   ├── EnemyHealth.cs
│   │   └── EnemyAttack.cs
│   └── Managers/
│       ├── EnemyManager.cs
│       ├── ScoreManager.cs
│       ├── WinManager.cs
│       └── GameOverManager.cs
├── Prefabs/
│   └── Zombunny.prefab
└── MainGame.unity
```

### Layer & Tags:
- **Tags**: `Player` - Tag cho GameObject player
- **Layers**: `Shootable` - Layer cho quái vật (để bắn)
- **Layers**: `Floor` - Layer cho mặt sàn (để raycast chuột)

---

## 📝 GHI CHÚ

### Dành cho người mới học Unity:
- Game được thiết kế để học tập với code đơn giản, dễ hiểu
- Đã có null-checks đầy đủ để tránh lỗi runtime
- Auto-add components giúp dễ dàng thiết lập
- Hỗ trợ cả TextMeshPro (Unity 6) và Legacy Text

### Tùy chỉnh:
- **Tốc độ player**: Thay đổi `speed` trong PlayerMovement
- **Sát thương súng**: Thay đổi `damagePerShot` trong PlayerShooting
- **Tốc độ bắn**: Thay đổi `timeBetweenBullets` trong PlayerShooting
- **Máu player**: Thay đổi `startingHealth` trong PlayerHealth
- **Sát thương quái**: Thay đổi `attackDamage` trong EnemyAttack
- **Tốc độ quái**: Thay đổi `Speed` trong NavMeshAgent của Zombunny
- **Thời gian spawn**: Thay đổi `spawnTime` trong EnemyManager
- **Điểm để thắng**: Thay đổi `scoreToWin` trong WinManager

---

## 🐛 VẤN ĐỀ KHẢ NĂNG GẶP

### Tia súng không hiển thị:
- Kiểm tra xem GunBarrelEnd có đúng chưa
- Kiểm tra LineRenderer có được gán chưa

### Quái không di chuyển:
- Kiểm tra NavMesh đã Bake chưa
- Kiểm tra NavMeshAgent có được gán đúng chưa
- Kiểm tra quái có layer đúng để không chặn navmesh

### Không bắn được quái:
- Kiểm tra quái có layer "Shootable" chưa
- Kiểm tra tag của player có phải "Player" chưa

### Game không restart:
- Kiểm tra scene đã thêm vào Build Settings chưa
- Kiểm tra hàm RestartLevel trong PlayerHealth

---

## 📄 LICENSE

Dự án này được tạo ra cho mục đích học tập và thực hành. Dựa trên bộ asset mẫu "Survival Shooter" của Unity.

---

## 👤 TÁC GIẢ

- Được xây dựng như bài tập thực hành Unity 6
- Hướng dẫn và hỗ trợ bởi Devin AI Assistant

---

**Chúc bạn chơi vui vẻ! 🎮🚀**
