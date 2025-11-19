# 🗓️ Game Ninja 2D - Kế hoạch Sprint 4 Tuần

Đây là lịch trình "chạy nước rút" (sprint) trong 4 tuần để tạo ra một game 2D platformer offline, nơi người chơi điều khiển một ninja, di chuyển qua bản đồ, đánh quái và lên cấp.

---

## 🚀 Tuần 1: Nền tảng & Nhân vật (Ngày 1 - 7)
> **Mục tiêu:** Có một nhân vật chạy nhảy mượt mà trong một màn chơi.

### Ngày 1-2: Cài đặt & Setup Project
- [ ] Cài đặt Unity Hub và phiên bản Unity LTS.
- [ ] Tạo Project 2D (URP hoặc 2D Core).
- [ ] Import package `2D Pixel Perfect` từ Package Manager.
- [ ] Thiết lập `PixelPerfectCamera` và đặt PPU (Pixels Per Unit) mặc định (ví dụ: 16 hoặc 32).
- [ ] Tổ chức thư mục: `_Scripts`, `_Sprites`, `_Prefabs`, `_Scenes`.

### Ngày 3-4: Tạo Nhân vật & Di chuyển
- [ ] Vẽ (hoặc tìm) một sprite nhân vật "placeholder".
- [ ] Tạo GameObject "Player".
- [ ] Thêm `SpriteRenderer`.
- [ ] Thêm `Rigidbody2D` (đặt Gravity Scale, Freeze Rotation Z).
- [ ] Thêm `BoxCollider2D`.
- [ ] Tạo script `PlayerMovement.cs`.
- [ ] Code logic di chuyển trái/phải: Dùng `Input.GetAxis("Horizontal")` và cập nhật `Rigidbody2D.velocity`.

### Ngày 5-6: Nhảy & Môi trường
- [ ] Code logic nhảy: Dùng `Input.GetButtonDown("Jump")`.
- [ ] **Quan trọng:** Tạo "Ground Check" (Raycast/BoxCast) để chỉ nhảy khi trên đất.
- [ ] Sử dụng Tilemap: Tạo `Grid` -> `Tilemap`.
- [ ] Tạo `Tile Palette` từ các sprite đất.
- [ ] Vẽ một màn chơi đơn giản.
- [ ] Thêm `Tilemap Collider 2D`.

### Ngày 7: Camera & Tinh chỉnh
- [ ] Cài đặt `Cinemachine` (từ Package Manager).
- [ ] Tạo `Cinemachine Virtual Camera` và cho nó "Follow" (Theo dõi) "Player".
- [ ] Tinh chỉnh thông số nhảy, tốc độ di chuyển cho "mượt".

---

## ⚔️ Tuần 2: Chiến đấu & Kẻ thù (Ngày 8 - 14)
> **Mục tiêu:** Nhân vật có thể tấn công và tiêu diệt kẻ thù đơn giản.

### Ngày 8-9: Hệ thống Hoạt ảnh (Animation)
- [ ] Vẽ sprite sheet cho Player: Idle, Run, Jump, Attack.
- [ ] Dùng cửa sổ `Animation` và `Animator`.
- [ ] Tạo `Animator Controller` cho Player (Tạo các state: Idle, Run, Jump, Attack).
- [ ] Thiết lập `Transition` dựa trên các `Parameters` (`isMoving`, `isGrounded`, trigger `attack`).
- [ ] Cập nhật `PlayerMovement.cs` để set các biến này cho Animator.

### Ngày 10-11: Logic Tấn công (Player)
- [ ] Thêm input cho phím "Attack" (ví dụ: 'Z' hoặc 'Ctrl').
- [ ] Khi nhấn Attack, kích hoạt trigger "attack" trong Animator.
- [ ] Tạo "vùng gây sát thương" (GameObject con với `BoxCollider2D` `Is Trigger`).
- [ ] Kích hoạt vùng này khi animation tấn công diễn ra.

### Ngày 12-13: Tạo Kẻ thù (Enemy)
- [ ] Vẽ sprite Kẻ thù đơn giản (ví dụ: Slime).
- [ ] Tạo Prefab `Enemy`.
- [ ] Thêm `Rigidbody2D`, `Collider2D`.
- [ ] Tạo script `Enemy.cs`.
- [ ] Thêm biến: `public int health`, `public int damage`.
- [ ] Viết hàm `public void TakeDamage(int dmg)`.
- [ ] Logic hàm: `health -= dmg; if (health <= 0) { Die(); }`.
- [ ] Hàm `Die()`: Phát hiệu ứng và `Destroy(gameObject)`.

### Ngày 14: AI Kẻ thù (Cơ bản) & Va chạm
- [ ] Trong script "vùng tấn công" của Player, dùng `OnTriggerEnter2D` để phát hiện Kẻ thù (dùng Tag "Enemy") và gọi `enemy.TakeDamage(...)`.
- [ ] Trong `Enemy.cs`, thêm AI đơn giản (di chuyển qua lại).
- [ ] Trong `PlayerMovement.cs`, dùng `OnCollisionEnter2D` để phát hiện va chạm Kẻ thù và làm Player mất máu.

---

## 📊 Tuần 3: Hệ thống & Giao diện (Ngày 15 - 21)
> **Mục tiêu:** Hoàn thiện vòng lặp game với UI, HP, và EXP.

