namespace Phase06Autoresume.Services.General;
public interface IStartFarmRegistry
{
    Task<BasicList<PlayerState>> GetFarmsAsync(); 
}