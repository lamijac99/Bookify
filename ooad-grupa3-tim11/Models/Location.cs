using System.ComponentModel.DataAnnotations;

namespace ooad_grupa3_tim11.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        public Double XCoordinates { get; set; }
        public Double YCoordinates { get; set; }
        public String Name { get; set; }

        public Location(int locationId, double xCoordinates, double yCoordinates, string name)
        {
            LocationId = locationId;
            XCoordinates = xCoordinates;
            YCoordinates = yCoordinates;
            Name = name;
        }

        public Location()
        {
        }


    }
}
