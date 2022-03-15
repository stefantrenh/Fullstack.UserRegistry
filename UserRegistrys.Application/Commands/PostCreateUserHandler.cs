using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistry.Domain.Managers;
using UserRegistry.Domain.Models;

namespace UserRegistrys.Application.Commands
{
    public class PostCreateUserHandler
    {
        private readonly IUserCRUDOperationService _userCRUDOperationService;

        public PostCreateUserHandler(IUserCRUDOperationService userCRUDOperationService)
        {
            _userCRUDOperationService = userCRUDOperationService;
        }

        public async Task<PostCreateUserBack> HandleAsync(PostCreateUserCommand postCreateUserCommand)
        {
            var userModel = new UserEntityModel
            { Name = postCreateUserCommand.Name, Address = postCreateUserCommand.Address };

            var user = await _userCRUDOperationService.Create(userModel);
            var response = new PostCreateUserBack
            {
                Address = user.Address,
                Name = user.Name,
            };

            return response;
        }
        
    }
}
