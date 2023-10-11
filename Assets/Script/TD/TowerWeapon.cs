using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public enum WeaponState { SearchTarget = 0, AttackToTarget}
public class TowerWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectileprefab;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float attackRate = 0.5f;
    [SerializeField]
    private float attackRange = 2.0f;
    private WeaponState weaponState = WeaponState.SearchTarget;
    private Transform attackTarget = null;
    private EnemySpawn enemySpawn;

    public void Setup(EnemySpawn enemySpawn)
    {
        this.enemySpawn = enemySpawn;
        ChangeState(WeaponState.SearchTarget);
    }

    public void ChangeState(WeaponState newState)
    {
        StopCoroutine(weaponState.ToString());
        weaponState = newState;
        StartCoroutine(weaponState.ToString());
    }

    private void Update()
    {
        if( attackTarget != null)
        {
            RotateToTarget();
        }
    }

    private void RotateToTarget()
    {
        float dx = attackTarget.position.x - spawnPoint.position.x;
        float dy = attackTarget.position.y - spawnPoint.position.y;

        float degree = Mathf.Atan2(dy,dx) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,degree);
    }

    private IEnumerator SearchTarget()
    {
        while (true)
        {
            float closesDistSqr = Mathf.Infinity;
            for ( int i = 0; i < enemySpawn.EnemyList.Count; i++ )
            {
                float distance = Vector3.Distance(enemySpawn.EnemyList[i].transform.position, transform.position);
                if ( distance <= attackRange && distance <= closesDistSqr)
                {
                    closesDistSqr = distance;
                    attackTarget = enemySpawn.EnemyList[i].transform;
                }

            }

            if ( attackTarget != null )
            {
                ChangeState(WeaponState.AttackToTarget);
            }

            yield return null; 
        }
    }

    private IEnumerator AttackToTarget()
    {
        while(true)
        {
            // Ÿ���� �ִ��� �˻�
            if ( attackTarget == null)
            {
                ChangeState(WeaponState.SearchTarget);
                break;
            }

            // Ÿ���� ���� �����ȿ� �ִ��� �˻�
            float distance = Vector3.Distance(attackTarget.position, transform.position);
            if ( distance > attackRange)
            {
                attackTarget = null;
                ChangeState(WeaponState.SearchTarget);
                break;
            }

            // ���÷���Ʈ �ð���ŭ ���
            yield return new WaitForSeconds(attackRate);
            // ����
            SpawnProjectile();
        }
    }

    private void SpawnProjectile()
    {
        Instantiate(projectileprefab, spawnPoint.position, Quaternion.identity);
    }
}
