using System.Net.Sockets;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class Firearm : MonoBehaviour
{
    Vector2 inputDirection = Vector2.zero;

    public DefaultGun DefaultGun {  get; private set; } = new DefaultGun();
    public Projectile DefaultProjectile;
    private float DefaultGunCooldown = 0;
    
    public void OnLook(InputValue input)
    {
        Vector2 newInput = input.Get<Vector2>();

        if(newInput.magnitude > 0.1f)
        {
            inputDirection = input.Get<Vector2>();

            Vector3 lookDirection = new (inputDirection.x, 1, inputDirection.y);

            transform.rotation = Quaternion.LookRotation(lookDirection.normalized);
        }
    }

    private void Update()
    {
        if(DefaultGunCooldown > 0)
        {
            DefaultGunCooldown -= Time.deltaTime;
        }

        if (inputDirection.magnitude > 0.1f && DefaultGunCooldown <= 0)
        {
            Projectile projectile = Instantiate(DefaultProjectile, transform.position, Quaternion.identity, transform.root);
            projectile.Damage = DefaultGun.Damage.Value;
            projectile.RB.linearVelocity = transform.forward * DefaultGun.ProjectileSpeed.Value;

            DefaultGunCooldown = DefaultGun.Cooldown.Value;
        }
    }
}
