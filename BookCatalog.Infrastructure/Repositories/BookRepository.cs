using BookCatalog.Infrastructure.Context;
using BookCatalogApplication.Interfaces;
using BookCatalogDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Infrastructure.Repositories
{
    public class BookRepository:IBookRepository
    {
        private readonly BookCatalogDbContext context;
        public BookRepository(IDbContextFactory<BookCatalogDbContext> factory)
        {
            context=factory.CreateDbContext();
        }

        public async Task AddAsync(Book book)
        {
            context.Books.Add(book);
            await context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
           var book= await GetByIdAsync(id);
            if(book is not null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Book>> GetAllAsync()
        {
            var books=await context.Books.ToListAsync();
            return books;
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            var book =await context.Books.FirstOrDefaultAsync(e=> e.Id==id);
            return book;
        }

        public async Task UpdateAsync(Book book)
        {
            context.Entry(book).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
