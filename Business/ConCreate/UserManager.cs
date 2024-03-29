﻿using Business.Abstract;
using Business.Constants;
using Core.Entities.Dtos;
using Core.Utilities;
using DataAccess.Abstract;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ConCreate
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetALL());
        }

        public IDataResult<User> GetById(User entity)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UsersId == entity.UsersId));
        }

        public IDataResult<User> GetByMail(string email)
        {
            var getMail = _userDal.Get(u => u.Email == email);
            if(getMail == null)
            {
                return new ErrorDataResult<User>(Message.UserNotFound,getMail);
            }
            return new SuccessDataResult<User>(getMail,Message.UserAlreadyExists);
        }

        public IDataResult<UserDto> GetByUserMail(string user)
        {
            var getMail = _userDal.GetByUserMail(user);
            if (getMail == null)
            {
                return new ErrorDataResult<UserDto>(Message.UserNotFound, getMail);
            }
            return new SuccessDataResult<UserDto>(getMail, Message.UserAlreadyExists);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<List<UserDetailDto>> GetUserDetails()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails());
        }

        public IDataResult<UserDetailDto> GetUsersByFirstName(string FirstName)
        {
            return new SuccessDataResult<UserDetailDto>(_userDal.GetUserDetailFirstName(FirstName));
        }

        public IResult update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }
    }
}
