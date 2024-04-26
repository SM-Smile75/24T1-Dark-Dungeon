using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float ghostSpeed;
    public float ghostDistance;
    public float ghostMovement;

    public float playerSpace;
    public GameObject player;
    public GameObject pauseSensor;

    void FixedUpdate()
    {
        ghostMovement = ghostSpeed * Time.deltaTime;
        ghostDistance = Vector3.Distance(transform.position, player.transform.position);

        if (ghostDistance > playerSpace && pauseSensor.paused == true)
        {
            transform.rotation = Quarternion.LookRotation(player.transform.position - transform.position, transform.up);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, ghostMovement);
        }
    }
}
