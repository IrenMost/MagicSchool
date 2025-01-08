//using BackendMagic.Data.SeedingDto;
//using BackendMagic.Model;
//using BackendMagic.Repository.Interfaces;
//using Microsoft.AspNetCore.Identity;

//namespace BackendMagic.Data
//{
//    public class HelpHouseElfSeeder
//    {
//        private readonly UserManager<IdentityUser> _userManager;
//        private readonly IHouseElfRepository _houseElfRepository;
        


//        public async Task EnsureHouseElvesAsync(IEnumerable<HouseElfData> houseElves)
//        {
//            foreach (var houseElfData in houseElves)
//            {
//                await EnsureHouseElvesAsync(
//                    houseElfData.UserName,
//                    houseElfData.Email,
//                    houseElfData.Password,
//                   houseElfData.Name,
//                    houseElfData.Role

//                );
//            }
//        }
//        public async Task EnsureHouseElvesAsync(
//                string userName,
//                string email,
//                string password,
//                string Name,
                
//                string role = "HouseElf")
//        {
//            // Check if IdentityUser exists
//            var user = await _userManager.FindByNameAsync(userName);
//            if (user == null)
//            {
//                user = new IdentityUser { UserName = userName, Email = email };
//                var result = await _userManager.CreateAsync(user, password);

//                user.EmailConfirmed = true;
//                await _userManager.UpdateAsync(user);

//                if (result.Succeeded)
//                {
//                    await _userManager.AddToRoleAsync(user, role);
//                }
//            }

//            // Check if HouseElf entity exists
//            if ((await _houseElfRepository.GetHouseElfByIdentityUserId(user.Id)) == null)
//            {
//                // Create the Student entity
//                var houseElf = new HouseElf(Name, user.Id);


//                await _houseElfRepository.AddAsync(houseElf);

                
//            }
//        }
//    }
//}
