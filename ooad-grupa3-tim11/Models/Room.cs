using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ooad_grupa3_tim11.Models
{

   
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public AccommodationEnum AccommodationType { get; set; }
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }
        public bool BestOffer { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int Price { get; set; }


        public Room()
        {
        }

       
        public Room(int roomId, AccommodationEnum accommodationType, int hotelId, Hotel hotel, bool bestOffer, string description, string picture, int price)
        {
            RoomId = roomId;
           
            AccommodationType = accommodationType;
            HotelId = hotelId;
            Hotel = hotel;
            BestOffer = bestOffer;
            Description = description;
            Picture = picture;
            Price = price;
        }
    }
}
