using UnityEngine;

public class Player_Ranged : Weapon
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    protected override void Init()
    {
        weilder = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Shoot()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }
    }
}