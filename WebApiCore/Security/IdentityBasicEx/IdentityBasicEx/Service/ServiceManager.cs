using AutoMapper;
using IdentityBasicEx.Contracts;
using IdentityBasicEx.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityBasicEx.Service
{
	public sealed class ServiceManager : IServiceManager
	{
		private readonly Lazy<IAuthenticationService> _authenticationService;

		public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, UserManager<User> userManager,
			IConfiguration configuration)
		{
			_authenticationService = new Lazy<IAuthenticationService>(() =>
				new AuthenticationService(mapper, userManager, configuration));
		}

		public IAuthenticationService AuthenticationService => _authenticationService.Value;
	}
}
