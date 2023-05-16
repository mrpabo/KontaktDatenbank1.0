using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontakteDatenbankDB.Models
{
    public class Address : ModelBase
    {

        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string FullAddress => $"{Street} {BuildingNumber}, {PostalCode} {City}, {State}";
       


        public override string ToString()
        {
            return FullAddress;
        }







        public static Address FromEntity(Entities.Address entity)
        {
            return new Address()
            {
                Id = entity.Id,
                PersonId = entity.PersonId,
                Street = entity.Street,
                BuildingNumber = entity.BuildingNumber,
                PostalCode = entity.PostalCode,
                City = entity.City,
                State = entity.State
            };
        }

        public  Entities.Address ToEntity()
        {
            return new Entities.Address()
            {
                Id = Id,
                PersonId = PersonId,
                Street = Street,
                BuildingNumber = BuildingNumber,
                PostalCode = PostalCode,
                City = City,
                State = State
            };
        }
    }
}
