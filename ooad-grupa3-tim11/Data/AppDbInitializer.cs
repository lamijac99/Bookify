using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ooad_grupa3_tim11.Models;
using static System.Net.Mime.MediaTypeNames;
namespace ooad_grupa3_tim11.Data
{
    public class AppDbInitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();


                //Location

                if (!context.Location.Any()) 
                {

                    context.Location.AddRange(new List<Location>()
                    { 
                       new Location()
                       {
                           XCoordinates = 43.867996528,
                           YCoordinates = 18.405165046,
                           Name = "Sarajevo"

                       },

                       new Location()
                       {
                           XCoordinates = 43.34333,
                           YCoordinates = 17.80806,
                           Name = "Mostar"

                       },

                       new Location()
                       {
                           XCoordinates = 44.77583 ,
                           YCoordinates = 17.18556,
                           Name = "Banjaluka"

                       },
                    });
                    context.SaveChanges();
                }

                //Hotel
                if (!context.Hotel.Any())
                {

                    context.Hotel.AddRange(new List<Hotel>()
                    {
                       new Hotel()
                       {
                            
                          LocationId = 1,
                          Name = "President",
                          Category = CategoryEnum.Hotel,
                          Description = "Hotel s 5 zvjezdica",
                          Price = 0,
                          Image = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/16/9e/96/c2/hotel-president-sarajevo.jpg?w=700&h=-1&s=1"

                       },

                       new Hotel()
                       {

                          LocationId = 2,
                          Name = "Backpackers",
                          Category = CategoryEnum.Hostel,
                          Description = "Za avanturiste",
                          Price = 0,
                          Image = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/0f/41/0a/47/hostel-backpackers-mostar.jpg?w=1200&h=-1&s=1"

                       },

                             new Hotel()
                       {

                          LocationId = 3,
                          Name = "Backpackers",
                          Category = CategoryEnum.Motel,
                          Description = "Povoljne cijene",
                          Price = 0,
                          Image = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/201903582.jpg?k=b8fcc98b3ba278d740a0628286fb9cdd3bb6fff7dc09b33525e8bf9be8dbd0ec&o=&hp=1"

                       },

                    });
                    context.SaveChanges();
                }

                //Room
                if (!context.Room.Any())
                {

                    context.Room.AddRange(new List<Room>()
                    {
                       

                             new Room()
                       {
                           AccommodationType = AccommodationEnum.Single,
                           HotelId = 1,
                        
                          BestOffer = false,
                          Description = "Rooms are equipped with: air conditioning system, LCD satellite TV, mini bar, hair dryer, safe. WiFi usage is unlimited in all rooms and free of charge. All rooms are non-smoking.\r\n\r\nOn disposal to all our guests: laundry services at surcharge; copy/print services; room service at surcharge; rent a car at surcharge; airport shuttle service at surcharge.\r\n\r\nOur professional staff is always at your service ready to fulfil any request of yours.",
                          Picture = "https://hotelpresident.ba/wp-content/uploads/2019/05/single.jpg",
                          Price = 200,


                       },


                             new Room()
                       {
                           AccommodationType = AccommodationEnum.Double,
                           HotelId =2,

                          BestOffer = false,
                          Description = "At the hostel, every room includes a balcony with a garden view. With a shared bathroom, rooms at Backpack Hostel also boast a city view. At the accommodation rooms are equipped with air conditioning and a safety deposit box.",
                          Picture = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/420777750.jpg?k=c8d2b0bdc0d08b0cab0446a0e0bea47fb3bb4d97fe82fed0904b68e03e6fda28&o=&hp=1",
                          Price = 150,


                       },

                                new Room()
                       {
                           AccommodationType = AccommodationEnum.Single,
                           HotelId =3,

                          BestOffer = false,
                          Description = "With air conditioning and views over the river, each accommodation is equipped with a satellite flat-screen TV, refrigerator and a private bathroom with a shower and free toiletries. Apartments have a kitchenette with toaster and electric kettle.",
                          Picture = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/28475407.jpg?k=23a66437e68911fa019b2a20911de004f69b59d76adce5379e7ba2beef76260c&o=&hp=1",
                          Price = 70,


                       },

                    });
                    context.SaveChanges();
                }

            }
        }
    }
}
