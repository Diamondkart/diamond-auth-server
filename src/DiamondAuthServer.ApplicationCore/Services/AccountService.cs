using AutoMapper;
using DiamondAuthServer.ApplicationCore.Models.Request;
using DiamondAuthServer.ApplicationCore.Models.Response;
using DiamondAuthServer.ApplicationCore.Ports.Out.IRepositories;
using DiamondAuthServer.ApplicationCore.Ports.Out.IServices;
using DiamondAuthServer.Domain.Constants;
using DiamondAuthServer.Domain.Entities;
using DiamondAuthServer.Domain.Exceptions;

namespace DiamondAuthServer.ApplicationCore.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IAccountRespository _accountRespository;

        public AccountService(IMapper mapper, IAccountRespository accountRespository)
        {
            _mapper = mapper;
            _accountRespository = accountRespository;
        }

        
    }
}