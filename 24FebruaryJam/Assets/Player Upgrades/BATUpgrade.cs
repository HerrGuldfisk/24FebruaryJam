using UnityEngine;
using Replayer.Stats;

public class BATUpgrade : MonoBehaviour, IUpgradeBase
{
    public void Equip(PlayerStats playerStats)
    {
        playerStats.BaseAttackSpeed.AddModifier(new StatModifier(-0.5f, StatModType.PercentAdd, this));
    }

    public void RemoveUpgrade(PlayerStats playerStats)
    {
        playerStats.BaseAttackSpeed.RemoveAllModifiersFromSource(this);
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
