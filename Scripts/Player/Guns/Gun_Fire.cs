using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Fire : MonoBehaviour
{
    public bool canShoot = true;
    public GameObject projectilePrefab;
    public float fireRate;

    private IEnumerator turnCanShoot(float delay)
    {
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Fire1") != 0 && canShoot)
        {
            shoot();
            StartCoroutine(turnCanShoot(fireRate));
        }
        
    }
    public void shoot()
    {
        canShoot = false;
        
        GameObject projectile = Instantiate(projectilePrefab, transform.position,transform.rotation);             
    }
}
