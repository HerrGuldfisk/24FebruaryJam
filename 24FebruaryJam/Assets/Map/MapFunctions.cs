
using UnityEngine;

public class MapFunctions : MonoBehaviour
{
    public static Vector3 GetRandomPositionOnMap()
    {
        return new Vector3(Random.Range(-20, 20f), 0, Random.Range(-10, 10f)); 
    }
}
