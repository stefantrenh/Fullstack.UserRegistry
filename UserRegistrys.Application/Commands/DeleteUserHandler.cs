using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistry.Domain.Managers;
using UserRegistry.Domain.Models;

namespace UserRegistrys.Application.Commands
{
    public class DeleteUserHandler
    {
        private readonly IUserCRUDOperationService _userCRUDOperationService;

        public DeleteUserHandler(IUserCRUDOperationService userCRUDOperationService)
        {
            _userCRUDOperationService = userCRUDOperationService;
        }

        public async Task<DeleteUserBack> HandleAsync(DeleteUserCommand deleteUserCommand)
        {
            var response = new DeleteUserBack();
            var currentUser = await _userCRUDOperationService.Get(deleteUserCommand.Id); //currently exception handling shall make a get request with trigger in background. (breaking the CQRS pattern)
            if (currentUser == null)
            {
                response.Response = $"Current User Does Not Exist By UserId {deleteUserCommand.Id}";
                return response;
            }
            else
            {
                response.Response = $"User {currentUser.Name} With Id {currentUser.Id} has been DELETED!";
                await _userCRUDOperationService.Delete(deleteUserCommand.Id);
                return response;
            }         
        }
    }
}
