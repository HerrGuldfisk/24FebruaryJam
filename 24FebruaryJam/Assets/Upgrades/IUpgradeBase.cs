using UnityEngine;

public interface IUpgradeBase
{
    public void Equip(PlayerStats playerStats);

    public void RemoveUpgrade(PlayerStats playerStats);
}
