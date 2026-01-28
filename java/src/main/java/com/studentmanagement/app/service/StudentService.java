package com.studentmanagement.app.service;

import java.util.List;

import org.springframework.stereotype.Service;

import com.studentmanagement.app.entity.Student;
import com.studentmanagement.app.repository.StudentRepository;

@Service
public class StudentService {
    private StudentRepository studentRepository;

    public StudentService(StudentRepository studentRepository) {
        this.studentRepository = studentRepository;
    }

    public List<Student> getAllStudents() {
        return studentRepository.findAll();
    }

    public void enrollStudent(Student student) {
        studentRepository.save(student);

        System.out.println("Student enrolled: " + student.getFirstname() + " " + student.getLastname());
    }

    public Student getStudentById(Long id) {
        return studentRepository.findById(id).orElse(null);
    }

    public void updateStudent(Student student) {
        studentRepository.updateStudent(student);

        System.out.println("Student updated: " + student.getFirstname() + " " + student.getLastname());
    }

    public void deleteStudent(Long id) {
        studentRepository.deleteStudent(id);

        System.out.println("Student deleted with ID: " + id);
    }
}
