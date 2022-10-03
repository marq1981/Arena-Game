using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
 
    public Transform folowPlayer;
    public PlayerController playerController;
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }


    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, folowPlayer.position, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, folowPlayer.rotation, 0);
    }
}

