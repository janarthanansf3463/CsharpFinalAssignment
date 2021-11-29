using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination_Application
{
    
    class BeneficieryDetails
    {
        public BeneficieryDetails(int registrationNumber ,string name,int age,long MobileNumber,string city,string gender,List<VaccinationDetails> vaccination1)
        {
            RegistrationNumber = registrationNumber;
            beneficieryName = name;
            Age = age;
            MobilelNumber = MobileNumber;
            City = city;
            Gender = gender;
            VaccinationDetailsList = vaccination1;
        }
        public int RegistrationNumber { get; set; }
        public string beneficieryName { get; set; }
        public int Age { get; set; }
        public long MobilelNumber { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }

        public List<VaccinationDetails> VaccinationDetailsList { get; set; }
        
        

    }
    public enum GenderSelection
    {
        Male,
        Female,
        Transgender,
        others
    }
}
