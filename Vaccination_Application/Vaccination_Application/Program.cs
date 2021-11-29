using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination_Application
{
    class Program
    {
        public static List<VaccinationDetails> vaccination1 = new List<VaccinationDetails>();
        public static List<BeneficieryDetails> beneficieryDetails = new List<BeneficieryDetails>();

        static void Main(string[] args)
        {
        
            int registraion_number = 1002;
            DefaultValues();
            BeneficiaryAndVaccination(registraion_number);
            
        }    
 
        public static void DefaultValues()
        {
            VaccinationDetails vaccination = new VaccinationDetails(1, "covishield", new DateTime(2021, 10, 11), new DateTime());
            vaccination1.Add(vaccination);
            BeneficieryDetails beneficiery = new BeneficieryDetails(1001,"jana", 21, 9843844959, "karaikudi", "male",vaccination1);
           
           beneficiery.VaccinationDetailsList = vaccination1;
           beneficieryDetails.Add(beneficiery);

            VaccinationDetails vaccination2 = new VaccinationDetails(2, "covaxin", new DateTime(2021, 10, 12), new DateTime(2021,11,12));
            vaccination1.Add(vaccination2);
            BeneficieryDetails beneficiery1 = new BeneficieryDetails(1002,"kirubakaran", 21, 8526369824, "kadaloor", "male",vaccination1);
            
            beneficiery.VaccinationDetailsList = vaccination1;
            beneficieryDetails.Add(beneficiery1);
           
            
        }

        public static void BeneficiaryAndVaccination(int registrationnumber)
        {
            mainmenu:
            submenu:
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("1.Benefiery Registration \n 2.Vaccination \n 3.Exit");
            int chooses=int.Parse(Console.ReadLine());
            ++registrationnumber;
            string name = "";
            int age = 0;
            long mobilenumber = 0;
            string city = "";
            string gender="";
            switch (chooses)
            {
                case 1:
                    Console.WriteLine("----------------------Registration Page-------------------------");
                    Console.WriteLine("Enter your Name");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter your Age");
                    age = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter your MobileNmber");
                    mobilenumber = long.Parse(Console.ReadLine());
                    Console.WriteLine("Enter your City");
                    city = Console.ReadLine();
                    Console.WriteLine("Gender:\n 1.Male \n 2.Female \n 3.Gender");
                    int choose = int.Parse(Console.ReadLine());
                  
                    switch (choose)
                    {
                        case 1:
                            gender = GenderSelection.Male.ToString();
                            break;
                        case 2:
                            gender = GenderSelection.Female.ToString();
                            break;
                        case 3:
                            gender = GenderSelection.Transgender.ToString();
                            break;
                        default:
                            gender = GenderSelection.others.ToString();
                            break;
                    }
                    VaccinationDetails vaccination2 = new VaccinationDetails(1, "", new DateTime(), new DateTime());
                    vaccination1.Add(vaccination2);
                    BeneficieryDetails beneficiery = new BeneficieryDetails(registrationnumber, name, age, mobilenumber, city, gender,vaccination1);
                   
                    beneficiery.VaccinationDetailsList = vaccination1;
                    
                    beneficieryDetails.Add(beneficiery);
                    Console.WriteLine("Your Vaccination Id is:"+registrationnumber);
                    
                   
                    goto submenu;
                case 2:
                    
                    Console.WriteLine("-----------Vaccination------------------------");
                    Console.WriteLine("Enter your registration number:");
                    int registration_number = int.Parse(Console.ReadLine());
                    int count = 0;
                    int index = 0;
                    foreach(var values in beneficieryDetails)
                    {
                        if (values.RegistrationNumber == registration_number)
                        {
                           
                            Console.WriteLine("1.Take Vaccination \n 2.Vaccination History \n 3.Next due Date \n 4.Exit");
                            int numberchoose = int.Parse(Console.ReadLine());
                            switch (numberchoose)
                            {
                                case 1:
                                    Console.WriteLine("Take vaccination");
                                    Console.WriteLine("1.Covaxin \n 2.Covishield");
                                    string vacctinationtype="";
                                    int num = int.Parse(Console.ReadLine());
                                    switch (num)
                                    {
                                        case 1:
                                            vacctinationtype = vaccineType.Covaxin.ToString();
                                            break;
                                        case 2:
                                            vacctinationtype = vaccineType.Covishield.ToString();
                                            break;
                                    }
                                    DateTime nexttime=new DateTime();

                                    if (values.VaccinationDetailsList[index].Dosage == 1)
                                    {
                                        values.VaccinationDetailsList[index].Dosage += 1;
                                        values.VaccinationDetailsList[index].VaccineDate1 = DateTime.Now;
                                        values.VaccinationDetailsList[index].VaccineType = vacctinationtype;
                                        nexttime = values.VaccinationDetailsList[index].VaccineDate1.AddMonths(1);
                                        values.VaccinationDetailsList[index].VaccineDate2 = nexttime;
                                        Console.WriteLine("Your next vaccination is" + nexttime.ToUniversalTime().ToShortDateString());
                                    }
                                    else if (values.VaccinationDetailsList[index].Dosage == 2)
                                    {
                                        if (values.VaccinationDetailsList[index].VaccineType.Equals(vacctinationtype))
                                        {
                                            Console.WriteLine("Vaccinated successfully finished");
                                        }
                                    }

                                    break;
                                case 2:
                                    Console.WriteLine("Vaccination History");
                                    
                                    if(values.VaccinationDetailsList[index].Dosage == 2)
                                    {
                                        Console.WriteLine("Dosage:"+values.VaccinationDetailsList[index].Dosage);
                                        Console.WriteLine("FirstDosage:"+values.VaccinationDetailsList[index].VaccineDate1.ToUniversalTime().ToShortDateString());
                                        Console.WriteLine("SecondDosage:"+values.VaccinationDetailsList[index].VaccineDate2.ToUniversalTime().ToShortDateString());
                                        Console.WriteLine("Vaccination:"+values.VaccinationDetailsList[index].VaccineType);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Dosage:"+values.VaccinationDetailsList[index].Dosage);
                                        Console.WriteLine("Vaccinated Successfully");
                                        Console.WriteLine("Vaccination:"+values.VaccinationDetailsList[index].VaccineType);
                                    }
                                    break;
                                case 3:
                                    if(values.VaccinationDetailsList[index].Dosage < 3)
                                    {
                                        Console.WriteLine("Next Date for your " +
                                            "Vaccination is:"+values.VaccinationDetailsList[index].VaccineDate2.ToUniversalTime().ToShortDateString());

                                    }
                                    else
                                    {
                                        Console.WriteLine("You have completed the vaccination course. Thanks for your participation in the vaccination drive.");
                                    }
                                    break;
                                default:
                                    break;
                            }
                            count = count + 1;
                        }
                        else
                        {
                            index = index + 1;
                            count = count + 0;
                        }
                    }
                    if(count == 0)
                    {
                        Console.WriteLine("Wrong Data input");
                    }
                    
                    goto mainmenu;
                default:
                    break;

            

            }
        }

    }
}
