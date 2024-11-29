using BackendMagic.DTOs.Auth;
using Microsoft.AspNetCore.Identity;

namespace BackendMagic.Services.Authentication
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterStudentAsync(RegisterAStudentDto registerStudentDto);
        Task<IdentityResult> RegisterTeacherAsync(RegisterATeacherDto registerATeacherDto);
        Task<IdentityResult> RegisterHouseElf( RegisterHouseElfDto registerHouseElfDto);

        Task<LoginEntity?> FindEntity(LoginDto loginDto);

        Task<string?> GetUserId(LoginDto loginDto);

    }
}
