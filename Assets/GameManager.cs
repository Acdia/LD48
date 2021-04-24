using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int[] levels;
    public GameObject deathUI;
    

    Impact missile;

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

        this.missile = missile;
        deathUI.SetActive(true);
    }
    

    public void ResetLevel()
    {
        missile.ResetFlight();
        deathUI.SetActive(false);
    }

    public void NextLevel()
    {


    }
}
