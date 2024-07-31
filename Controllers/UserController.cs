using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using onlinetools.DTOs;
using onlinetools.Interfaces.RepositoryInterFaces;
using onlinetools.Interfaces.UseCase;
using onlinetools.Models;
using System.Security.Cryptography.X509Certificates;
using Ubiety.Dns.Core;

namespace onlinetools.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuth _auth;

        public UserController(IUserRepository  userRepository , IAuth auth) {
            _userRepository = userRepository;
            _auth = auth;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return CustomOk(await _userRepository.GetAll());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            return CustomOk(await _userRepository.GetById(id));
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDTO user)
        {
            _auth.CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var userModel = new User
            {
                Name = user.Name,
                Email = user.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt

            };
            await _userRepository.Add(userModel);

            string token = _auth.GenerateToken(userModel);

            UserResultDTO result = new() { 
            Name = user.Name,
            Email = user.Email,
            Token = "bearer " + token
            };
            return CustomOk(result, "User Registered Successfully");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO userDto)
        {
            var user = await _userRepository.FindUserByIEmail(userDto.Email);
            if (user == null)
            {
                return CustomError("NotFound");
            }

            if (! _auth.VerifyPasswordHash(userDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return CustomError("Incorrect password");
            }

            string token =  _auth.GenerateToken(user);
            UserResultDTO result = new()
            {
                Name = user.Name,
                Email = user.Email,
                Token = "bearer " + token
            };
            return CustomOk(result, "User Is Valid" );
        }

        [HttpPatch("Edit")]
        public async Task<IActionResult> Edit(UserEditDTO user)
        {
            var User = new User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                IsAdmin = user.IsAdmin
            };
             if (user.Password != null && user.Password.Length > 0)
            {
                _auth.CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
                User.PasswordHash = passwordHash;
                User.PasswordSalt = passwordSalt;
            }
             
            await _userRepository.Edit(User);

            return CustomOk();
        }



        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userRepository.Delete(id);
            return CustomOk();
        }

    }
}
