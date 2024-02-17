using UnityEngine;
using Replayer.Stats;

public class Firearm : MonoBehaviour
{
    protected CharacterStat Cooldown { get; set; } = new CharacterStat(1);

    protected CharacterStat Damage { get; set; } = new CharacterStat(10);
}
