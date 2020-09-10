using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CareerCloud.BusinessLogicLayer
{
   public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>

    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
        {
        }

        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
          //  string[] comparison = new string[] { ".ca", ".com", ".biz" };

                  foreach (CompanyProfilePoco poco in pocos)
         //   {

           //     foreach (string compare in comparison)
                {
                    if (string.IsNullOrEmpty(poco.CompanyWebsite))
                     {
                        exceptions.Add(new ValidationException(600, "CompanyWebsite not"));
                     }
                     else if (poco.CompanyWebsite.EndsWith(".ca") || poco.CompanyWebsite.EndsWith(".biz") || poco.CompanyWebsite.EndsWith(".com"))
                    {

                    }
                    else
                    {
                        exceptions.Add(new ValidationException(600, "CompanyWebsite Valid websites must end with the following extensions – .ca, .com, .biz"));
                    }               
                
          
                  if (string.IsNullOrEmpty(poco.ContactPhone) == false)
                   {
                    //Match match = Regex.Match(poco.ContactPhone, @"^\d{3}-\d{3}-\d{4}$");
                    if (Regex.IsMatch(poco.ContactPhone, @"^\d{3}-\d{3}-\d{4}$") == false)
                    {
                        exceptions.Add(new ValidationException(601, "Contact Phone must correspond to a valid phone number"));
                    }
                    }
                else if (string.IsNullOrEmpty(poco.ContactPhone) == true)
                   {
                    exceptions.Add(new ValidationException(601, "Contact Phone must correspond to a valid phone number"));
                    }
                
                }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }

        }
    }
}