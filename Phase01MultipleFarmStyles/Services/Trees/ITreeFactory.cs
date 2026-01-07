namespace Phase01MultipleFarmStyles.Services.Trees;
public interface ITreeFactory
{
    TreeServicesContext GetTreeServices(string style);
}