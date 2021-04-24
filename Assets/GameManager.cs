using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int[] levels;
    public GameObject deathUI;

    // Start is called before the first frame update
    void Start()
    {

        DontDestroyOnLoad(gameObject);
    }

    public void LaunchGame()
    {

        SceneManager.LoadScene(levels[0]);
    }

    public void Die()
    {

        deathUI.SetActive(true);
    }

    public void ResetLevel()
    {

        deathUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
