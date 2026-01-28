package com.studentmanagement.app.entity;

import java.time.LocalDateTime;

import io.swagger.v3.oas.annotations.media.Schema;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "students")
@Schema(description = "Thông tin sinh viên")
public class Student {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Schema(description = "ID sinh viên (tự động tăng)", example = "1")
    private Long id;

    @Column(name = "firstname")
    @Schema(description = "Tên của sinh viên", example = "Nguyễn", required = true)
    private String firstname;

    @Column(name = "lastname")
    @Schema(description = "Họ của sinh viên", example = "Văn A", required = true)
    private String lastname;

    @Column(name = "email")
    @Schema(description = "Email của sinh viên", example = "student@example.com")
    private String email;

    @Column(name = "phone")
    @Schema(description = "Số điện thoại của sinh viên", example = "0912345678")
    private String phone;

    @Column(name = "created_at")
    @Schema(description = "Thời gian tạo sinh viên", example = "2026-01-28T10:00:00")
    private LocalDateTime createdAt;

    @Column(name = "updated_at")
    @Schema(description = "Thời gian cập nhật sinh viên", example = "2026-01-28T15:30:00")
    private LocalDateTime updatedAt;
}
