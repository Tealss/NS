using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyDestroyType { Kill = 0, Arrive}
public class Enemy : MonoBehaviour
{
    private int wayPointCount;
    private Transform[] wayPoints;
    private int currentIndex = 0;
    private MovementTD MovementTD;
    private EnemySpawn enemySpawn;

    
    public void Setup(EnemySpawn enemyspawn, Transform[] wayPoints)
    {
        MovementTD = GetComponent<MovementTD>();
        this.enemySpawn = enemyspawn;

        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        transform.position = wayPoints[currentIndex].position;

        StartCoroutine("OnMove");
    }

    private IEnumerator OnMove()
    {
        NextMoveTo();

        while (true)
        {
            transform.Rotate(Vector3.forward * 10);

            if (Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02f * MovementTD.MoveSpeed)
            {
                NextMoveTo();
            }

            yield return null;

        }
    }

    private void NextMoveTo()
    {
        if ( currentIndex < wayPointCount - 1)
        {
            transform.position = wayPoints[currentIndex].position;

            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            MovementTD.MoveTo(direction);
        }
        else
        {
            //Destroy(gameObject);
            Ondie(EnemyDestroyType.Arrive);
        }
    }

    public void Ondie(EnemyDestroyType type)
    {
        enemySpawn.DestroyEnemy(type, this);
    }
}
