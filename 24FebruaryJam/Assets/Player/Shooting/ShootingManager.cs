using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    public Firearm Firearm {  get; private set; }

    public void EquipFirearm(Firearm newFirearm)
    {
        Firearm = newFirearm;
    }

    
}
