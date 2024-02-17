using UnityEngine;
using Replayer.Stats;

public class SpeedUpgrade : MonoBehaviour, IUpgradeBase
{
    public void Equip(PlayerStats playerStats)
    {
        playerStats.MoveSpeed.AddModifier(new StatModifier(4, StatModType.Flat, this));
    }

    public void RemoveUpgrade(PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerControllerScript player))
        {
            Equip(player.playerStats);
            Destroy(gameObject);
        }
    }
}
