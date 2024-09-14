using System.ComponentModel.DataAnnotations;

namespace SampleWebApiCore.Models
{
    public class DepartmentRequest
    {
        [Required(AllowEmptyStrings =false)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
