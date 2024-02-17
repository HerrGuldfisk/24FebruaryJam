using Replayer.Stats;
using UnityEngine;

public interface WeaponData
{
    public CharacterStat Cooldown { get; set; }

    public CharacterStat Damage { get; set; }

    public CharacterStat ProjectileSpeed { get; set; }

}
