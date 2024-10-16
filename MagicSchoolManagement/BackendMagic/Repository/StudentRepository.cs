﻿using BackendMagic.Data;
using BackendMagic.Model;
using BackendMagic.Repository.Interfaces;
using BackendMagic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendMagic.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _dbContext;
        private readonly IStudentService _studentService;

        public StudentRepository(SchoolContext dbContext, IStudentService studentService)
        {
            _dbContext = dbContext;
            _studentService = studentService;
        }

        public async Task AddAsync(Student student)
        {
            await _dbContext.AddAsync(student);
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(s => s.StudentId == studentId);
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task UpdateStudent(Student student)
        {
            _dbContext.Students.Update(student);
            await _dbContext.SaveChangesAsync();

        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
