using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PointView : MonoBehaviour
{
    public float zoomSpeed = 1.0f;
    public float minSize = 5.0f;
    public float maxSize = 12.0f;

    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // ���콺 �ٰ� �Է��� ����
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");

        // ī�޶��� Size ���� ����
        float newSize = mainCamera.orthographicSize - scrollWheelInput * zoomSpeed;

        // Size ���� �ּҰ��� �ִ밪 ���̷� ����
        mainCamera.orthographicSize = Mathf.Clamp(newSize, minSize, maxSize);
    }
}