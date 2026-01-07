namespace Phase02SinglePlayerFarmThemesPlayersModes.Services.Workers;
public enum EnumWorkerStatus
{
    None,
    Selected,
    Working //if they are working, they can't be on another site.
}