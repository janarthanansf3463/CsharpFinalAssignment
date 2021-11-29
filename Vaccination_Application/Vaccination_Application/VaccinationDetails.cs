using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination_Application
{
    class VaccinationDetails
    {
        public VaccinationDetails(int dosage,string vaccine,DateTime date,DateTime date2)
        {
            Dosage = dosage;
            VaccineType = vaccine;
            VaccineDate1 = date;
            VaccineDate2 = date2;
          
        }
        public int Dosage { get; set; }
        public string VaccineType { get; set; }
        public DateTime VaccineDate1 { get; set; }
        public DateTime VaccineDate2 { get; set; }


    }
    public enum vaccineType
    {
        Covaxin,
        Covishield,
        Sputnik
    }
}
