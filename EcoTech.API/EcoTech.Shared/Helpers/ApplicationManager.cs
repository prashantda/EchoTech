
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace EcoTech.Shared.Helpers;

public interface IApplicationManager
{
     ApplicationSettings AppSettings { get; }
    string GetConnectionString(string dbName = default!);
}
public class ApplicationManager:IApplicationManager
{
    public  ApplicationSettings AppSettings { get; }
    private readonly IConfiguration _configuration;
    private readonly IMemoryCache _memoryCache;

    public ApplicationManager(IOptions<ApplicationSettings> appSettings, IConfiguration configuration
        , IMemoryCache memoryCache)
    {
        AppSettings = appSettings.Value;
        _configuration = configuration;
        _memoryCache = memoryCache;
    }

    public string GetConnectionString(string dbName=default!)
    {
        dbName = dbName ?? AppConstants.EcoTechDataBase;
        return AppSettings.ConnectionStrings.EcoTech;
    }
}
