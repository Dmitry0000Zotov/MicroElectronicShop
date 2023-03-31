using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroElectronic.Domain.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Size { get; set; }

        public string BodyMaterial { get; set; }

        public string WorkingArea { get; set; }

        public string Power { get; set; }

        public string GuaranteePeriod { get; set; }

        public string FullDescription { get; set; }

        public string ImageUrl { get; set; }

    }
}
