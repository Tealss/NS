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
        // 마우스 휠값 입력을 받음
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");

        // 카메라의 Size 값을 조절
        float newSize = mainCamera.orthographicSize - scrollWheelInput * zoomSpeed;

        // Size 값을 최소값과 최대값 사이로 제한
        mainCamera.orthographicSize = Mathf.Clamp(newSize, minSize, maxSize);
    }
}