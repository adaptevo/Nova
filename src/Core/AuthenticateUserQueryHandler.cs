using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nova.Core.Services.Persistence;
using Nova.Core.Domain;

namespace Nova.Core
{
    public class AuthenticateUserQueryHandler : IQueryHandler<AuthenticateUserQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public AuthenticateUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Handle(AuthenticateUserQuery query)
        {
            if (string.IsNullOrWhiteSpace(query.Username))
            {
                throw new ArgumentNullException("Username");
            }

            if (string.IsNullOrWhiteSpace(query.Password))
            {
                throw new ArgumentNullException("Password");
            }

            return _userRepository.GetUser(query.Username, query.Password);
        }
    }
}
