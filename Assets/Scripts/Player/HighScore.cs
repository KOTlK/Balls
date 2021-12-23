using UnityEngine;

public class HighScore
{
    private const string KeyName = "Score";

    public void TrySave(int score)
    {
        if (PlayerPrefs.HasKey(KeyName))
        {
            if (PlayerPrefs.GetInt(KeyName) >= score)
            {
                return;
            }
        }
        PlayerPrefs.SetInt(KeyName, score);
    }

    public int TryLoad()
    {
        if (PlayerPrefs.HasKey(KeyName))
        {
            return PlayerPrefs.GetInt(KeyName);
        }
        else
        {
            return 0;
        }
    }
}
