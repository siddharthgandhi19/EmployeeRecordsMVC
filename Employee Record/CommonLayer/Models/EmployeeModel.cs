using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models
{
    public class EmployeeModel
    {
            public int EmployeeId { get; set; }
        
            public string Name { get; set; }
            
            public string Gender { get; set; }
           
            public string Department { get; set; }
            
            public string City { get; set; }
        
    }
}
