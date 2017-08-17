using System.ComponentModel.DataAnnotations;

namespace Fixit.Models
{
    public class Identity
    {
        [Key]
        public int id {get;set;}
        public bool enable {get;set;}
    }
}