namespace Phase09MVP1.Services.Trees;
public class DefaultTreesCollected : ITreesCollecting
{
    int ITreesCollecting.TreesCollectedAtTime => 4; //usually 4 regardless of game.
}