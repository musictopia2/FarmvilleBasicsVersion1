namespace Phase13SingleWorksites.Services;
public static class WorkerDefinition
{
    public static BasicList<WorkerModel> Workers =>
    [
        new WorkerModel
        {
            WorkerType = EnumWorkerType.General,
            WorkerStatus = EnumWorkerStatus.None,
            WorkerName = "Alice",
            Details = "General Worker."
        },
        new WorkerModel
        {
            WorkerType = EnumWorkerType.General,
            WorkerStatus = EnumWorkerStatus.None,
            WorkerName = "Bob",
            Details = "General Worker."
        },
        new WorkerModel
        {
            WorkerType = EnumWorkerType.Strawberries,
            WorkerStatus = EnumWorkerStatus.None,
            WorkerName = "Clara",
            Details = "Expert in picking strawberries. Guarantees one strawberry per job in grandmas glade."
        },
        new WorkerModel
        {
            WorkerType = EnumWorkerType.GranillaBar,
            WorkerStatus = EnumWorkerStatus.None,
            WorkerName = "Daniel",
            Details = "Specializes in finding Granilla Bars in gradmas glade. Has a small chance to harvest them."
        }
    ];
}