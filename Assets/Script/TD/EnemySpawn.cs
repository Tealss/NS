using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemyHPSliderPrefab;
    [SerializeField]
    private Transform canvasTransform;
    [SerializeField]
    private float spwanTime;
    [SerializeField]
    private Transform[] wayPoints;
    [SerializeField]
    private PlayerHP playerHP;
    private List<Enemy> enemyList;

    public List<Enemy> EnemyList => enemyList; 

    private void Awake()
    {
        enemyList = new List<Enemy>();

        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
       while (true)
        { 
            GameObject clone = Instantiate(enemyPrefab);
            Enemy enemy = clone.GetComponent<Enemy>();

            enemy.Setup(this,wayPoints);
            enemyList.Add(enemy);

            SpawnEnemyHPSlider(clone);

            yield return new WaitForSeconds(spwanTime);
        }
    }

    public void DestroyEnemy(EnemyDestroyType type, Enemy enemy)
    {
        if (type == EnemyDestroyType.Arrive)
        {
            playerHP.TakeDamage(1);
        }

        enemyList.Remove(enemy);
        Destroy(enemy.gameObject);
    }

    private void SpawnEnemyHPSlider(GameObject enemy)
    {
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab);

        // �����̴� UI�� ���� "ĵ����" ������Ʈ�� �ڽ����� ����
        // UI ĵ������ �ڽ� ������Ʈ�� �����Ǿ� �־�� ȭ�鿡 ����
        sliderClone.transform.SetParent(canvasTransform);
        sliderClone.transform.localScale = Vector3.one;

        sliderClone.GetComponent<SliderSetter>().Setup(enemy.transform);
        sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHP>());
    }


}
