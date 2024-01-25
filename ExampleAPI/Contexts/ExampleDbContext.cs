﻿using System;
using ExampleAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExampleAPI.Contexts;
public class ExampleDbContext:DbContext
{
    protected IConfiguration Configuration;
    public ExampleDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Configuration.GetValue<string>("ConnectionStrings:Production");
        optionsBuilder.UseSqlServer(connectionString);
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<ProductTransaction> ProductTransactions { get; set; }
    public DbSet<AccountTransaction> AccountTransactions { get; set; }
	public DbSet<CreditCard> CreditCard { get; set; }
	public DbSet<CreditCardTransaction> CreditCardTransactions { get; set; }
}


