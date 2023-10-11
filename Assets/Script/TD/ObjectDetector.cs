using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField]
    private TowerSpawn towerSpawn;

    private Camera MainCamera;
    private Ray ray;
    private RaycastHit hit;


    private void Awake()
    {
        MainCamera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            if( Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.CompareTag("Tile"))
                {
                    towerSpawn.SpawnTower(hit.transform);
                }
            }
        }
    }
}
