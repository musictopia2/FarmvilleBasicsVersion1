namespace Phase03ConcurrentPlayerSessions.Services.Crops;
public class CropServicesContext
{
    required
    public ICropRegistry CropRegistry{ get; init; }
    required
    public ICropInstances CropInstances { get; init; }
    required
    public ICropPolicy CropPolicy { get; init; }
}