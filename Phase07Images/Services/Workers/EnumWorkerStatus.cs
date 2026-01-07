namespace Phase07Images.Services.Workers;
public enum EnumWorkerStatus
{
    None,
    Selected,
    Working //if they are working, they can't be on another site.
}