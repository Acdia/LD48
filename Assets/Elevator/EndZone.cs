using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            Debug.Log("Proceed to next level!");
            GameObject go = GameObject.FindGameObjectWithTag("GameManager");

            go.GetComponent<GameManager>().NextLevel();
        }
    }
}
