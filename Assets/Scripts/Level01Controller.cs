using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text _currentScoreTextView;
    [SerializeField] GameObject _panalToView;
    [SerializeField] GameObject _deathScreen;

    int _currentScore;

    private void Start()
    {
        _panalToView.SetActive(false);
        _deathScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //Increase Score
        //TODO replace with real implementation later
        if(Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseScore(5);
        }

        //Exit Level
        //TODO bring up popup menu for navigation
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
            //_panalToView.SetActive(true);
            Resume();
        }

        
    }

    public void Resume()
    {
        bool currentIsActive = _panalToView.activeSelf;
        _panalToView.SetActive(!currentIsActive);

        Cursor.visible = !currentIsActive;

        if (!currentIsActive)
        {
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("Lock None");
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("Lock Locked");
        }
    }

    public void setCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ExitLevel()
    {
        //compare score to high score
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (_currentScore > highScore)
        {
            //save current score as new high score
            PlayerPrefs.SetInt("HighScore", _currentScore);
            Debug.Log("New high score: " + _currentScore);
        }

        //load new level
        SceneManager.LoadScene("MainMenu");
    }

    public void deathMenu()
    {
        _deathScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Restart()
    {
        int activeSceneIndex =
                SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }

    public void IncreaseScore(int scoreIncrease)
    {
        //increase score
        _currentScore += scoreIncrease;
        //update scroe display, so we can see the new score
        _currentScoreTextView.text =
            "Score: " + _currentScore.ToString();
    }
}
