using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class BallController : MonoBehaviour
{
    [Header("Line")]
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float launchForce = 1.5f;
    [SerializeField] float trajectoryTimeStep = 0.05f;
    [SerializeField] int trajectoryStepCount = 15;

    [Header("Game")]
    Vector2 velocity, startTouch, currentTouchPos;
    Rigidbody2D rb;
    SpawnerManager spawner;
    FallowCam fallowCam;
    private void Start()
    {
        fallowCam=GameObject.FindObjectOfType<FallowCam>();
        spawner=GameObject.FindObjectOfType<SpawnerManager>();
        rb=GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        TouchControl();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="levelup")
        {
            ElevatorController.level++;
            if (ElevatorController.distance > 6)
            {
                ElevatorController.distance -= 0.1f;
            }else
                ElevatorController.distance = 6;
            
            
            collision.gameObject.transform.DOScale(0, 1.4f).SetEase(Ease.InBack).OnComplete(() =>
            {
                Destroy(collision.gameObject);
                rb.velocity = new Vector2(0, 0);
                fallowCam.Invoke("Fallow",1);
            });
           
        }
    }
    private void TouchControl()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTouch = Camera.main.ScreenToWorldPoint(touch.position);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                currentTouchPos = Camera.main.ScreenToWorldPoint(touch.position);
                velocity = (startTouch - currentTouchPos) * launchForce;
                DrawTrajectory();
                RotateBow();
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Fire();
                lineRenderer.positionCount = 0;
            }
        }
    }
    void DrawTrajectory()
    {
        Vector3[] positions = new Vector3[trajectoryStepCount];
        for (int i = 0; i < trajectoryStepCount; i++)
        {
            float t = i * trajectoryTimeStep;
            Vector3 pos = (Vector2)transform.position + velocity * t + 0.5f * Physics2D.gravity * t * t;
            positions[i] = pos;
        }
        lineRenderer.positionCount = trajectoryStepCount;
        lineRenderer.SetPositions(positions);
    }
    void RotateBow()
    {

        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void Fire()
    {
        rb.velocity = velocity;
    }
}
