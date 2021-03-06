using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUiHandler : MonoBehaviour
{
    [SerializeField] private Text ScoreText;
    [SerializeField] private InputField nameInputField;

    // Start is called before the first frame update
    void Start()
    {
        if (ScoreManager.Instance.highScore == 0)
        {
            ScoreText.text = "";
        }
        else
        {
            ScoreText.text = "High Score: " + ScoreManager.Instance.highScore + " (" + ScoreManager.Instance.playerName + ")";
        }
    }

    public void StartGame()
    {
        ScoreManager.Instance.currentPlayer = nameInputField.text;
        SceneManager.LoadScene(1);
    }
}
