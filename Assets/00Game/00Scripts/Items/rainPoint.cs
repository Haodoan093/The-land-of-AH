using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainPoint : MonoBehaviour
{
    public List<Transform> enemiesInRange = new List<Transform>();

    private bool _hasTarget = false;
    public bool HasTarget { 
      get { return _hasTarget; }
        set { _hasTarget = value; }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Enemy") || other.CompareTag("Boss"))
        {
           
            enemiesInRange.Add(other.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Boss"))
        {
            enemiesInRange.Remove(other.transform);
        }
    }

    private void Update()
    {
       if(enemiesInRange.Count > 0)
        {
            HasTarget=true;
        }
        else
        {
            HasTarget = false;
        }
        
    }

    // Hàm này trả về vị trí của enemy/boss gần nhất
    public Vector2 GetClosestEnemyPosition()
    {
        if (enemiesInRange.Count == 0)
        {
            return Vector2.zero; // Trả về giá trị mặc định nếu không có enemy nào trong phạm vi
        }

        Vector2 closestEnemyPosition = Vector2.zero;
        float closestDistance = float.MaxValue;

        foreach (Transform enemy in enemiesInRange)
        {
            float distance = Vector2.Distance(transform.position, enemy.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemyPosition = (Vector2)enemy.position;
            }
        }

        return closestEnemyPosition;
    }
}
