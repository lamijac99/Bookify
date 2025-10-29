using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace ooad_grupa3_tim11.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        public String Name { get; set; }
        public CategoryEnum Category { get; set; }
        public String Description { get; set; }
        public Double Price { get; set; }
        public String Image { get; set; }

        public Hotel(int hotelId, int locationId, Location location, string name, CategoryEnum category, string description, double price, String image)
        {
            HotelId = hotelId;
            LocationId = locationId;
            Location = location;
            Name = name;
            Category = category;
            Description = description;
            Price = price;
            Image = image;
        }

        public Hotel()
        {
        }
    }
}
