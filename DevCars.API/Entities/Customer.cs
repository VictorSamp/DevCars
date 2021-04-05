﻿using System;
using System.Collections.Generic;

namespace DevCars.API.Entities
{
    public class Customer
    {
        public Customer(int id, string fullName, string document, DateTime birthDate)
        {
            Id = id;
            FullName = fullName;
            Document = document;
            BirthDate = birthDate;
            Orders = new List<Order>();
        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Document { get; private set; }
        public DateTime BirthDate { get; private set; }
        public List<Order> Orders { get; private set; }
    }
}