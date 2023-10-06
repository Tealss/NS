using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public GameObject[] characterPrefabs; //  Prefabs 배열
    private GameObject currentCharacter;   // 현재 캐릭
    private Vector3 previousPosition;

    private void Start()
    {
        // 캐릭터 생성
        SpawnCharacter(0);
    }

    private void SpawnCharacter(int characterIndex)
    {
        // 새로운 캐릭터 생성을 위해 캐릭 삭제
        if (currentCharacter != null)
        {
            previousPosition = currentCharacter.transform.position;
            Destroy(currentCharacter);
        }

        // 현재 캐릭값의 위치를 잡아서, 그 값(previousPosition)으로 생성함
        currentCharacter = Instantiate(characterPrefabs[characterIndex], previousPosition, Quaternion.identity);
    }

    public void ChangeCharacter(int characterIndex)
    {

        // 캐릭 변경
        SpawnCharacter(characterIndex);
    }
}
