using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KontakteDatenbank.Models
{
    public class Contact : ModelBase
    {
        public static object ItemsSource { get; internal set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public string Addres { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public string Mantra { get; set; }
        public int Id { get; set; }


        public string ImageFileName;

        public ImageSource Image { get; set; }



        public void LoadImage()
        {
            using (Image image = System.Drawing.Image.FromFile(ImageFileName))
            using (MemoryStream stream = new MemoryStream())
            {
                if (Path.GetExtension(ImageFileName).ToLower() == ".png")
                {
                    image.Save(stream, ImageFormat.Png);
                }
                else if (Path.GetExtension(ImageFileName).ToLower() == ".jpg")
                {
                    image.Save(stream, ImageFormat.Jpeg);
                }
                else if (Path.GetExtension(ImageFileName).ToLower() == ".jpeg")
                {
                    image.Save(stream, ImageFormat.Jpeg);
                }
                else if (Path.GetExtension(ImageFileName).ToLower() == ".bmp")
                {
                    image.Save(stream, ImageFormat.Bmp);
                }

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = stream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                stream.Close();

                Image = bitmapImage;
            }
        }




        public override string ToString()
        {
            return $"{LastName}, {FirstName}";
        }





        //public class ContactContext : DbContext
        //{
        //    public DbSet<Contact> Contacts { get; set; }

           
        //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //    {
        //        modelBuilder.Entity<Contact>()
        //            .HasKey(c => c.Id)
        //            .Property(c => c.Id)
        //            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        //    }

           

        //}
    }
}
