namespace Phase02AutoresumeDatabase.Models;
public class CropInstanceDocument
{
    // All crop slots and their state
    //when starting out, the number required will actually populate the values.
    required public BasicList<CropAutoResumeModel> Slots { get; set; } = [];

    required public PlayerState Player { get; set; }
}