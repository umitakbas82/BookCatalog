using BookCatalog.Infrastructure.Context;
using BookCatalogApplication.Interfaces;
using BookCatalogDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}
