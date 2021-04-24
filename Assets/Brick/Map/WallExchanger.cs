using UnityEngine;

public class WallExchanger : MonoBehaviour
{

    [SerializeField] GameObject realWall;

    public void ExchangeWall()
    {

        Instantiate(realWall, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
