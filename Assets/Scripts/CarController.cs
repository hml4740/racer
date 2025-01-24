using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private int gas = 100;
    [SerializeField] private float moveSpeed = -1f;

    public int Gas {get => gas;}

    private void Start()
    {
        StartCoroutine(GasCoroutine());
    }

    IEnumerable GasCoroutine()
    {
        while (true)
        {
            gas -= 10;
            if (gas <= 0) 
                yield return new WaitForSeconds(1f);
        }
    }

    public void Move(float direction)
    {
        transform.Translate(Vector3.right * direction);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2f, 2f), 0, transform.position.z);
    }

    // <summary>
    // 가스 아이템 획득시 호출되는 메서드
    // </summary>
    // <param name="other></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gas"))
        {
            gas += 30;
            
            //TODD: 가스 아이템 제거
            
            
        }
    }
}
