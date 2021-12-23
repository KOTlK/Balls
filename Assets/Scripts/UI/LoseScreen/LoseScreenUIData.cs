using UnityEngine;
using UnityEngine.UI;

public class LoseScreenUIData : MonoBehaviour
{
    [SerializeField] private Text _youLose;
    [SerializeField] private Text _currentScore;
    [SerializeField] private Text _bestScore;
    [SerializeField] private Button _retry;

    public Text Lose => _youLose;
    public Text CurrentScore => _currentScore;
    public Text BestScore => _bestScore;
    public Button Retry => _retry;
    
    
}
