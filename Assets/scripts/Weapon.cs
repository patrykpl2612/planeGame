using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Button shotButton;
    private bool shooting;
    public float fireRate = 0.2f;
    private float nextFire = 0.0f;

    public bool shootingAllowed = true;

    public int ammo;
    public int maxAmmo;
    public GameObject ammoBar;
    public float reloadTime;

    private bool reloading = false;

    void Start()
    {
        //Button btn = shotButton.GetComponent<Button>();
        //btn.OnPointerDown.AddListener(Shoot);
    }

    public void OnPress()
    {
        shooting = true;
    }

    public void OnRelase()
    {
        shooting = false;
    }

    void Update()
    {
        ammoBar.transform.localScale = new Vector3((float)ammo / (float)maxAmmo, 1, 1);
        if (ammo <= 0) StartCoroutine(Reloading());
        if (shooting && !reloading) Shoot();
    }

    IEnumerator Reloading()
    {
        reloading = true;
        yield return new WaitForSeconds(0.5f);
        ammo = maxAmmo / 6;
        ammoBar.transform.localScale = new Vector3(ammo / maxAmmo, 1, 1);
        yield return new WaitForSeconds(0.5f);
        ammo = 2 * maxAmmo / 6;
        ammoBar.transform.localScale = new Vector3(ammo / maxAmmo, 1, 1);
        yield return new WaitForSeconds(0.5f);
        ammo = 3 * maxAmmo / 6;
        ammoBar.transform.localScale = new Vector3(ammo / maxAmmo, 1, 1);
        yield return new WaitForSeconds(0.5f);
        ammo = 4 * maxAmmo / 6;
        ammoBar.transform.localScale = new Vector3(ammo / maxAmmo, 1, 1);
        yield return new WaitForSeconds(0.5f);
        ammo = 5 * maxAmmo / 6;
        ammoBar.transform.localScale = new Vector3(ammo / maxAmmo, 1, 1);
        yield return new WaitForSeconds(0.5f);
        ammo = maxAmmo;
        ammoBar.transform.localScale = new Vector3(ammo / maxAmmo, 1, 1);
        reloading = false;
    }

    void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            ammo--;
        }
    }
}
