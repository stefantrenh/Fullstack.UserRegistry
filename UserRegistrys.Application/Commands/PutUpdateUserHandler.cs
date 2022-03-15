using UserRegistry.Domain.Managers;
using UserRegistry.Domain.Models;

namespace UserRegistrys.Application.Commands
{
    public class PutUpdateUserHandler
    {
        private readonly IUserCRUDOperationService _userCRUDOperationService;

        public PutUpdateUserHandler(IUserCRUDOperationService userCRUDOperationService)
        {
            _userCRUDOperationService = userCRUDOperationService;
        }

        public async Task<PutUpdateUserBack> HandleAsync(PutUpdateUserCommand putUpdateUserCommand)
        {
            var userModel = new UserEntityModel
            {
                Id = putUpdateUserCommand.Id,
                Name = putUpdateUserCommand.Name,
                Address = putUpdateUserCommand.Address
            };

            await _userCRUDOperationService.Update(userModel);

            var response = new PutUpdateUserBack
            { 
                Id = userModel.Id,
                Name = userModel.Name,
                Address = userModel.Address
            };

            return response;

        }
    }
}
