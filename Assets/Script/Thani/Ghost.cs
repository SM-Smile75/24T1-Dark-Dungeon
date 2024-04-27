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
    public PlayerMovementAdvanced playerStats;
    public PlayerUI pauseSensor;

    void FixedUpdate()
    {
        ghostMovement = ghostSpeed * Time.deltaTime;
        ghostDistance = Vector3.Distance(transform.position, player.transform.position);

        if (ghostDistance > playerSpace && pauseSensor.isPaused == false && playerStats.invincible == false)
        {
            transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.up);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, ghostMovement);
        } else if (pauseSensor.isPaused == false && playerStats.invincible == true)
        {
            transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.up);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, -1 * ghostSpeed * Time.deltaTime);
        }
    }
}
