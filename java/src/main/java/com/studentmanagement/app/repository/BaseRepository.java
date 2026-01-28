package com.studentmanagement.app.repository;

/*
Spring Data JPA

| Thành phần              | Vai trò                   |
| ----------------------- | ------------------------- |
| `JpaRepository`         | Interface cung cấp CRUD operations tự động |
| `@Query`                | Định nghĩa custom query (JPQL hoặc Native SQL) |
| `@Modifying`            | Đánh dấu query thay đổi dữ liệu (INSERT/UPDATE/DELETE) |
| `@Transactional`        | Quản lý transaction tự động |
| `nativeQuery = true`    | Sử dụng raw SQL thay vì JPQL |

Lợi ích:
- Không cần implement methods, Spring tự động generate
- Tự động quản lý transaction và exception
- Hỗ trợ pagination, sorting out-of-the-box
- Type-safe với generics
 */

/**
 * BaseRepository không còn cần thiết khi sử dụng Spring Data JPA
 * Các repository chỉ cần extends JpaRepository<Entity, ID>
 *
 * File này giữ lại để tham khảo về cách hoạt động của Spring Data JPA
 */
public abstract class BaseRepository {
    // Spring Data JPA không cần BaseRepository
    // Mỗi repository chỉ cần extends JpaRepository<Entity, ID> với JpaRepository đã được cấu hình sẵn làm Base Repository
}
