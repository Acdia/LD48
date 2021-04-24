using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    [SerializeField] GameManager gm;

    public void NewMissile()
    {
        

        gm.ResetLevel();
    }

}
