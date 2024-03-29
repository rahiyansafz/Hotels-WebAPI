﻿using Hotels.Models.Dtos.Hotel;

namespace Hotels.Models.Dtos.City;

public class CityDto : BaseCityDto, IBase
{
    public int Id { get; set; }
    public IEnumerable<GetHotelDto> Hotels { get; set; }
}
