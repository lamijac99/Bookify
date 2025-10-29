using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ooad_grupa3_tim11.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        public RegisteredUser User { get; set; }

        public int RoomId;
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        public string Text { get; set; }


       
        public int Rating { get; set; }

        public Review(int id, RegisteredUser userId, int roomId,Room room, string text, int rating)
        {
            ReviewID = id;
            User = userId;
            RoomId = roomId;
            Room = room;
            Text = text;
            Rating = rating;
        }
        public Review()
        {
        }
    }
}
