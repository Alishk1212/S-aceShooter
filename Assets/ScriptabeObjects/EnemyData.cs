using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 2)]
public class EnemyData : ScriptableObject
{
    public int numberOfEnemies;
    public float spacing;        
    public float moveSpeed;
    public MovementType movementType; 

    public enum MovementType
    {
        Straight,
        Zigzag,
        Wave,
        Diagonal
    }
}
