using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuData : MonoBehaviour
{
    [SerializeField] private Text _bestScoreText;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _quitButton;

    public Text BestScore => _bestScoreText;
    public Button ContinueButton => _continueButton;
    public Button ExitButton => _quitButton;

}

