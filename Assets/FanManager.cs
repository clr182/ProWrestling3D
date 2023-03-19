using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanManager : MonoBehaviour
{
    public GameObject fanPrefab;
    List<GameObject> fans = new List<GameObject>();
    float speed = 4;
    float height = 1f;

    private void Start()
    {
        for (var i = 0; i <11; i++)
        {
            fans.Add(Instantiate(fanPrefab, new Vector3( -20 + (4f * i), 1.26f, 19.3f), Quaternion.Euler(new Vector3(-75, 0, 0))) as GameObject);
        }
    }


    private void FixedUpdate()
    {
        float randSpeed = Random.Range(0, 4);
        float randHeight = Random.Range(0.0f, 1.0f);
        float sinwave = Mathf.Sin(Time.deltaTime * randSpeed) * randHeight;

        foreach( GameObject fan in fans)
        {
            fan.transform.position = new Vector3(fan.transform.position.x, sinwave, fan.transform.position.z);
        }
    }
}
