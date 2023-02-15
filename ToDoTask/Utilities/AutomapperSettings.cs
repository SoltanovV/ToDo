using AutoMapper;
using AspBackend.Models.Entity;
using AspBackend.Models.Entity.Request;
using AspBackend.Models.Entity.Responce;

namespace AspBackend.Utilities
{
    public class AutomapperSettings: Profile
    {
        /// <summary>
        /// Метод для сопоставления типов при маппинге
        /// </summary>
        /// <returns>Настройки маппинга</returns>
        public static  MapperConfiguration RegisterMaps()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {

                config.CreateMap<UserRequest, User>().ReverseMap();
                config.CreateMap<UserResponce, User>().ReverseMap();

                //config.CreateMap<CreatePersonResponce, Person>();
                //config.CreateMap<Person, CreatePersonResponce>();

                //config.CreateMap<SearchPersonRequest, Person>();
                //config.CreateMap<Person, SearchPersonRequest>();

                //config.CreateMap<SearchPersonResponce, Person>();
                //config.CreateMap<Person, SearchPersonResponce>();
            });

            return mapperConfig;
        }
    }
}
