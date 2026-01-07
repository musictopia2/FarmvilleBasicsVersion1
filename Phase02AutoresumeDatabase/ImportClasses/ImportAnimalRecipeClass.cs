namespace Phase02AutoresumeDatabase.ImportClasses;
public static class ImportAnimalRecipeClass
{
    public static async Task ImportAnimalsAsync()
    {
        BasicList<AnimalRecipeDocument> list = [];
        list.AddRange(GetCountryStandardRecipes());
        list.AddRange(GetCountryTestRecipes());
        list.AddRange(GetTropicalStandardRecipes());
        list.AddRange(GetTropicalTestRecipes());
        AnimalRecipeDatabase db = new();
        await db.ImportAsync(list);
    }
    private static BasicList<AnimalRecipeDocument> GetCountryStandardRecipes()
    {
        string theme = FarmThemeList.Country;
        string mode = SessionModeList.SampleProduction;
        BasicList<AnimalRecipeDocument> output = [];
        BasicList<AnimalProductionOption> options = [];
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(1),
            Input = 3,
            Output = new(CountryItemList.Milk, 1),
            Required = CountryItemList.Wheat
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(20),
            Input = 9,
            Output = new(CountryItemList.Milk, 3),
            Required = CountryItemList.Wheat
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromHours(1),
            Input = 15,
            Output = new(CountryItemList.Milk, 5),
            Required = CountryItemList.Wheat
        });
        AnimalRecipeDocument recipe = new()
        {
            Animal = CountryAnimalListClass.Cow,
            Options = options,
            Theme = theme,
            Mode = mode
        };
        output.Add(recipe);
        options = [];
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(3),
            Input = 2,
            Output = new(CountryItemList.GoatMilk, 2),
            Required = CountryItemList.Carrot
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(30),
            Input = 4,
            Output = new(CountryItemList.GoatMilk, 4),
            Required = CountryItemList.Carrot
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(80),
            Input = 6,
            Output = new(CountryItemList.GoatMilk, 6),
            Required = CountryItemList.Carrot
        });
        recipe = new()
        {
            Animal = CountryAnimalListClass.Goat,
            Options = options,
            Theme = theme,
            Mode = mode
        };
        output.Add(recipe);

        options = [];
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(30),
            Input = 4,
            Output = new(CountryItemList.Wool, 3),
            Required = CountryItemList.Tomato
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromHours(2),
            Input = 4,
            Output = new(CountryItemList.Wool, 6),
            Required = CountryItemList.Tomato
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromHours(3.5),
            Input = 6,
            Output = new(CountryItemList.Wool, 9),
            Required = CountryItemList.Tomato
        });
        recipe = new()
        {
            Animal = CountryAnimalListClass.Sheep,
            Options = options,
            Theme = theme,
            Mode = mode
        };
        output.Add(recipe);


        return output;
    }
    private static BasicList<AnimalRecipeDocument> GetCountryTestRecipes()
    {
        string theme = FarmThemeList.Country;
        string mode = SessionModeList.SimpleTesting;
        BasicList<AnimalRecipeDocument> output = [];
        BasicList<AnimalProductionOption> options = [];
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromSeconds(2),
            Input = 1,
            Output = new(CountryItemList.Milk, 1),
            Required = CountryItemList.Wheat
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromSeconds(5),
            Input = 3,
            Output = new(CountryItemList.Milk, 3),
            Required = CountryItemList.Wheat
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromSeconds(30),
            Input = 5,
            Output = new(CountryItemList.Milk, 5),
            Required = CountryItemList.Wheat
        });
        AnimalRecipeDocument recipe = new()
        {
            Animal = CountryAnimalListClass.Cow,
            Options = options,
            Theme = theme,
            Mode = mode
        };
        output.Add(recipe);
        options = [];
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(10),
            Input = 2,
            Output = new(CountryItemList.GoatMilk, 2),
            Required = CountryItemList.Carrot
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromSeconds(50),
            Input = 4,
            Output = new(CountryItemList.GoatMilk, 4),
            Required = CountryItemList.Carrot
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(3),
            Input = 6,
            Output = new(CountryItemList.GoatMilk, 6),
            Required = CountryItemList.Carrot
        });
        recipe = new()
        {
            Animal = CountryAnimalListClass.Goat,
            Options = options,
            Theme = theme,
            Mode = mode
        };
        output.Add(recipe);

        options = [];
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(1),
            Input = 4,
            Output = new(CountryItemList.Wool, 3),
            Required = CountryItemList.Tomato
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(5),
            Input = 4,
            Output = new(CountryItemList.Wool, 6),
            Required = CountryItemList.Tomato
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(10),
            Input = 6,
            Output = new(CountryItemList.Wool, 9),
            Required = CountryItemList.Tomato
        });
        recipe = new()
        {
            Animal = CountryAnimalListClass.Sheep,
            Options = options,
            Theme = theme,
            Mode = mode
        };
        output.Add(recipe);

        return output;
    }
    private static BasicList<AnimalRecipeDocument> GetTropicalStandardRecipes()
    {
        string theme = FarmThemeList.Tropical;
        string mode = SessionModeList.SampleProduction;
        BasicList<AnimalRecipeDocument> output = [];
        BasicList<AnimalProductionOption> options = [];
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(1),
            Input = 1,
            Output = new(TropicalItemList.Fish, 2),
            Required = TropicalItemList.Pineapple
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(20),
            Input = 3,
            Output = new(TropicalItemList.Fish, 4),
            Required = TropicalItemList.Pineapple
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromHours(1),
            Input = 3,
            Output = new(TropicalItemList.Fish, 6),
            Required = TropicalItemList.Pineapple
        });
        AnimalRecipeDocument recipe = new()
        {
            Animal = TropicalAnimalListClass.Dolphin,
            Options = options,
            Theme = theme,
            Mode = mode
        };
        output.Add(recipe);

        options = [];
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(2),
            Input = 2,
            Output = new(TropicalItemList.Egg, 1),
            Required = TropicalItemList.Rice
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(30),
            Input = 6,
            Output = new(TropicalItemList.Egg, 3),
            Required = TropicalItemList.Rice
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromHours(2),
            Input = 10,
            Output = new(TropicalItemList.Egg, 5),
            Required = TropicalItemList.Rice
        });
        recipe = new()
        {
            Animal = TropicalAnimalListClass.Chicken,
            Options = options,
            Theme = theme,
            Mode = mode
        };
        output.Add(recipe);

        options = [];
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(3),
            Input = 2,
            Output = new(TropicalItemList.Mushroom, 1),
            Required = TropicalItemList.Tapioca
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromHours(1),
            Input = 6,
            Output = new(TropicalItemList.Mushroom, 3),
            Required = TropicalItemList.Tapioca
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromHours(3),
            Input = 10,
            Output = new(TropicalItemList.Mushroom, 5),
            Required = TropicalItemList.Tapioca
        });
        recipe = new()
        {
            Animal = TropicalAnimalListClass.Boar,
            Options = options,
            Theme = theme,
            Mode = mode
        };
        output.Add(recipe);

        return output;

    }

    private static BasicList<AnimalRecipeDocument> GetTropicalTestRecipes()
    {
        string theme = FarmThemeList.Tropical;
        string mode = SessionModeList.SimpleTesting;
        BasicList<AnimalRecipeDocument> output = [];
        BasicList<AnimalProductionOption> options = [];
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromSeconds(2),
            Input = 1,
            Output = new(TropicalItemList.Fish, 2),
            Required = TropicalItemList.Pineapple
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromSeconds(10),
            Input = 3,
            Output = new(TropicalItemList.Fish, 4),
            Required = TropicalItemList.Pineapple
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromSeconds(20),
            Input = 3,
            Output = new(TropicalItemList.Fish, 6),
            Required = TropicalItemList.Pineapple
        });
        AnimalRecipeDocument recipe = new()
        {
            Animal = TropicalAnimalListClass.Dolphin,
            Options = options,
            Theme = theme,
            Mode = mode
        };
        output.Add(recipe);

        options = [];
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromSeconds(3),
            Input = 2,
            Output = new(TropicalItemList.Egg, 1),
            Required = TropicalItemList.Rice
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromSeconds(20),
            Input = 6,
            Output = new(TropicalItemList.Egg, 3),
            Required = TropicalItemList.Rice
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(1),
            Input = 10,
            Output = new(TropicalItemList.Egg, 5),
            Required = TropicalItemList.Rice
        });
        recipe = new()
        {
            Animal = TropicalAnimalListClass.Chicken,
            Options = options,
            Theme = theme,
            Mode = mode
        };
        output.Add(recipe);

        options = [];
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromSeconds(4),
            Input = 2,
            Output = new(TropicalItemList.Mushroom, 1),
            Required = TropicalItemList.Tapioca
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromSeconds(40),
            Input = 6,
            Output = new(TropicalItemList.Mushroom, 3),
            Required = TropicalItemList.Tapioca
        });
        options.Add(new AnimalProductionOption
        {
            Duration = TimeSpan.FromMinutes(2),
            Input = 10,
            Output = new(TropicalItemList.Mushroom, 5),
            Required = TropicalItemList.Tapioca
        });
        recipe = new()
        {
            Animal = TropicalAnimalListClass.Boar,
            Options = options,
            Theme = theme,
            Mode = mode
        };
        output.Add(recipe);
        return output;
    }
}