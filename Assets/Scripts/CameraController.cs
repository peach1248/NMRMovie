using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float gamma = 0;
    bool rotateBool = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (rotateBool)
            {
                rotateBool = false;
            } else {
                rotateBool = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (rotateBool)
        {
            GameObject gameMaster = GameObject.Find("Master");
            float omega = 2.0f * Mathf.PI * gamma
               * gameMaster.GetComponent<MasterController>().h0;

            float y = transform.position.y;
            transform.RotateAround(
                new Vector3(0, y, 0),
                transform.up,
                omega * Time.deltaTime);
        }
    }
}
