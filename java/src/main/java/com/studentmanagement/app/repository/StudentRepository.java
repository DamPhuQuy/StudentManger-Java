package com.studentmanagement.app.repository;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.studentmanagement.app.entity.Student;

import jakarta.transaction.Transactional;

// @Transactional annotation is used to manage the transaction
// It is used to mark the method as transactional
// It is like try-catch block for method
// Client
//  ↓
// Spring AOP Proxy (do @Transactional tạo ra) (Proxy is fake object that wraps the real object)
//  ↓
// BEGIN TRANSACTION
//  ↓
// method business()
//  ↓
// COMMIT (nếu OK) / ROLLBACK (nếu exception)


// @Modifying annotation is used to mark the query method as a modifying query
// It is used to indicate that the query is an INSERT, UPDATE, DELETE, or DDL query

// @Query = query string + parameter binding + result mapping

// @Param annotation is used to bind the method parameter to the query parameter
// @Param("name") String name  => :name

/*
save()
findById()
findAll()
deleteById()
count()
existsById()

là những phương thức mà JpaRepository tạo sẵn, đều ở dạng @Transaction
 */

@Repository
public interface StudentRepository extends JpaRepository<Student, Long> {

    // Find by ID - Native Query
    @Query(value = "SELECT * FROM students WHERE id = :id", nativeQuery = true)
    Optional<Student> findById(@Param("id") Long id);

    // Find all - Native Query
    @Query(value = "SELECT * FROM students", nativeQuery = true)
    List<Student> findAll();

    // Insert new student - Native Query
    @Modifying
    @Transactional
    @Query(value = """
        INSERT INTO students (firstname, lastname, email, phone, created_at, updated_at)
        VALUES (:#{#student.firstname}, :#{#student.lastname}, :#{#student.email},
                :#{#student.phone}, :#{#student.createdAt}, :#{#student.updatedAt})
        """, nativeQuery = true)
    int addNewStudent(@Param("student") Student student);

    // Update student - Native Query
    @Modifying
    @Transactional
    @Query(value = """
        UPDATE students
        SET firstname = :#{#student.firstname},
            lastname = :#{#student.lastname},
            email = :#{#student.email},
            phone = :#{#student.phone},
            updated_at = :#{#student.updatedAt}
        WHERE id = :#{#student.id}
        """, nativeQuery = true)
    int updateStudent(@Param("student") Student student);

    // Delete student - Native Query
    @Modifying
    @Transactional
    @Query(value = "DELETE FROM students WHERE id = :id", nativeQuery = true)
    int deleteStudent(@Param("id") Long id);

    // Custom queries - Examples

    @Query(value = "SELECT * FROM students WHERE email = :email", nativeQuery = true)
    Optional<Student> findByEmail(@Param("email") String email);

    @Query(value = "SELECT * FROM students WHERE firstname LIKE CONCAT('%', :name, '%') OR lastname LIKE CONCAT('%', :name, '%')", nativeQuery = true)
    List<Student> searchByName(@Param("name") String name);

    @Query(value = "SELECT COUNT(*) FROM students", nativeQuery = true)
    long countAllStudents();
}
