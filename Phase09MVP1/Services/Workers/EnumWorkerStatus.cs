namespace Phase09MVP1.Services.Workers;
public enum EnumWorkerStatus
{
    None,
    Selected,
    Working //if they are working, they can't be on another site.
}