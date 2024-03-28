using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 targetOffset;
    [SerializeField] private float smoothness = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitCamera();
    }

    void OrbitCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");

        transform.position = player.transform.position + Quaternion.Euler(0, transform.eulerAngles.y, 0) * offset;

        transform.RotateAround(player.transform.position, Vector3.up, smoothness * mouseX);
        transform.LookAt(player.transform.position + targetOffset);
    }
}
