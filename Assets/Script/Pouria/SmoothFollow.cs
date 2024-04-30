using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target; 
    public float speed = 2.0f; 
    public float stoppingDistance = 0.5f; 
    public float rotationSpeed = 2.0f; 
    public float rotationMagnitude = 90.0f; 

    private float rotationAngle = 0.0f; 

    void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > stoppingDistance)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }

        OscillateRotation();
    }

    void OscillateRotation()
    {
        rotationAngle += rotationSpeed * Time.deltaTime;
        float angle = rotationMagnitude * Mathf.Sin(rotationAngle);

        Quaternion currentRotation = Quaternion.LookRotation(target.position - transform.position);
        Quaternion zOscillation = Quaternion.Euler(0, 0, angle);
        transform.rotation = currentRotation * zOscillation;
    }
}