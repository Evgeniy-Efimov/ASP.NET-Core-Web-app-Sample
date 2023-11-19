using System;
using System.Linq;
using WebApp.DAL;
using WebApp.Enums;
using WebApp.Interfaces;
using WebApp.Models;

namespace WebApp.BLL
{
    public class BaseService
    {
        private IAuthService _authService;
        protected readonly DB1DataContext DataContext;

        public BaseService(DB1DataContext dataContext, IAuthService authService)
        {
            DataContext = dataContext;
            _authService = authService;
        }

        protected void CheckPermissionForAction(Roles role)
        {
            if (_authService.GetAuthorizedUser() == null ||
                !_authService.GetAuthorizedUser().RoleIds.ToList().Contains((short)role))
            {
                throw new Exception("You are not authorized to perform this action");
            }
        }
    }
}
