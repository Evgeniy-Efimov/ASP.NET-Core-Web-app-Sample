using System.Linq;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class AuthDataViewModel : AuthData
    {
        private const byte LoginParts = 2;
        private const char DomainLoginSeparator = '\\';

        public AuthData GetAuthData()
        {
            if (!string.IsNullOrWhiteSpace(Login) && Login.Contains(DomainLoginSeparator))
            {
                var domainLoginParts = Login.Split(DomainLoginSeparator).Where(x => !string.IsNullOrWhiteSpace(x));

                if (domainLoginParts?.Count() == LoginParts)
                {
                    return new AuthData() { Login = domainLoginParts.ElementAt(1), Domain = domainLoginParts.First(), Password = Password };
                }
            }

            return new AuthData() { Login = Login, Domain = string.Empty, Password = Password };
        }
    }
}
