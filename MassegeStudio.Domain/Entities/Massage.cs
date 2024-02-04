using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Domain.Entities
{
    public class Massage
    {
        public string Id { get; set; }
        public Type Type { get; set; } = default!;
        public DateTime Date { get; set; }
        public DateTime SetupDate { get; set; } = DateTime.Now;
        public string? MasseurName { get; set; }
        public string? MasseurLastName { get; set; }
        public string? MasseurId { get; set; }
        public ApplicationUser? Masseur { get; set; }
        public bool Free { get; set; } = true;
        public string? ClientName { get; set; }
        public string? ClientLastName { get; set; }
        public string? ClientId { get; set; }
        public ApplicationUser? Client { get; set; }

        public Massage(string masseurId, string masseurName, string masseurLastName, DateTime date)
        {
            MasseurLastName = masseurLastName;
            Id = Guid.NewGuid().ToString();
            MasseurId = masseurId;
            MasseurName = masseurName;
            Date = date;
            SetupDate = DateTime.Now;
            Free = true;
        }
        public Massage()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
