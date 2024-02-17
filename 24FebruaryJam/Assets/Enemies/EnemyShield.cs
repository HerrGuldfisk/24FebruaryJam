using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Contact");
        Destroy(this.gameObject);
    }
}
