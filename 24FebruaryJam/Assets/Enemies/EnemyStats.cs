using UnityEngine;
using Replayer.Stats;

public class EnemyStats
{
    public CharacterStat MaxHP { get; set; } = new CharacterStat(1);
    public float CurrentHP { get; set; }
    public CharacterStat MoveSpeed { get; set; } = new CharacterStat(5);
}
