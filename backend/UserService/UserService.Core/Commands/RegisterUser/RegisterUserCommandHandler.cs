using MediatR;
using UserService.Core.Entities;
using UserService.Core.Interfaces;

namespace UserService.Core.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        public readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            // Implementation logic for handling the command goes here.

            if (await _userRepository.ExistsByEmailAsync(request.Email))
                throw new Exception("Email already available");

            var hassPass = PasswordHash(request.Password);

            var user = new User
            {
                Email = request.Email,
                PasswordHash = hassPass,
                UserName = request.UserName
            };

            var Id = await _userRepository.AddUserAsync(user);

            return Id;
        }

        public string PasswordHash(string pass)
        {
            return BCrypt.Net.BCrypt.HashPassword(pass);
        }
    }
}