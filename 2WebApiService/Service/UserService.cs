using _2WebApiData.IRepository;
using _2WebApiDomain.Entities;
using _2WebApiService.DTOs;
using _2WebApiService.Interfaces;
using _2WebApiService.Mappers;
using _2WebApiService.ViewModel;
using AutoMapper;
using ProtoolsStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using WebApi2.Data.DbContexts;

namespace _2WebApiService.Service
{
    public class UserService : IUser
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _repository;
        public UserService(AppDbContext context)
        {
            this._mapper = new Mapper(new MapperConfiguration(
                    cfg => cfg.AddProfile<MapperProfile>()
            ));
            this._repository = _repository;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {

            return await Task.FromResult(_mapper.Map<IEnumerable<UserViewModel>>(
            _repository.GetAll().AsEnumerable()));

        }

        public async Task<UserViewModel> GetAsync(long id)
        {
            var existedUser = await _repository.GetAsync(b => b.Id == id);

            return _mapper.Map<UserViewModel>(existedUser);
        }

        public async Task<UserViewModel> CreateAsync(UserCreationDto dto)
        {
            var usercreate = new User()
            {
                Id = dto.GetHashCode(),
                UserName = dto.UserName,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
            };

            _repository.Add(usercreate);
            await _repository.SaveAsync();
            return _mapper.Map<UserViewModel>(_repository.GetAll().AsEnumerable());
        }
    }
}

