namespace Phase02AutoresumeDatabase.Models;
public class InventoryDocument
{
    required
    public PlayerState Player
    { get; set; }
    public Dictionary<string, int> List { get; set; } = [];
}