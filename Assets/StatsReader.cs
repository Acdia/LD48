using UnityEngine.UI;
using UnityEngine;

public class StatsReader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        Text text = GetComponent<Text>();

        string output = "";

        for(int i = 0; i < gm.missiles.Length; i++)
        {

            output += "Level -" + i.ToString() + " : " + gm.missiles[i].ToString() + " missiles" + "\n";
        }

        text.text = output;
        
    }
    
}
