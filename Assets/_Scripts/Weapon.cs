using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float fireForce = 20f;
    public int currentClip, maxClip = 10, currentAmmo, maxAmmo = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void Fire() //call in player script
    {
        if (currentClip > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * fireForce, ForceMode.Impulse);
            currentClip--;
        }
        
    }

    public void Reload()
    {
        int reloadAmount = maxClip - currentClip;
        reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount : currentAmmo;
        currentClip += reloadAmount;
        currentAmmo -= reloadAmount;
    }

    public void AddAmmo(int ammoAmount)
    {
        currentAmmo += ammoAmount;
        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
    }
    /*
     if (Input.GetKeyDown(KeyCode.0) { weapon.Fire(); }
     if (Input.GetKeyDown(KeyCode.R) { weapon.Reload(); } */
}
