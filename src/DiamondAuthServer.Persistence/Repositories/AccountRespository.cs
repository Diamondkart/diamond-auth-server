using DiamondAuthServer.ApplicationCore.Ports.Out.IRepositories;
using DiamondAuthServer.Domain.Entities;
using DiamondAuthServer.Domain.Entities.SP;
using DiamondAuthServer.Persistence.DBStorage;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DiamondAuthServer.Persistence.Repositories
{
    public class AccountRespository : IAccountRespository
    {
        private readonly UserDBContext _dBContext;

        public AccountRespository(UserDBContext context)
        {
            _dBContext = context;
        }

        public async Task<ChangePassword> RequestChangePasswordAsync(ChangePassword changePassword)
        {
            _dBContext.ChangePassword.Add(changePassword);
            await _dBContext.SaveChangesAsync();
            return changePassword;
        }

        public Task<bool> GeneratePasswordAsync(UserDetail userDetails)
        {
            throw new NotImplementedException();
        }

        public async Task<ChangePassword> GetChangePasswordByTokenPasswordAsync(ChangePassword changePassword)
        {
            var changePasswordDb = _dBContext.ChangePassword.AsNoTracking()
                .Where(x => x.TempPassword == changePassword.TempPassword && x.Token == changePassword.Token)
                ?.FirstOrDefault();
            return await Task.FromResult(changePasswordDb);
        }

        public async Task<bool> UpdatePasswordAndPasswordTokenValidityAsync(UserDetail user, ChangePassword changePassword)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@password", user.Password),
                new SqlParameter("@salt", user.Salt),
                new SqlParameter("@userId", user.UserId),
                new SqlParameter("@isValid", changePassword.IsValid),
                new SqlParameter("@changePasswordId", changePassword.Id)
            };
            var result = await _dBContext.Database.ExecuteSqlRawAsync(SP.Sp_UpdatePasswordAndPasswordTokenValidity, parameters);
            return result > 0;
        }

        public async Task<UserDetail> CreateAccountAsync(UserDetail userDetail)
        {
            _dBContext.Users.Add(userDetail);
            await _dBContext.SaveChangesAsync();
            return userDetail;
        }

        public async Task<bool> CheckIfUserIsUnique(UserDetail userDetails)
        {
            var userExists = _dBContext.Users.Any(u => u.UserName == userDetails.UserName && u.FirstName == userDetails.FirstName && u.MobileNo == userDetails.MobileNo);
            return userExists;
        }
    }
}