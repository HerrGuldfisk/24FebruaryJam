using Replayer.Stats;
using UnityEngine;

public class DefaultGun : WeaponData
{
    public CharacterStat Cooldown { get; set; } = new CharacterStat(0.8f);

    public CharacterStat Damage { get; set; } = new CharacterStat(10);

    public CharacterStat ProjectileSpeed { get; set; } = new CharacterStat(12);
}
