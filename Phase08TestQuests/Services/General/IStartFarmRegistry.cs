namespace Phase08TestQuests.Services.General;
public interface IStartFarmRegistry
{
    Task<BasicList<PlayerState>> GetFarmsAsync(); 
}