### Ngày 15-16: Hệ thống Stats (HP, MP, EXP)
- [ ] Tạo script `PlayerStats.cs` (gắn vào Player).
- [ ] Các biến: `currentHP`, `maxHP`, `currentMP`, `maxMP`, `currentEXP`, `expToNextLevel`, `level`.
- [ ] Tạo hàm `TakeDamage(int dmg)` (khi bị quái đánh) và `Die()` (khi HP <= 0).
- [ ] Trong `Enemy.cs`, khi chết: `Destroy(gameObject);` và gọi `PlayerStats.instance.AddEXP(expValue);` (sử dụng Singleton).

### Ngày 17-18: Hệ thống Lên cấp (Level Up)
- [ ] Trong `PlayerStats.cs`, viết hàm `AddEXP(int exp)`.
- [ ] Logic hàm: `if (currentEXP >= expToNextLevel) { LevelUp(); }`.
- [ ] Hàm `LevelUp()`: Tăng `level`, tăng `maxHP`/`maxMP`, tính lại `expToNextLevel`, hồi đầy máu/MP.

### Ngày 19-20: Giao diện Người dùng (UI)
- [ ] Tạo một `Canvas` (Screen Space - Overlay).
- [ ] Thêm `Slider` cho HP (màu đỏ) và MP (màu xanh).
- [ ] Thêm `Text` (hoặc `TextMeshPro`) để hiển thị Level và % EXP.
- [ ] Tạo script `UIManager.cs` (Singleton).
- [ ] Viết các hàm `UpdateHealthBar(float current, float max)`, `UpdateExpBar(...)`.
- [ ] `PlayerStats` sẽ gọi các hàm này khi HP, EXP thay đổi.

### Ngày 21: Chuyển màn (Scene Management)
- [ ] Tạo 2-3 Scene (bản đồ) khác nhau (ví dụ: Làng, Rừng).
- [ ] Tạo Prefab "Portal" (Cổng dịch chuyển) với `BoxCollider2D` (Is Trigger).
- [ ] Viết script `Portal.cs`, dùng `OnTriggerEnter2D` để kiểm tra `Player` và gọi `SceneManager.LoadScene("TenSceneMoi")`.

---

## 🏁 Tuần 4: Hoàn thiện & Đóng gói (Ngày 22 - 30)
> **Mục tiêu:** Một bản build "chơi được" với âm thanh và menu.

### Ngày 22-23: Âm thanh (Audio)
- [ ] Tìm nhạc nền (BGM) và hiệu ứng (SFX) miễn phí (itch.io, freesound.org).
- [ ] Tạo `AudioManager.cs` (Singleton) để quản lý `AudioSource`.
- [ ] Thêm nhạc nền cho các màn chơi.
- [ ] Thêm SFX cho: nhảy, chém, bị thương, quái chết, lên cấp.

### Ngày 24-25: Thêm "Chất" (Juice)
- [ ] Thêm hiệu ứng đơn giản:
  - [ ] Camera shake (rung lắc) nhẹ khi Player bị đánh (`Cinemachine Impulse`).
  - [ ] Hiệu ứng "chớp đỏ" (flash red) cho Player/Enemy khi bị đánh.
  - [ ] Hiệu ứng "Vụt" (slash) khi tấn công (`Particle System` hoặc sprite).
  - [ ] Hiệu ứng "Chết" (`Particle System`) cho quái.

### Ngày 26-27: Menu chính & Game Over
- [ ] Tạo Scene "MainMenu".
- [ ] Thêm nút `Button` (UI): "New Game" và "Quit".
- [ ] Tạo Scene "GameOver".
- [ ] Khi `PlayerStats.Die()`, tải Scene này. Thêm nút "Restart" hoặc "Main Menu".

### Ngày 28-29: Sửa lỗi (Bug Fixing) & Cân bằng (Balancing)
- [ ] Chơi game nhiều lần.
- [ ] Tinh chỉnh các con số (HP, sát thương, EXP).
- [ ] Sửa lỗi (ví dụ: nhân vật bị kẹt, collider sai).

### Ngày 30: ĐÓNG GÓI (Build)
- [ ] Vào `File > Build Settings`.
- [ ] Thêm tất cả các Scene (MainMenu, Làng, Rừng, GameOver).
- [ ] Chọn nền tảng (Platform): `PC, Mac & Linux Standalone`.
- [ ] Nhấn `Build` và tạo file `.exe`.
- [ ] **CHÚC MỪNG! Đã hoàn thành prototype!** 🎉

---

## ⚠️ Lời khuyên quan trọng

> * **Bám sát kế hoạch (Stick to the Scope):** Bạn sẽ có RẤT NHIỀU ý tưởng mới ("hay là thêm chiêu Lửa", "hay là thêm pet"). **HÃY GHI CHÚNG LẠI** và **ĐỂ DÀNH SAU NÀY**. Mục tiêu của 1 tháng là hoàn thành những gì đã đề ra.
> * **Dùng Art "Tạm" (Placeholder):** Đừng tốn quá nhiều thời gian cho 2 tuần đầu để vẽ art. Dùng hình vuông, hình tròn màu cũng được. Bạn sẽ thay thế art ở Tuần 4.
> * **Học hỏi liên tục:** Bạn chắc chắn sẽ gặp lỗi. Đó là điều bình thường. Hãy học cách tìm kiếm Google (ví dụ: "unity how to make 2d player jump") và đọc tài liệu của Unity.