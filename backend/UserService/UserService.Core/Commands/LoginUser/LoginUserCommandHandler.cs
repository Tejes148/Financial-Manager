using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Core.DTOs;
using UserService.Core.Interfaces;

namespace UserService.Core.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserResultDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtService;
        public LoginUserCommandHandler(IUserRepository userRepository, IJwtTokenService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<LoginUserResultDTO> Handle(LoginUserCommand LoginCommand, CancellationToken cancellationToken)
        {
            var userExist = await _userRepository.ExistsByEmailAsync(LoginCommand.EmailId, cancellationToken);

            if (userExist == null ||  !VerifyPassword(LoginCommand.Password, userExist.PasswordHash))
            {
                return new LoginUserResultDTO
                {
                    Success = false,
                    FailureMessage = "Invalid email or password"
                };
            }

            // Generate JWT and Refresh Token logic here
            var jwt = _jwtService.GenerateJwtToken(userExist.UserId, userExist.Email);

            var RefreshToken = _jwtService.GenerateRefreshToken(); // Placeholder for actual refresh token generation
            var expiry = DateTime.UtcNow.AddDays(7);

            await _userRepository.SaveRefreshTokenAsync(userExist.UserId, RefreshToken, expiry, cancellationToken);
            await _userRepository.UpdateLastLoginAsync(userExist.UserId, DateTime.UtcNow, cancellationToken);

            return new LoginUserResultDTO
            {
                Success = true,
                JwtToken = jwt,
                RefreshToken = RefreshToken
            };

        }

        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
        }
    }
}
