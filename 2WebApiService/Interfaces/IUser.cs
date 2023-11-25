using _2WebApiService.DTOs;
using _2WebApiService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WebApiService.Interfaces
{
    public interface IUser
    {
        Task<UserViewModel> GetAsync(long id);
        Task<IEnumerable<UserViewModel>> GetAllAsync();
        Task<UserViewModel> CreateAsync(UserCreationDto dto);
    }
}
