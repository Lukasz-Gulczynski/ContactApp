namespace ContactsApp.Service.Interfaces
{
    public interface IRepositoryManager
    {
        IContactsRepository Contact { get; }
        ICategoryRepository Category { get; }
        IUserAuthenticationRepository UserAuthentication { get; }
        Task SaveAsync();
    }
}
