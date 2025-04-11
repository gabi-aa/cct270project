using System.Collections;
using UnityEngine;
using TMPro;

public class ShootData : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GunBehaviour gunData;
    [SerializeField] private Transform muzzle;
    [SerializeField] private TMP_Text prompt;

    float timeSinceLastShot;
    public int localAmmo = 10;

    public void Start()
    {
        PlayerShoot.shootinput += Shoot;
        PlayerShoot.reloadinput += StartReload;
    }

    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate) / 60f;

    public void Shoot()
    {
        if(localAmmo > 0)
        {
            if(Physics.Raycast(muzzle.position, muzzle.forward, out RaycastHit hitInfo, gunData.maxDist))
            {
                Target target = hitInfo.transform.GetComponent<Target>();
                if(target != null)
                {
                    target.TakeDamage(gunData.damage);
                }
                Exit exit = hitInfo.transform.GetComponent<Exit>();
                if (exit != null)
                {
                    exit.LeaveLevel();
                }
            }
            localAmmo -= 1;
            timeSinceLastShot = 0;
        }
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        prompt.text = "Ammo: " + localAmmo.ToString();
    }

    public void StartReload()
    {
        if (!gunData.reloading)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        gunData.reloading = true;
        yield return new WaitForSeconds(gunData.reloadTime);

        localAmmo = gunData.magSize;
        gunData.reloading = false;
    }
}
