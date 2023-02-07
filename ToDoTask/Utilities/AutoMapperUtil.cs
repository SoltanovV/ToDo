using AutoMapper;

namespace AspBackend.Utilities;
/// <summary>
/// Класс для маппинга данных
/// </summary>
/// <typeparam name="T">Входные данные</typeparam>
/// <typeparam name="F">Выходные данные</typeparam>
public static class AutomapperUtil<T,F>
{
    public static F Map(T model)
    {
        try
        {
            // настройка конфигурации
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T, F>(MemberList.Source));
            
            // передача конфигурации
            var mapper = new Mapper(config);
            
            // маппинг данных
            var result = mapper.Map<F>(model);

            return result;
        }
        catch
        {
            throw;
        }

        
    }
}
