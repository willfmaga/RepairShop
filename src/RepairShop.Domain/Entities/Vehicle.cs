using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Entities
{
    public class Vehicle
    {
        public Int64 Id { get; set; }
        public string Plate { get; set; }
        public string Name { get; set; }

        public VehicleType? TypeId { get; set; }

        public VehicleBrand? BrandId { get; set; }
        public string? Model { get; set; }

        public VehicleColor? ColorId { get; set; }

        public Int16? ManufacturingYear { get; set; }
        public Int16? Year { get; set; }

        public bool? Active { get; set; }

        public DateTime? CreationDate { get; set; } = DateTime.Now;

    }

    public enum VehicleType
    {
        none = 0,
        [Display(Name = "Moto")]
        Bike = 1,
        [Display(Name = "Carro")]
        Car = 2,
        [Display(Name = "Caminhao")]
        Truck = 3
    }

    public enum VehicleBrand
    {
        none = 0,
        [Display(Name = "Honda")]
        Honda = 1,
        [Display(Name = "Harley Davidson")]
        HarleyDavidson = 2
    }

    public enum VehicleColor
    {
        none = 0,
        [Display(Name = "Vermelha")]
        Red = 1,
        [Display(Name = "Verde")]
        Green = 2,
        [Display(Name = "Preta")]
        Black = 3,
        [Display(Name = "Azul")]
        Blue = 4,
        [Display(Name = "Amarela")]
        Yellow = 5,
        [Display(Name = "Branca")]
        White = 6,
        [Display(Name = "Cinza")]
        Gray = 7,
        [Display(Name = "Roxa")]
        Purple = 8,
        [Display(Name = "Bege")]
        Beige = 9
    }
}
