
using UserRegistry.Domain.Managers;

namespace UserRegistrys.Application.Queries
{
    public class GetAllUsersDataQueryHandler
    {
        private readonly IUserCRUDOperationService _userCRUDOperationService;

        public GetAllUsersDataQueryHandler(IUserCRUDOperationService userCRUDOperationService)
        {
            _userCRUDOperationService = userCRUDOperationService;
        }

        public async Task<List<GetAllUsersDataQueryResponse>> HandleAsync()
        {
            var response = new List<GetAllUsersDataQueryResponse>();

            var userLists = await _userCRUDOperationService.Get();
            foreach (var user in userLists) 
            { 
               var userDataReponse = new GetAllUsersDataQueryResponse(); //Current DTO includes ID!
                userDataReponse.Id = user.Id;
                userDataReponse.Name = user.Name;
                userDataReponse.Address = user.Address;
                response.Add(userDataReponse);
            }

            return response;

        }

    }
}
