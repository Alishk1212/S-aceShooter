using System.Collections;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private Transform firepos;

    [SerializeField]
    private ProjectileData projectileData; 

    private Coroutine shootingCoroutine;
    private void Update()
    {
        if (shootingCoroutine == null) 
        {
            shootingCoroutine = StartCoroutine(ShootWithDelay(projectileData));
        }
    }

    public void Shoot(ProjectileData projectileData)
    {
        int numberOfProjectiles = projectileData.numberOfProjectiles;

        float angleStep = 10f;  
        float startAngle = -angleStep * (numberOfProjectiles - 1) / 2; 

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            float currentAngle = startAngle + angleStep * i;
            Quaternion rotation = Quaternion.Euler(0, 0, currentAngle);

            GameObject projectileInstance = Instantiate(projectilePrefab, firepos.position, rotation);

            Projectile projectile = projectileInstance.GetComponent<Projectile>();
            projectile.data = projectileData;
        }
    }
    private void ShootSideBySide(ProjectileData projectileData)
    {
        int numberOfProjectiles = projectileData.numberOfProjectiles;
        float spacing = 0.3f; 

        Vector3 startPosition = firepos.position - new Vector3((numberOfProjectiles - 1) * spacing / 2, 0, 0); 

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            Vector3 positionOffset = new Vector3(spacing * i, 0, 0); 
            Vector3 spawnPosition = startPosition + positionOffset;

            GameObject projectileInstance = Instantiate(projectilePrefab, spawnPosition, firepos.rotation);
            Projectile projectile = projectileInstance.GetComponent<Projectile>();
            projectile.data = projectileData;
        }
    }

    private IEnumerator ShootWithDelay(ProjectileData projectileData)
    {
        while (true)
        {
            switch (projectileData.shootingMode)
            {
                case ProjectileData.ShootingMode.Angled:
                    Shoot(projectileData);
                    break;

                case ProjectileData.ShootingMode.SideBySide:
                    ShootSideBySide(projectileData);
                    break;
            }

            yield return new WaitForSeconds(projectileData.fireRate);
        }
    }


}
