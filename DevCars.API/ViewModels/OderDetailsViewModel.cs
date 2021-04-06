using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.ViewModels
{
    public class OderDetailsViewModel
    {
        public OderDetailsViewModel(int idCar, int idCostumer, decimal totalCost, List<string> extraItems)
        {
            IdCar = idCar;
            IdCostumer = idCostumer;
            TotalCost = totalCost;
            ExtraItems = extraItems;
        }

        public int IdCar { get; set; }
        public int IdCostumer { get; set; }
        public decimal TotalCost { get; set; }
        public List<string> ExtraItems { get; set; }
    }
}