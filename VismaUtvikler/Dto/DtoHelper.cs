using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VismaUtvikler.Models;

namespace VismaUtvikler.Dto
{
    public class DtoHelper
    {



        /// <summary>
        /// mapper en Customer til en Dto Customer for å lettere overføre klassen til web
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static CustomerDto MapCustomerToDtoCustomer(Customer customer)
        {

            var dtoCustomer = new CustomerDto()
            {

                Id = customer.Id,
                FirmName = customer.FirmName,
                Adress = customer.Adress,
                PhoneNumber = customer.PhoneNumber,
                FaxNumber = customer.FaxNumber,
                MailAdress = customer.MailAdress,
                PostalCode = customer.PostalCode,
               
            };



            return dtoCustomer;
        }



        /// <summary>
        /// Mapper en liste med Customer over i Dto form
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        public static List<CustomerDto> MapCustomerListToDto(List<Customer> customers)
        {
            List<CustomerDto> dtoCustomerList = new List<CustomerDto>();
            foreach (var customer in customers)
            {
                var dtoCustomer = new CustomerDto()
                {
                    Id = customer.Id,
                    FirmName = customer.FirmName,
                    Adress = customer.Adress,
                    PhoneNumber = customer.PhoneNumber,
                    FaxNumber = customer.FaxNumber,
                    MailAdress = customer.MailAdress,
                    PostalCode = customer.PostalCode,
                 



                };
                dtoCustomerList.Add(dtoCustomer);
            }

            return dtoCustomerList;
        }






        /// <summary>
        /// Mapper en CustomerContactperson over i en contactPersonDto for
        /// </summary>
        /// <param name="contactPerson"></param>
        /// <returns></returns>

        private static ContactPersonDto MapContactPersonToDtoPerson(CustomerContactPerson contactPerson)
        {

            var dtoContact = new ContactPersonDto()
            {

                Id = contactPerson.Id,
                FirstName = contactPerson.FirstName,
                Adress = contactPerson.Adress,
                PhoneNumber = contactPerson.PhoneNumber,
               MailAdress = contactPerson.MailAdress,
                PostalCode = contactPerson.PostalCode,
                CustomerId= contactPerson.Customer.Id
             

            };



            return dtoContact;
        }

        /// <summary>
        /// Mapper en liste med CustomerContctPerson over i Dto form
        /// </summary>
        /// <param name="contactPersons"></param>
        /// <returns></returns>


        private static List<ContactPersonDto> MapContList(List<CustomerContactPerson> contactPersons)
        {
            List<ContactPersonDto> dtoList = new List<ContactPersonDto>();



       
            foreach (var contact in contactPersons)
            {
               
                dtoList.Add(MapContactPersonToDtoPerson(contact));
            }


            return dtoList;

        }


    }
}