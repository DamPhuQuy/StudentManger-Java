# Hệ Thống Quản Lý Sinh Viên Trường Đại Học

## Mô tả

Hệ thống quản lý sinh viên được xây dựng bằng C# 14 với đầy đủ các tính năng quản lý học tập cho trường đại học.

## Tính năng

### 1. Quản trị viên (Admin)

- Thêm sinh viên thủ công hoặc từ file CSV
- Quản lý danh sách môn học
- Gán sinh viên vào các môn học
- Quản lý tài khoản người dùng
- Xem báo cáo thống kê

### 2. Quản lý Khoa (Faculty)

- Xem danh sách môn học
- Xem danh sách sinh viên theo môn
- Cập nhật điểm cho sinh viên
- Xem thông tin cá nhân

### 3. Sinh viên (Student)

- Xem thông tin cá nhân
- Xem kết quả học tập
- Xem danh sách môn học đã đăng ký
- Cập nhật thông tin cá nhân

## Kiến trúc & Design Patterns

### OOP Principles

- **Encapsulation**: Tất cả các model đều có các thuộc tính và phương thức được đóng gói
- **Inheritance**: User hierarchy (Admin, Faculty, StudentUser kế thừa từ User base class)
- **Polymorphism**: Override DisplayInfo() method cho từng loại user
- **Abstraction**: Abstract User class và interfaces

### SOLID Principles

- **Single Responsibility**: Mỗi service chỉ xử lý một loại logic (StudentService, CourseService, GradeService)
- **Open/Closed**: Dễ dàng mở rộng thêm user types mới mà không cần sửa code hiện tại
- **Liskov Substitution**: Tất cả các user types có thể thay thế cho base User class
- **Interface Segregation**: Nhiều interfaces nhỏ thay vì một interface lớn
- **Dependency Inversion**: Services phụ thuộc vào interfaces, không phụ thuộc vào concrete classes

### Design Patterns

1. **Repository Pattern**: Generic repository cho data access
2. **Singleton Pattern**: AuthService sử dụng singleton để quản lý authentication
3. **Template Method Pattern**: DisplayInfo() method trong User hierarchy
4. **Strategy Pattern**: Grade calculation strategy
5. **Facade Pattern**: Program.cs làm facade cho toàn bộ hệ thống

### LINQ & PLINQ

- Sử dụng LINQ cho tất cả các truy vấn dữ liệu
- PLINQ (Parallel LINQ) cho các tác vụ xử lý dữ liệu lớn:
  - Import students from CSV
  - Statistics calculations
  - Student searches by major

## Cấu trúc thư mục

```
StudentManagement/
├── Models/                  # Domain models
│   ├── User.cs             # User hierarchy
│   ├── Student.cs          # Student entity
│   ├── Course.cs           # Course entity
│   ├── Grade.cs            # Grade entity
│   └── Enrollment.cs       # Enrollment entity
├── Interfaces/             # Interfaces
│   ├── IRepository.cs      # Generic repository interface
│   └── IServices.cs        # Service interfaces
├── Repositories/           # Data access layer
│   ├── Repository.cs       # Generic repository
│   └── SpecificRepositories.cs
├── Services/               # Business logic layer
│   ├── StudentService.cs
│   ├── CourseService.cs
│   ├── GradeService.cs
│   └── AuthService.cs
├── Utilities/              # Helper classes
│   ├── CsvHelper.cs        # CSV operations
│   └── ConsoleHelper.cs    # Console UI helpers
├── Program.cs              # Main application
├── students.csv            # Sample data
└── StudentManagement.csproj
```

## Yêu cầu

- .NET 9.0 SDK
- C# 14

## Cách chạy

1. Mở terminal tại thư mục dự án
2. Build project:
   ```bash
   dotnet build
   ```
3. Run project:
   ```bash
   dotnet run
   ```

## Tài khoản mặc định

### Admin

- Username: `admin`
- Password: `admin123`

### Faculty

- Username: `faculty`
- Password: `faculty123`

### Student

- Username: `student`
- Password: `student123`

## Import sinh viên từ CSV

File CSV phải có định dạng:

```
StudentId,FullName,DateOfBirth,Email,PhoneNumber,Major,Address,EnrollmentDate,Status
SV001,Nguyen Van A,01/01/2003,nva@student.edu,0901234567,Computer Science,123 Street,01/09/2021,Active
```

Sử dụng file mẫu `students.csv` có sẵn để test chức năng import.

## Tính năng nổi bật

### 1. Phân quyền người dùng

- Mỗi role có menu và quyền truy cập riêng
- Xác thực với mã hóa password (SHA256)

### 2. LINQ Queries

- Tìm kiếm sinh viên theo nhiều tiêu chí
- Lọc và sắp xếp dữ liệu
- Tính toán GPA tự động
- Thống kê theo department/major

### 3. PLINQ (Parallel LINQ)

- Xử lý song song khi import CSV
- Tìm kiếm sinh viên theo major với parallel processing
- Tính toán thống kê với parallel queries

### 4. Quản lý điểm

- Thêm và cập nhật điểm
- Tự động tính letter grade (A+, A, B+, ...)
- Tính GPA trung bình
- Export báo cáo ra CSV

### 5. CSV Operations

- Import sinh viên từ CSV
- Export điểm môn học ra CSV
- Validation dữ liệu khi import

## Mở rộng

Hệ thống được thiết kế theo SOLID principles nên dễ dàng mở rộng:

- Thêm user roles mới (VD: Dean, Registrar)
- Thêm repositories mới cho entities mới
- Thêm services mới cho business logic mới
- Thay đổi data storage (hiện tại là in-memory, có thể chuyển sang database)

## License

Educational Project - DUT University
