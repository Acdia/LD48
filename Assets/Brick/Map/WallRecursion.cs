using UnityEngine;

public class WallRecursion : MonoBehaviour
{

    public Transform[] recursor;
    public bool isInitial = false;
    [SerializeField] int lor = 15;

    [Space]

    public GameObject wall;
    public GameObject dooredWall;

    // Start is called before the first frame update
    void Start()
    {
        
        if(isInitial)
        {

            Recurse(lor);
        }
    }

    public void GetDoor()
    {

        Instantiate(dooredWall, transform.position, transform.rotation);
        DestroyImmediate(gameObject);
    }

    public void Recurse(int levelOfRecursion)
    {

        if(levelOfRecursion <= 0)
        {

            return;
        }

        GameObject newWall = Instantiate(wall, recursor[0].position, recursor[Random.Range(0, 3)].rotation);
        newWall.GetComponent<WallRecursion>().Recurse(levelOfRecursion - 1);
    }

    public GameObject PlaceWall(int direction)
    {

        return Instantiate(wall, recursor[direction].position, recursor[direction].rotation, transform.parent);
    }
}
