using ContactsApp.Core.Models;
using ContactsApp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApp.Service.ActionFilters
{
    public class ValidateContactExists : IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public ValidateContactExists(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository; _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var trackChanges = context.HttpContext.Request.Method.Equals("PUT")!;

            var id = (int)context.ActionArguments[context.ActionArguments.Keys.Where(x => x.Equals("id") || x.Equals("contactId")).SingleOrDefault()];

            var contact = await _repository.Contact.GetContact(id, trackChanges);
            if (contact is null)
            {
                _logger.LogInfo($"Contact with id: {id} doesn't exist in the database.");
                var response = new ObjectResult(new ResponseModel
                {
                    StatusCode = 404,
                    Message = $"Contact with id: {id} doesn't exist in the database."
                });
                context.Result = response;
            }
            else
            {
                context.HttpContext.Items.Add("contact", contact);
                await next();
            }
        }
    }
}
