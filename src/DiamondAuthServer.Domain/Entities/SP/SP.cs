namespace DiamondAuthServer.Domain.Entities.SP
{
    public class SP
    {
        public const string Sp_UpdatePasswordAndPasswordTokenValidity = "dbo.Sp_UpdatePasswordAndPasswordTokenValidity @password, @salt, @userId,  @isValid, @changePasswordId";
    }
}