using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderSetter : MonoBehaviour
{
    [SerializeField]
    private Vector3 distance = Vector3.down * 20.0f;
    private Transform targetTransfrom;
    private RectTransform rectTransform;

    public void Setup(Transform target)
    {
        targetTransfrom = target;
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if ( targetTransfrom == null ) 
        {
            Destroy(gameObject); 
            return;
        }

        // 오브젝트의 월드 좌표를 기준으로 좌표값
        Vector3 screenPostion = Camera.main.WorldToScreenPoint( targetTransfrom.position );
        // 화면 내에 좌표 + 디스턴스 만큼 떨어진 위치값
        rectTransform.position = screenPostion + distance;

    }
}
