using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaElPequeñoLibro.Models;

namespace PruebaElPequeñoLibro.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync(ApplicationUser user);

        Task<bool> AddItemAsync(TodoItem newItem, ApplicationUser user);
        Task<bool> MarkDoneAsync(Guid id, ApplicationUser user);

    }
}
