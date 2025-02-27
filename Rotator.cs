using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f; // 회전 속도
    private float dir = 1f;     // 회전 방향
    private float timer = 0f;         // 시간 계산

    void Update()
    {
        // 시간 누적
        timer += Time.deltaTime;

        // 5초마다 회전 방향 반전
        if (timer >= 5f)
        {
            dir *= -1f; // 방향 반전
            timer = 0f;       // 타이머 초기화
        }
        transform.Rotate(0f, rotationSpeed*Time.deltaTime*dir, 0f);
    }
}
