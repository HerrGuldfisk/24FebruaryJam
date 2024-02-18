using System.Net.Sockets;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class Firearm : MonoBehaviour
{
    Vector3 inputDirection = Vector2.zero;
    float inputMagnitude = 0f;
    PlayerStats playerStats;

    public DefaultGun DefaultGun {  get; private set; } = new DefaultGun();
    public Projectile DefaultProjectile;
    private float DefaultGunCooldown = 0;


    private void Start()
    {
        playerStats = GetComponentInParent<PlayerControllerScript>().playerStats;
    }

    public void OnLook(InputValue input)
    {
        Vector2 newInput = input.Get<Vector2>();
        inputMagnitude = newInput.magnitude;

        if(inputMagnitude > 0.1f)
        {
            inputDirection = new(newInput.x, 0, newInput.y);

            transform.rotation = Quaternion.LookRotation(inputDirection.normalized);
        }
        else
        {
            inputDirection = Vector2.zero;
        }
    }

    private void Update()
    {
        if (inputMagnitude > 0.1f && DefaultGunCooldown <= Time.time)
        {
            //Projectile projectile = Instantiate(DefaultProjectile, transform.position, transform.localRotation, null);
            Projectile projectile = ObjectPooler.DequeuObject<Projectile>("DefaultProjectile");
            projectile.transform.position = transform.position;
            projectile.transform.rotation = Quaternion.LookRotation(inputDirection.normalized);
            projectile.Damage = DefaultGun.Damage.Value;
            projectile.RB.linearVelocity = inputDirection.normalized * DefaultGun.ProjectileSpeed.Value;
            DefaultGunCooldown = Time.time + (DefaultGun.Cooldown.Value * playerStats.BaseAttackSpeed.Value);
            projectile.gameObject.SetActive(true);
        }
    }
}
