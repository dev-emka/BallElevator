using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    GameObject child1, child2;
    public static int level;
    float speed =1;
    public static float distance;
    void Start()
    {
        distance = 7f;
        level = 1;
        child1=transform.GetChild(0).gameObject;
        child2=transform.GetChild(1).gameObject;
    }

    
    void Update()
    {
        transform.position += Vector3.left * speed*Time.deltaTime;
        SetPos(distance);
    }

    void SetPos(float pos)
    {
        child1.transform.position = new Vector2(child1.transform.position.x, pos*-1);
        child2.transform.position = new Vector2(child2.transform.position.x, pos);

    }
}
