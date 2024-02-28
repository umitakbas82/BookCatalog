using BookCatalogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BookCatalogApplication.Interfaces
{
    public interface IBooKRepository
    {
        Task AddAsync(Book book);
    }
}
