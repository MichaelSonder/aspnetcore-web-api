﻿using Item_Books.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Item_Books.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }

    }
}
