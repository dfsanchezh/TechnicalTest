using ApiAmarisCore.ICore;
using ApiAmarisDto.Dto;
using ApiAmarisService.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAmarisService.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationCore _authenticationCore;
        public AuthenticationService(IAuthenticationCore authenticationCore)
        {
            _authenticationCore = authenticationCore;
        }

        public TokenJwtDTO GetAuthentication()
        {
            return _authenticationCore.GetAuthentication();
        }
    }
}
