using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nova.Core.Domain;
using Nova.Core.Services.Persistence;

namespace Nova.Core
{
    public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, IEnumerable<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> Handle(GetUsersQuery query)
        {
            return _userRepository.GetUsers();    
        }
    }
}
