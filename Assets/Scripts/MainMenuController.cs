using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    //[SerializeField] AudioClip _startingSong;
    [SerializeField] Text _highScoreTextView;

    int highScore = 0;

    private void Start()
    {
        //load high score display
        highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();

        /*if(_startingSong != null)
        {
            AudioManager.Instance.PlaySong(_startingSong);
        }*/
    }

    public void ResetData()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
