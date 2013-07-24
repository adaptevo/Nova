using Nova.Core.Utilities;

namespace Nova.Core.Domain
{
    public class UserAnswer
    {
        private readonly Answer _answer;
        private readonly User _user;

        public UserAnswer(Answer answer, User user)
        {
            _answer = CheckArgument.NotNull(answer, "answer");
            _user = CheckArgument.NotNull(user, "user");
        }

        public Answer Answer { get { return _answer; } }
        public User User { get { return _user; } }
    }
}
