using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class ExplosionAttack : MonoBehaviour
{
    float timeUntilExplosion = 0.8f;

    Transform explosion;

    float explosionSpeed = 10;

    bool triggered = false;

    private void Start()
    {
        timeUntilExplosion += Time.time;
        explosion = transform.GetChild(0);

        Destroy(transform.root.gameObject, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeUntilExplosion < Time.time) 
        {
            explosion.localScale += new Vector3(explosionSpeed, explosionSpeed, 1) * Time.deltaTime;
            explosionSpeed -= Time.deltaTime * 4f;
        }
    }

    public void RunOnTriggerEnter(Collider other)
    {
        Damage(other);
    }

    private void Damage(Collider other)
    {
        if (triggered) return;

        print(other.gameObject.GetComponent<PlayerControllerScript>());

        if (other.gameObject.GetComponent<PlayerControllerScript>())
        {
            print("hit2");
            triggered = true;
            other.gameObject.GetComponent<PlayerControllerScript>().TakeDamage(10f);
        }

        if(other.gameObject.GetComponent<PlayerShield>())
        {
            triggered = true;
            other.gameObject.GetComponent<PlayerShield>().TakeDamage(10);
            Destroy(transform.root.gameObject);
            print("hit3");
        }
    }
}
