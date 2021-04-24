using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int[] levels;
    public GameObject deathUI;
    public GameObject nextLevelUI;
    

    Impact missile;

    int currentLevel = 0;
    bool winning = false;

    // Start is called before the first frame update
    void Start()
    {

        DontDestroyOnLoad(gameObject);
    }

    public void LaunchGame()
    {

        SceneManager.LoadScene(levels[0]);
    }

    public void Die(Impact missile)
    {

        if(!winning)
        {

            this.missile = missile;
            deathUI.SetActive(true);
        }
    }
    

    public void ResetLevel()
    {
        missile.ResetFlight();
        deathUI.SetActive(false);
    }

    public void NextLevel()
    {

        nextLevelUI.SetActive(true);
        winning = true;
    }

    public void EnterNextLevel()
    {

        if(levels.Length <= currentLevel + 1)
        {

            Debug.Log("Game has ended. No more levels!");
            return;
        }

        SceneManager.LoadScene(levels[currentLevel + 1]);
        nextLevelUI.SetActive(false);
        winning = false;
    }

    public void RestartThisLevel()
    {

        SceneManager.LoadScene(levels[currentLevel]);
        nextLevelUI.SetActive(false);
        winning = false;

    }
}
