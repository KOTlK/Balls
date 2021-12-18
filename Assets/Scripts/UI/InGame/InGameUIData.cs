using UnityEngine;
using UnityEngine.UI;

public class InGameUIData : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _hpText;
    [SerializeField] private Button _menuButton;

    public Text Score => _scoreText;
    public Text HP => _hpText;
    public Button MenuButton => _menuButton;
}