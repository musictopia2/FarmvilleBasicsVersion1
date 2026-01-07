namespace Phase07Images.Services.General;
public interface IStartFarmRegistry
{
    Task<BasicList<PlayerState>> GetFarmsAsync(); 
}