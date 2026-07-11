using metal.Application.InterFace.Contexts;
using metal.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Application.service.users.command.UserStatusChange
{
    public interface IUserSatusChangeService
    {
        ResultDto Execute(long UserId);
    }

    public class UserSatusChangeService : IUserSatusChangeService
    {
        private readonly IDataBaseContext _context;


        public UserSatusChangeService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(long UserId)
        {
            var user = _context.Users.Find(UserId);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }

            user.isactive= !user.isactive;
            _context.SaveChanges();
            string userstate = user.isactive == true ? "فعال" : "غیر فعال";
            return new ResultDto()
            {
                IsSuccess = true,
                Message = $"کاربر با موفقیت {userstate} شد!",
            };
        }
    }
}
