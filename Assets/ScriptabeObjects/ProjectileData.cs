using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "ScriptableObjects/ProjectileData", order = 1)]
public class ProjectileData : ScriptableObject
{
    public string projectileName; 
    public int damage;             
    public float speed;            
    public int numberOfProjectiles; 
    public float fireRate;   

    public ShootingMode shootingMode;

    public enum ShootingMode
    {
        Angled,
        SideBySide
    }
}

