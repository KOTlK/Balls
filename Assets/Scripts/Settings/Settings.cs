using UnityEngine;

[CreateAssetMenu(fileName = "NewSettings", menuName = "Settings")]
public class Settings : ScriptableObject
{
    [SerializeField] private int _timeBeforeDifficultyIncrease;
    [SerializeField] private int _maximumBallsAmount;
    [SerializeField] private int _maximumBallsOnScreen;
    [SerializeField] private int _spawnOffsetX;
    [SerializeField] private int _spawnOffsetY;


    public int TimeBeforeDifficultyIncrease => _timeBeforeDifficultyIncrease;
    public int MaxBallsAmount => _maximumBallsAmount;
    public int MaxBallsOnScreen => _maximumBallsOnScreen;
    public int SpawnOffsetX => _spawnOffsetX;
    public int SpawnOffsetY => _spawnOffsetY;
}
