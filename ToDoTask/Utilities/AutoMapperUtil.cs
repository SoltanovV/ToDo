using AutoMapper;

namespace AspBackend.Utilities
{
    public static class AutomapperUtil<T,F>
    {
        public static F Map(T model)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<T, F>(MemberList.Source)/*IgnoreAllSourcePropertiesWithAnInaccessibleSetter()*/);
                var mapper = new Mapper(config);
                var result = mapper.Map<F>(model);

                return result;
            }
            catch(Exception ex)
            {
                throw;
            }

            
        }
    }
}
