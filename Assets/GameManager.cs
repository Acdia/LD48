using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int endScene;
    public int[] levels;
    public GameObject deathUI;
    public GameObject nextLevelUI;
    public Text nextLevelText;

    public int[] missiles;

    Impact missile;

    int currentLevel = 0;
    bool winning = false;

    int lastLevel = 5;

    //Settings

    public bool useProps;
    public bool autoRoll = true;
    public float volume = 1f;

    // Start is called before the first frame update
    void Start()
    {

        DontDestroyOnLoad(gameObject);
        missiles = new int[levels.Length];
    }

    //Settings
    public void SetUseProps(bool value)
    {

        useProps = value;
    }

    public void SetAutoRoll(bool value)
    {

        autoRoll = value;
    }

    public void SetVolume(float value)
    {

        volume = value;
        AudioListener.volume = value;
    }




    public void LaunchGame()
    {

        SceneManager.LoadScene(levels[0]);
    }

    public void Die(Impact missile)
    {
        
        if(!winning)
        {

            missiles[currentLevel]++;
            this.missile = missile;
            deathUI.SetActive(true);
        }

        winning = true;
    }
    

    public void ResetLevel()
    {
        missile.ResetFlight();
        deathUI.SetActive(false);
        winning = false;
    }

    public void NextLevel()
    {

        if(currentLevel == lastLevel)
        {

            missiles[currentLevel]++;
            winning = true;
            Win();
            return;
        }

        missiles[currentLevel]++;
        nextLevelText.text = "Level -" + currentLevel.ToString() + " completed with " + missiles[currentLevel] + " missiles";
        nextLevelUI.SetActive(true);
        winning = true;
    }

    void Win()
    {

        SceneManager.LoadScene(endScene);
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
        currentLevel++;
    }

    public void RestartThisLevel()
    {

        missiles[currentLevel] = 0;
        SceneManager.LoadScene(levels[currentLevel]);
        nextLevelUI.SetActive(false);
        winning = false;

    }
}
