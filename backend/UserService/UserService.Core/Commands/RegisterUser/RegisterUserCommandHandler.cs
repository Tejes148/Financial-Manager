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
            var userExist = await _userRepository.ExistsByEmailAsync(request.Email, cancellationToken);

            if (userExist is not null)
                throw new Exception("Email already available");

            var hassPass = PasswordHash(request.Password);

            var user = new User
            {
                UserId = Guid.NewGuid(),
                Email = request.Email,
                PasswordHash = hassPass,
                UserName = request.UserName,
                CreatedAt = DateTime.UtcNow,
                LastLoginAt = DateTime.UtcNow
            };

            var Id = await _userRepository.AddUserAsync(user,cancellationToken);

            return Id;
        }

        public string PasswordHash(string pass)
        {
            return BCrypt.Net.BCrypt.HashPassword(pass);
        }
    }
}