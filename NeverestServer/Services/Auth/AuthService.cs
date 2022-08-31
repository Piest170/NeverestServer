using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NeverestServer.Data.Dtos.User;
using NeverestServer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NeverestServer.Services
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Users
                .Include(u => u.Character)
                .FirstOrDefaultAsync(u => u.Username.ToLower().Equals(username.ToLower()));

            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            //else if (user.VerifiedTime == null)
            //{
            //    response.Success = false;
            //    response.Message = "User not Verified";
            //}
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong password.";
            }
            else
            {
                response.Data = user.Character.CharacterId.ToString();
            }

            return response;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            if (await UserExists(user.Email, user.Username))
            {
                response.Success = false;
                response.Message = "User already exists.";
                return response;
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Token = CreateToken(user);
            

            _context.Users.Add(user);

            Character character = new Character()
            {
                User = user,
                Job = _context.Jobs.First(j => j.JobId == 1)
            };

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            response.Data = user.Id;
            return response;
        }

        public async Task<ServiceResponse<string>> Verify(string token)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Token == token);
            if (user == null)
            {
                response.Success = false;
                response.Message = "Invalid Token";
            }

            user.VerifiedTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<ServiceResponse<string>> ForgotPassword(string email)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not Found";
            }

            user.ResetPasswordToken = CreateToken(user);
            user.TokenExpired = DateTime.Now.AddDays(1);
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<ServiceResponse<UserResetDto>> ResetPassword(UserResetDto reset)
        {
            ServiceResponse<UserResetDto> response = new ServiceResponse<UserResetDto>();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.ResetPasswordToken == reset.Token);
            if (user == null || user.TokenExpired < DateTime.Now)
            {
                response.Success = false;
                response.Message = "Invalid Token";
            }

            CreatePasswordHash(reset.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.ResetPasswordToken = null;
            user.TokenExpired = null;

            await _context.SaveChangesAsync();

            return response;
        }

        public async Task<bool> UserExists(string email, string username)
        {
            if (await _context.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower()) || 
               (await _context.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower())))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
