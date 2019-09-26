using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.DynamicData;

namespace ApplicationLayer.DTOs
{
    [TableName("Employee")]
    public class EmployeeDTO1
    {
        [Key]
        public int EmployeeID { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        public string Title { get; set; }

        [DisplayName("Title Of Courtesy")]
        public string TitleOfCourtesy { get; set; }

        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public Nullable<System.DateTime> BirthDate { get; set; }

        [DisplayName("Hire Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public Nullable<System.DateTime> HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }
        public string Country { get; set; }
        [DisplayName("Home Phone")]
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        [DisplayName("Reports To")]
        public Nullable<int> ReportsTo { get; set; }
        //public string PhotoPath { get; set; }
        //---------------------------------------------------------------------------

        public Employee Employee1 { get; set; }
        
    }
}
