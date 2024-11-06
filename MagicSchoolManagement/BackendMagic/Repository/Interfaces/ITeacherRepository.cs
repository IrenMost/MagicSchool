﻿using BackendMagic.Model;
using BackendMagic.Model.Enums;

namespace BackendMagic.Repository.Interfaces
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllTeachers();
        Task AddAsync(params Teacher[] teachers);

        Task<Teacher> GetTeacherById(int teacherId);
        Task UpdateTeacher(Teacher teacher);
      
        Task SaveChangesAsync();
       
      

        
    }
}
