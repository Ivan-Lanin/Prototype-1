using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset1 = new Vector3(0, 5, -7);
    [SerializeField] private Vector3 offset2 = new Vector3(0, 2.32f, 1);
    private Vector3 currentOffset = new Vector3(0, 0, 0);
    private bool cameraIsSwitched = true;

    // Start is called before the first frame update
    void Start()
    {
        currentOffset = offset1;
    }


    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("E");
            currentOffset = CameraSwitch(cameraIsSwitched);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + currentOffset;
        if (cameraIsSwitched == false) {
            transform.rotation = player.transform.rotation;
        }
    }

    private Vector3 CameraSwitch(bool state) {
        if (state == true) {
            cameraIsSwitched = false;
            return offset2;
        }
        else {
            cameraIsSwitched = true;
            return offset1;
        }
    }
}
