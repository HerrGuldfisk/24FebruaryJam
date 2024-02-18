using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class ExplosionAttack : MonoBehaviour
{
    float timeUntilExplosion = 1.8f;

    Transform explosion;

    float explosionSpeed = 4;

    private void Start()
    {
        timeUntilExplosion += Time.time;
        explosion = transform.GetChild(0);

        Destroy(gameObject, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeUntilExplosion < Time.time) 
        {
            explosion.localScale += new Vector3(explosionSpeed, explosionSpeed, 1) * Time.deltaTime;
            explosionSpeed -= Time.deltaTime * 1.5f;
        }
    }

    public void RunOnTriggerEnter(Collider other)
    {
        OnTriggerEnter(other);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(TryGetComponent(out PlayerControllerScript playerController))
        {
            playerController.TakeDamage(10);
        }

        if(TryGetComponent(out PlayerShield shield))
        {
            shield.TakeDamage(10);
        }
    }
}
