using metal.Application.InterFace.Contexts;
using metal.Common;

namespace metal.Application.service.users.quary.get
{
    public class getuserService : Igetuserservice
    {
        private readonly IDataBaseContext _context;
        public getuserService(IDataBaseContext context)
        {
            _context = context;
        }


         ReslutGetUserDto Igetuserservice.Execute(string searchkey, int page=1)
        {
            var users = _context.Users.AsQueryable();
            if (!String.IsNullOrWhiteSpace(searchkey))
            {
                users = users.Where(p => p.fullName.Contains(searchkey) || p.Cuntry.Contains(searchkey) || p.EmailAdress.Contains(searchkey));
            }
            int rowsCount = 0;
            var res = users.ToPaged(page, 20, out rowsCount).Select(p => new Getuserdto
            {
                EmailAdress = p.EmailAdress,
                fullName = p.fullName,
           //     Adress = p.Adress,
                Cuntry = p.Cuntry,
                Id = p.Id,
                isactive = p.isactive
                
            }).ToList();

            return new ReslutGetUserDto
            {
                Rows = rowsCount,
                Users = res
            };
        }
    }
}
