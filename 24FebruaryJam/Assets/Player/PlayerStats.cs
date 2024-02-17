using UnityEngine;
using Replayer.Stats;

public class PlayerStats : MonoBehaviour
{
    public CharacterStat MaxHP { get; set; } = new CharacterStat(1);
    public CharacterStat CurrentHP { get; set; } = new CharacterStat(1);
    public CharacterStat MoveSpeed { get; set; } = new CharacterStat(5);
}
