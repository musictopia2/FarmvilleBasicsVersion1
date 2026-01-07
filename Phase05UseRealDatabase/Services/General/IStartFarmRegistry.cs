namespace Phase05UseRealDatabase.Services.General;
public interface IStartFarmRegistry
{
    Task<BasicList<PlayerState>> GetFarmsAsync(); 
}