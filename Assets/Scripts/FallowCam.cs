using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FallowCam : MonoBehaviour
{
    public Transform target;
    public float speed;
    BallController ballController;
    void Start()
    {
        ballController=GameObject.FindObjectOfType<BallController>();
    }

    void Update()
    {
    }
    public void Fallow() {
        
        
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);

    }
}
