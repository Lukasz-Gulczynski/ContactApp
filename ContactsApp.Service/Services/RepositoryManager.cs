using AutoMapper;
using ContactsApp.Core.Models;
using ContactsApp.Repo.Data;
using ContactsApp.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace ContactsApp.Service.Services
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;

        private IContactsRepository _contactsRepository;
        private ICategoryRepository _categoryRepository;
        private IUserAuthenticationRepository _userAuthenticationRepository;
        private UserManager<User> _userManager;
        private IMapper _mapper;
        private IConfiguration _configuration;

        public RepositoryManager(RepositoryContext repositoryContext, UserManager<User> userManager, IMapper mapper, IConfiguration configuration)
        {
            _repositoryContext = repositoryContext;
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        public IContactsRepository Contact
        {
            get
            {
                if (_contactsRepository is null)
                    _contactsRepository = new ContactsRepository(_repositoryContext);
                return _contactsRepository;
            }
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_categoryRepository is null)
                    _categoryRepository = new CategoryRepository(_repositoryContext);
                return _categoryRepository;
            }
        }

        public IUserAuthenticationRepository UserAuthentication
        {
            get
            {
                if (_userAuthenticationRepository is null)
                    _userAuthenticationRepository = new UserAuthenticationRepository(_userManager, _configuration, _mapper);
                return _userAuthenticationRepository;
            }
        }
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
