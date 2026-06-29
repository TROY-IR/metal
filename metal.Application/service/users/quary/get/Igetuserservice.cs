using metal.Application.InterFace.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Application.service.users.quary.get
{
    public interface Igetuserservice
    {
        List<Getuserdto> execute(string searchkey, int page = 1);
    }


    public class getuserService : Igetuserservice
    {
        private readonly IDataBaseContext _context;
        public getuserService(IDataBaseContext context)
        {
            _context = context;
        }


        List<Getuserdto> Igetuserservice.execute(string searchkey, int page=1)
        {
            var users = _context.Users.AsQueryable();
            if (!String.IsNullOrWhiteSpace(searchkey))
            {
                users = users.Where(p => p.fullName.Contains(searchkey) && p.Cuntry.Contains(searchkey) && p.EmailAdress.Contains(searchkey));
            }
        }
    }
    public class Getuserdto
    {
        public long Id { get; set; }
        public string fullName { get; set; }
        public string Adress { get; set; }
        public int Age { get; set; }
        public string Cuntry { get; set; }
        public string EmailAdress { get; set; }
        public int PostCode { get; set; }
    }
}
