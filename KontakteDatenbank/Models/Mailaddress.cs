using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;

namespace KontakteDatenbankDB.Models
{
    public class Mailaddress : ModelBase
    {


        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Mailaddress1 { get; set; }
       
       






        public override string ToString()
        {
            return Mailaddress1;
        }







        public static Mailaddress FromEntity(Entities.Mailaddress entity)
        {
            return new Mailaddress()
            {
               Mailaddress1 = entity.Mailaddress1
            };
        }

        public static Entities.Mailaddress ToEntity(Mailaddress model)
        {
            return new Entities.Mailaddress()
            {
                Mailaddress1 = model.Mailaddress1
            };
        }

        public Entities.Mailaddress ToEntity()
        {
            return new Entities.Mailaddress()
            {
                Id = Id,
                PersonId = PersonId,
               Mailaddress1 = Mailaddress1
            };
        }

        
    }
}

