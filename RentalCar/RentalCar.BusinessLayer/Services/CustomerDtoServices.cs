﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCar.BusinessLayer.Dtos;
using RentalCar.BusinessLayer.Mappers;
using RentalCar.DataLayer.Repository;

namespace RentalCar.BusinessLayer.Services
{
    public class CustomerDtoServices
    {
        /// <summary>
        /// Dodaje nowy, unikatowy nowy Customer, zwraca false jeżeli taki już jest
        /// </summary>
        /// <param name="customerDto"></param>
        /// <returns></returns>
        public static bool Add(CustomerDto customerDto)
        {
            if (Exist(customerDto))
                return false;

            return new CustomerRepository().Add(DtoToEntityMapper.CustomerDtoToEntityModel(customerDto));
        }

        /// <summary>
        /// Sprawdza czy dany Dto istniej jako model w bazie danych
        /// </summary>
        /// <param name="customerDto"></param>
        /// <returns></returns>
        public static bool Exist(CustomerDto customerDto)
        {
            return new CustomerRepository()
                .Exist(DtoToEntityMapper.CustomerDtoToEntityModel(customerDto));
        }

        /// <summary>
        /// Zwraca wszystkie modele jako lista Dto z bazy danych
        /// </summary>
        /// <returns></returns>
        public static List<CustomerDto> GetAll()
        {
            return new CustomerRepository()
                .GetAll()
                .Select(EntityToDtoMapper.CustomerEntityModelToDto)
                .ToList();
        }

        /// <summary>
        /// Sprawdza czy pesel jest poprawny
        /// </summary>
        /// <param name="pesel"></param>
        /// <returns></returns>
        public static bool CheckPesel(long pesel)
        {
            return pesel.ToString().Length == 11;
        }

        /// <summary>
        /// Pobiera użytkownika po peselu, null jezeli on nie istnieje
        /// </summary>
        /// <param name="pesel"></param>
        /// <returns></returns>
        public static CustomerDto Get(long pesel)
        {
            if (!Exist(new CustomerDto() {Pesel = pesel}))
                return null;

            return EntityToDtoMapper.CustomerEntityModelToDto
                (new CustomerRepository().Get(pesel));
        }

        /// <summary>
        /// Uaktualnia dane personalne
        /// </summary>
        /// <param name="oldCustomer">Stary klient</param>
        /// <param name="newCustomer">Nowy klient</param>
        /// <returns></returns>
        public static bool UpadtePersonalData(CustomerDto oldCustomer,CustomerDto newCustomer)
        {
            if (!Exist(oldCustomer))
                return false;

            return new CustomerRepository()
                .UpdatePersonalData(
                    DtoToEntityMapper.CustomerDtoToEntityModel(oldCustomer),
                    DtoToEntityMapper.CustomerDtoToEntityModel(newCustomer));
        }
    }
}
