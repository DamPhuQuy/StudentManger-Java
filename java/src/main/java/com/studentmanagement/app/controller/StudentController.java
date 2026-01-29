package com.studentmanagement.app.controller;

import java.util.List;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.studentmanagement.app.entity.Student;
import com.studentmanagement.app.service.StudentService;

import io.swagger.v3.oas.annotations.Operation;
import io.swagger.v3.oas.annotations.Parameter;
import io.swagger.v3.oas.annotations.media.Content;
import io.swagger.v3.oas.annotations.media.Schema;
import io.swagger.v3.oas.annotations.responses.ApiResponse;
import io.swagger.v3.oas.annotations.responses.ApiResponses;
import io.swagger.v3.oas.annotations.tags.Tag;

@RestController
@RequestMapping("/students")
@Tag(name = "Student Management", description = "API để quản lý sinh viên")
public class StudentController {
    private StudentService studentService;

    public StudentController(StudentService studentService) {
        this.studentService = studentService;
    }

    // Lấy danh sách tất cả sinh viên
    @GetMapping
    @Operation(summary = "Lấy danh sách tất cả sinh viên", description = "Trả về danh sách tất cả sinh viên trong hệ thống")
    @ApiResponse(responseCode = "200", description = "Thành công", content = @Content(mediaType = "application/json", schema = @Schema(implementation = Student.class)))
    public ResponseEntity<List<Student>> getAllStudents() {
        List<Student> students = studentService.getAllStudents();
        return ResponseEntity.ok(students);
    }

    // Lấy sinh viên theo ID
    @GetMapping("/{id}")
    @Operation(summary = "Lấy sinh viên theo ID", description = "Trả về thông tin chi tiết của một sinh viên dựa trên ID")
    @ApiResponses(value = {
        @ApiResponse(responseCode = "200", description = "Thành công", content = @Content(mediaType = "application/json", schema = @Schema(implementation = Student.class))),
        @ApiResponse(responseCode = "404", description = "Không tìm thấy sinh viên")
    })
    public ResponseEntity<Student> getStudent(@PathVariable @Parameter(description = "ID của sinh viên") Long id) {
        Student student = studentService.getStudentById(id);
        if (student != null) {
            return ResponseEntity.ok(student);
        }
        return ResponseEntity.notFound().build();
    }

    // Tạo sinh viên mới
    @PostMapping
    @Operation(summary = "Tạo sinh viên mới", description = "Thêm một sinh viên mới vào hệ thống")
    @ApiResponses(value = {
        @ApiResponse(responseCode = "201", description = "Tạo thành công", content = @Content(mediaType = "application/json", schema = @Schema(implementation = Student.class))),
        @ApiResponse(responseCode = "400", description = "Dữ liệu không hợp lệ")
    })
    public ResponseEntity<Student> createStudent(@RequestBody @Parameter(description = "Thông tin sinh viên cần tạo") Student student) {
        
        studentService.enrollStudent(student);
        return ResponseEntity.status(HttpStatus.CREATED).body(student);
    }

    // Cập nhật sinh viên
    @PutMapping("/{id}")
    @Operation(summary = "Cập nhật thông tin sinh viên", description = "Cập nhật thông tin chi tiết của một sinh viên")
    @ApiResponses(value = {
        @ApiResponse(responseCode = "200", description = "Cập nhật thành công", content = @Content(mediaType = "application/json", schema = @Schema(implementation = Student.class))),
        @ApiResponse(responseCode = "404", description = "Không tìm thấy sinh viên"),
        @ApiResponse(responseCode = "400", description = "Dữ liệu không hợp lệ")
    })
    public ResponseEntity<Student> updateStudent(
            @PathVariable @Parameter(description = "ID của sinh viên cần cập nhật") Long id,
            @RequestBody @Parameter(description = "Thông tin sinh viên cập nhật") Student student) {
        Student existingStudent = studentService.getStudentById(id);
        if (existingStudent != null) {
            student.setId(id);
            studentService.updateStudent(student);
            return ResponseEntity.ok(student);
        }
        return ResponseEntity.notFound().build();
    }

    // Xóa sinh viên
    @DeleteMapping("/{id}")
    @Operation(summary = "Xóa sinh viên", description = "Xóa một sinh viên khỏi hệ thống")
    @ApiResponses(value = {
        @ApiResponse(responseCode = "204", description = "Xóa thành công"),
        @ApiResponse(responseCode = "404", description = "Không tìm thấy sinh viên")
    })
    public ResponseEntity<Void> deleteStudent(@PathVariable @Parameter(description = "ID của sinh viên cần xóa") Long id) {
        Student student = studentService.getStudentById(id);
        if (student != null) {
            studentService.deleteStudent(id);
            return ResponseEntity.noContent().build();
        }
        return ResponseEntity.notFound().build();
    }
}
