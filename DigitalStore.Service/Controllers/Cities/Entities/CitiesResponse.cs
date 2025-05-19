using DigitalStore.BL.Cities.Entities;

namespace DigitalStore.Service.Controllers.Cities.Entities;

public record CitiesResponse(List<CityModel> Cities);