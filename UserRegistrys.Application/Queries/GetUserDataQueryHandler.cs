

using UserRegistry.Domain.Managers;

namespace UserRegistrys.Application.Queries
{
    public class GetUserDataQueryHandler
    {
        private readonly IUserCRUDOperationService _userCRUDOperationService;

        public GetUserDataQueryHandler(IUserCRUDOperationService userCRUDOperationService)
        {
            _userCRUDOperationService = userCRUDOperationService;
        }

        public async Task<GetUserDataQueryResponse> HandleAsync(GetUserDataQuery getUserDataQuery)
        {
            var response = new GetUserDataQueryResponse();
            var user = await _userCRUDOperationService.Get(getUserDataQuery.Id);

            response.Id = user.Id;
            response.Name = user.Name;
            response.Address = user.Address;

            return response;
        }

    }
}
