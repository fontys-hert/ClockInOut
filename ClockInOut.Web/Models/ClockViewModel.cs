using System.ComponentModel.DataAnnotations;

namespace ClockInOut.Web.Models
{
    public class ClockViewModel
    {
        [Required] public string? Name { get; set; }
        public DateTime DateClocked { get; set; }
    }
}
