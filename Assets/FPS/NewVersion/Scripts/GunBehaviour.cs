using UnityEngine;

[CreateAssetMenu(fileName="Gun", menuName="Weapon/Gun")]
public class GunBehaviour : ScriptableObject
{
    [Header("Info")]
    public string name;

    [Header("Shooting")]
    public float damage;
    public float maxDist;

    [Header("Reloading")]
    public int magSize;
    public float fireRate;
    public float reloadTime;
    public bool reloading;
}
