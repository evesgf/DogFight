using Microsoft.EntityFrameworkCore;
using TestMySql.Entity;

namespace TestMySql.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string Test()
        {
            var repo = _unitOfWork.GetRepository<UserList>();
            repo.Insert(new UserList
            {
                UserName="admin",
                PassWord="123456"
            });
            _unitOfWork.SaveChanges();  //提交到数据库
            var re = repo.GetFirstOrDefault()?.UserName ?? string.Empty;
            return re;
        }
    }
}
