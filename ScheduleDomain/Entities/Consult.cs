using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleDomain.Entities;

public class Consult : Entity
{
    [ForeignKey("Schedule")]
    public Guid ScheduleId { get; set; }
    [MaxLength(5000)]
    public string? DoctorDescription { get; set; }
}

