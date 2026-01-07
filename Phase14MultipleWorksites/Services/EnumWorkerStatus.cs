namespace Phase14MultipleWorksites.Services;
public enum EnumWorkerStatus
{
    None,
    Selected,
    Working //if they are working, they can't be on another site.
}