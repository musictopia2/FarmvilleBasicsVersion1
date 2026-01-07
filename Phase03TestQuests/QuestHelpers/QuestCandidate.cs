namespace Phase03TestQuests.QuestHelpers;
internal sealed class QuestCandidate
{
    public required string ItemKey { get; set; }         // string item key (CountryItemList.Wheat, etc.)
    public required EnumQuestSourceKind SourceKind { get; set; }
    public string? ProducerId { get; set; }              // workshop/worksite/animal id/name (optional)
    //public string Main { get; set; } = ""; //useful so can do variety when it does a final shuffle (


}