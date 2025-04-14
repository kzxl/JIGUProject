JIGUProject

JIGUProject là một ứng dụng được phát triển bằng ngôn ngữ C#, sử dụng kiến trúc đa tầng với các thành phần chính như ClientView, ServerView, WebAPI và các mô hình dữ liệu chia sẻ. Dự án nhằm mục đích xây dựng một hệ thống quản lý dữ liệu hiệu quả và dễ mở rộng.​
🗂 Cấu trúc dự án

    ClientView/: Giao diện người dùng phía khách hàng.​

    ServerView/: Giao diện quản trị hoặc máy chủ.​

    WebAPI/: API trung gian xử lý dữ liệu và giao tiếp giữa client và server.​

    Service/: Lớp dịch vụ xử lý logic nghiệp vụ.​

    ModelDTO/: Các đối tượng truyền dữ liệu (Data Transfer Objects).​

    Shared.Models/: Các mô hình dữ liệu được chia sẻ giữa các thành phần.​

    JIGUProject.sln: Tệp giải pháp của Visual Studio.​
    GitHub

🚀 Bắt đầu
Yêu cầu hệ thống

    .NET Framework 4.6 hoặc cao hơn​

    Visual Studio 2019 hoặc mới hơn​

    SQLite hoặc SQL Server (tùy thuộc vào cấu hình)​

Cài đặt

    Clone repository:​

    git clone https://github.com/kzxl/JIGUProject.git

2. Mở JIGUProject.sln bằng Visual Studio.​ 3. Khôi phục các gói NuGet cần thiết.​ 4. Cấu hình chuỗi kết nối cơ sở dữ liệu trong tệp cấu hình.​ 5. Xây dựng và chạy dự án.​
🧩 Tính năng

    Giao diện người dùng thân thiện và dễ sử dụng.​

    API mạnh mẽ hỗ trợ các thao tác CRUD.​

    Kiến trúc phân tầng giúp dễ dàng bảo trì và mở rộng.​

    Sử dụng Entity Framework cho việc quản lý dữ liệu.​
