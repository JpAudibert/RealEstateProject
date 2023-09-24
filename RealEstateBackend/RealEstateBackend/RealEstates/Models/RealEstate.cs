﻿namespace RealEstateBackend.RealEstates.Models
{
    public sealed class RealEstate
    {
        public Guid Id { get; }
        public bool IsActive { get; set; }
        public string ComercialType { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Number { get; set; }
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public double SquareFoot { get; set; }
        public double PrivateSquareFoot { get; set; }
        public double SellValue { get; set; }
        public double RentValue { get; set; }
        public double Price { get; set; }
        public Guid PropertyTypeId { get; set; }
    }
}