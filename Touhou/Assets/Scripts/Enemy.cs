using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform nextGoalPoint;
    public Transform lastGoalPoint;
    private Transform _transform;
    public float startTime;
    public float endTime;
    private float interpolationRatio;

    private void Start()
    {
        startTime += Time.time;
        _transform = transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.transform.tag == "wayPoint")
        {
            startTime = Time.time;
            lastGoalPoint = nextGoalPoint;
            nextGoalPoint = collision.GetComponent<WayPoint>().nextGoalPoint;
        }
    }

    private void FixedUpdate()
    {
        interpolationRatio = (Time.time - startTime) / endTime;
        _transform.position = Vector3.Lerp(lastGoalPoint.position, nextGoalPoint.position, interpolationRatio);
    }   
}