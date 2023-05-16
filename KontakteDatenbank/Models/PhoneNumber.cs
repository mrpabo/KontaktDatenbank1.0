namespace KontakteDatenbankDB.Entities
{
    public partial class PhoneNumber
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string PhoneNumber1 { get; set; }

        public virtual Person Person { get; set; }

        public static object FromEntity(PhoneNumber x)
        {
            return x.Person;
        }

        public static object FromEntity(KontakteDatenbankDB.Models.PhoneNumbers phoneNumber)
        {
            return PhoneNumber.FromEntity(phoneNumber);
        }

        public static PhoneNumber ToEntity(Models.PhoneNumbers model)
        {
            PhoneNumber entity = new PhoneNumber
            {
                PhoneNumber1 = model.PhoneNumber1
            };

            return entity;
        }
    }
}
