using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nova.Core.Domain;
using Nova.Core.Services.Persistence;

namespace Nova.Core
{
    public class CreateUserQueryHandler : IQueryHandler<CreateUserQuery, User> 
    {
        private readonly IUserRepository _userRepository;

        public CreateUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Handle(CreateUserQuery query)
        {
            return _userRepository.CreateUser(query.username, query.password, query.name, query.email);
        }
    }
}
