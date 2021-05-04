using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ConCreate
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Password = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Message.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Message.UserNotFound,userToCheck);
            }             

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Password,userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Message.PasswordError, userToCheck);
            }

            return new SuccessDataResult<User>(userToCheck, Message.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            var data = _userService.GetByMail(email);
            if (data.Data == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult(Message.UserAlreadyExists);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Message.AccessTokenCreated);
        }
    }
}
