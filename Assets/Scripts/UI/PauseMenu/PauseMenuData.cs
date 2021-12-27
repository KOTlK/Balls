using UnityEngine;
using UnityEngine.UI;

public class PauseMenuData : MonoBehaviour
{
    [SerializeField] private Text _bestScoreText;
    [SerializeField] private Text _continueButtonText;
    [SerializeField] private Text _quitButtonText;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _english;
    [SerializeField] private Button _russian;

    public Text BestScore => _bestScoreText;
    public Text ContinueButtonText => _continueButtonText;
    public Text ExitButtonText => _quitButtonText;
    public Button ContinueButton => _continueButton;
    public Button ExitButton => _quitButton;
    public Button English => _english;
    public Button Russian => _russian;

}

