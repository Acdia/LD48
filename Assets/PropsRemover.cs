using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsRemover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        if(!GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().useProps)
        {

            gameObject.SetActive(false);
        }
    }
    
}
