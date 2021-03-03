using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaElPequeñoLibro.Data;
using PruebaElPequeñoLibro.Models;
using Microsoft.EntityFrameworkCore;
namespace PruebaElPequeñoLibro.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly MyDbContext _context;
        public TodoItemService(MyDbContext context)
        {
            _context = context;
        }
        public async Task<TodoItem[]> GetIncompleteItemsAsync(ApplicationUser user)
        {
            var items = await _context.Items
            .Where(x => x.IsDone == false && x.UserId == user.Id)
            .ToArrayAsync();
            return items;            
        }

        public async Task<bool> AddItemAsync(TodoItem newItem, ApplicationUser user)
        {
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.DueAt = DateTimeOffset.Now.AddDays(3);
            _context.Items.Add(newItem);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> MarkDoneAsync(Guid id, ApplicationUser user)
        {
            var item = await _context.Items
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
            if (item == null) return false;
            item.IsDone = true;
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1; // One entity should have been updated
        }
    }
}
