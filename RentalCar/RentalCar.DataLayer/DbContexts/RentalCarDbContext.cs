﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCar.DataLayer.Models;

namespace RentalCar.DataLayer.DbContexts
{
    /// <summary>
    /// Klasa modelująca bazę danych
    /// </summary>
    public class RentalCarDbContext : DbContext
    {
        /// <summary>
        /// Podstawowy konstruktor
        /// </summary>
        public RentalCarDbContext() : base(GetConnectionString()) { }

        /// <summary>
        /// Tabelę CarType
        /// </summary>
        public DbSet<CarType> CarTypesDbSet {get; set; }

        /// <summary>
        /// Tabela z Car for Rent
        /// </summary>
        public DbSet<CarForRent> CarForRentsDbSet { get; set; }

        /// <summary>
        /// Tabela z Customers
        /// </summary>
        public DbSet<Customer> CustomersDbSet { get; set; }

        /// <summary>
        /// Tabela z Promocjami
        /// </summary>
        public DbSet<Sale> SaleDbSet { get; set; }

        /// <summary>
        /// Tabela z many to many
        /// </summary>
        public DbSet<CarsRentedByCustomers> CarsRentedByCustomersesDbSet { get; set; }

        /// <summary>
        /// Pobiera conection stringa
        /// </summary>
        /// <returns>Obiekt typu string, który jest connectionString</returns>
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["RentalCarSql"].ConnectionString;
        }
    }
}
