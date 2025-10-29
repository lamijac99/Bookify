using System.Collections.Generic;
using ooad_grupa3_tim11.Models;

public class HomeFiltersViewModel
{
    public List<Location> Cities { get; set; }
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }
    public AccommodationEnum? AccommodationType { get; set; }
}