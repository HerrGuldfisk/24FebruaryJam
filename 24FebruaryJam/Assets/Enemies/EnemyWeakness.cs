using UnityEngine;

public class EnemyWeakness : MonoBehaviour
{
    public EnemyController Enemy;

    private void Awake()
    {
        Enemy = GetComponentInParent<EnemyController>();
    }
}
