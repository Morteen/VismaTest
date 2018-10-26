using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VismaUtvikler.Models;

namespace VismaUtvikler.Dto
{
    public class DtoHelper
    {

        ///////Customer//////////

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

        public static Customer MapDtoCustomerToCustomer(CustomerDto dtoCustomer)
        {
            return  new Customer()
            {

                FirmName = dtoCustomer.FirmName,
                Adress = dtoCustomer.Adress,
                PhoneNumber = dtoCustomer.PhoneNumber,
                FaxNumber = dtoCustomer.FaxNumber,
                MailAdress = dtoCustomer.MailAdress,
                PostalCode = dtoCustomer.PostalCode

            };
            

        }


        ///////////////////ContactPerson//////////////////////////

        /// <summary>
        /// Mapper en CustomerContactperson over i en contactPersonDto for
        /// </summary>
        /// <param name="contactPerson"></param>
        /// <returns></returns>

      public static ContactPersonDto MapContactPersonToDtoPerson(CustomerContactPerson contactPerson)
        {

            var dtoContact = new ContactPersonDto()
            {

                Id = contactPerson.Id,
                FirstName = contactPerson.FirstName,
                lastName = contactPerson.lastName,
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


        public static List<ContactPersonDto> MapContList(List<CustomerContactPerson> contactPersons)
        {
            List<ContactPersonDto> dtoList = new List<ContactPersonDto>();



       
            foreach (var contact in contactPersons)
            {
               
                dtoList.Add(MapContactPersonToDtoPerson(contact));
            }


            return dtoList;

        }
        ////////////////////////CustomerType///////////
        public static CustomerTypeDto MapTypeToTypeDto(CustomerType customerType)
        {
            var dtoType = new CustomerTypeDto()
            { CustomerTypeName= customerType.CustomerTypeName,
                Description= customerType.Description,
                Id=customerType.Id
            };
            return dtoType;
        }

        public static List<CustomerTypeDto> MapTypeListToDtoList(List<CustomerType> customerTypes)
        {
            var dtoList = new List<CustomerTypeDto>();
            
            foreach (var type in customerTypes)
            {
                dtoList.Add(MapTypeToTypeDto(type));

            }

            



            return dtoList;
        }
        ///////CustomerToTypes
        public static CustomerToType Map_customerToTypeDto_ToType(CustomerToTypeDto customerToTypeDto)
        {
            var customerTotype= new CustomerToType()
            {
                CustomerId= customerToTypeDto.CustomerId,
             CustomerTypeId = customerToTypeDto.CustomerTypeId
             
            };
            return customerTotype;
        }

        ///prøver igjen fra customerToType til dto

        public static CustomerToTypeDto MapOne(CustomerToType customerToType)
        {

            var temp = new CustomerToTypeDto()
            {
                CustomerTypeId = customerToType.CustomerTypeId,
                CustomerId = customerToType.CustomerId
            };
            return temp;

        }


        public static List<CustomerToTypeDto> MapList(List<CustomerToType> customerToType)
        {
            List<CustomerToTypeDto> tempList = new List<CustomerToTypeDto>();
            foreach (var type in customerToType)
            {
                tempList.Add(MapOne(type));
                
            }

            return tempList;
        }

    }
}