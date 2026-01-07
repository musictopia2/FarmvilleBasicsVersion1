//namespace Phase06Autoresume.Services.Workshops;

//public static class WorkshopStateStore
//{
//    //a temporary solution until i have database access and autoresume.
//    // Key: workshop.Id, Value: selected recipe index
//    private static Dictionary<Guid, int> _selectedRecipes = new();

//    public static int GetSelectedRecipe(Guid workshopId)
//    {
//        if (_selectedRecipes.TryGetValue(workshopId, out var index))
//        {
//            return index;
//        }

//        return 0; // default to first recipe
//    }

//    public static void SetSelectedRecipe(Guid workshopId, int index)
//    {
//        _selectedRecipes[workshopId] = index;
//    }
//}
