using metal.Application.InterFace.Contexts;
using metal.Common;
using metal.Domain.Entities.users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Application.service.users.command
{
    public interface IRgegisterUserService
    {
        ResultDto<ResultRgegisterUserDto> Execute(RequestRgegisterUserDto request);
    }

    public class RgegisterUserService : IRgegisterUserService
    {
        private readonly IDataBaseContext _context;

        public RgegisterUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRgegisterUserDto> Execute(RequestRgegisterUserDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDto<ResultRgegisterUserDto>()
                    {
                        Data = new ResultRgegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "پست الکترونیک را وارد نمایید"
                    };
                }

                if (string.IsNullOrWhiteSpace(request.FullName))
                {
                    return new ResultDto<ResultRgegisterUserDto>()
                    {
                        Data = new ResultRgegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDto<ResultRgegisterUserDto>()
                    {
                        Data = new ResultRgegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور را وارد نمایید"
                    };
                }
                if (request.Password != request.RePasword)
                {
                    return new ResultDto<ResultRgegisterUserDto>()
                    {
                        Data = new ResultRgegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور و تکرار آن برابر نیست"
                    };
                }

                User user = new User()
                {
                    EmailAdress = request.Email,
                    fullName = request.FullName,
                    Password = request.Password,
                };

                List<Userinrole> userInRoles = new List<Userinrole>();

                foreach (var item in request.roles)
                {
                    var roles = _context.Roles.Find(item.Id);
                    userInRoles.Add(new Userinrole
                    {
                        Role = roles,
                        RoleId = roles.Id,
                        User = user,
                    //    UserId = user.Id,
                    });
                }
                user.Userinrole = userInRoles;

                _context.Users.Add(user);

                _context.SaveChanges();

                return new ResultDto<ResultRgegisterUserDto>()
                {
                    Data = new ResultRgegisterUserDto()
                    {
                        UserId = user.Id,

                    },
                    IsSuccess = true,
                    Message = "ثبت نام کاربر انجام شد",
                };
            }
            catch (DbUpdateException ex)
            {
              Console.WriteLine(ex.InnerException?.Message);
                return new ResultDto<ResultRgegisterUserDto>()
                {
                    Data = new ResultRgegisterUserDto()
                    {
                        UserId = 0,
                    },
                    IsSuccess = false,
                    Message = "ثبت نام انجام نشد !"
                };
            }
        }
    }



    public class RequestRgegisterUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePasword { get; set; }


        public List<RolesInRgegisterUserDto> roles { get; set; }
    }

    public class RolesInRgegisterUserDto
    {
        public long Id { get; set; }
    }

    public class ResultRgegisterUserDto
    {
        public long UserId { get; set; }

    }
}
