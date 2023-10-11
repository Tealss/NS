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

        // ������Ʈ�� ���� ��ǥ�� �������� ��ǥ��
        Vector3 screenPostion = Camera.main.WorldToScreenPoint( targetTransfrom.position );
        // ȭ�� ���� ��ǥ + ���Ͻ� ��ŭ ������ ��ġ��
        rectTransform.position = screenPostion + distance;

    }
}
