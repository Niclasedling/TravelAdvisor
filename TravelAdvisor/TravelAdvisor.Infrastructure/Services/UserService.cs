using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Interfaces;
using TravelAdvisor.Infrastructure.Migrations.Interfaces;
using TravelAdvisor.Infrastructure.Models;

namespace TravelAdvisor.Infrastructure.Services
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            //_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<UserCreateDto> Create(UserCreateDto newUser)
        {
            throw new NotImplementedException();
        
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<UserUpdateDto> Update()
        {
            throw new NotImplementedException();
        }
    }
}
