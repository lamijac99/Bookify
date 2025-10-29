using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ooad_grupa3_tim11.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        public string RegisteredUserId { get; set; }
        [ForeignKey("RegisteredUserId")]
        public RegisteredUser RegisteredUser { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Price { get; set; }

        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }


        public Reservation()
        {

        }

       
        public Reservation(int reservationId, RegisteredUser registeredUser, DateTime startDate, DateTime endDate, int price, Room room)
        {
            ReservationId = reservationId;
            RegisteredUser = registeredUser;
            StartDate = startDate;
            EndDate = endDate;
            Price = price;
            Room = room;
        }
    }
}
