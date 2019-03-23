using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinIController : MonoBehaviour
{
    public float i_spin = 3.5f;
    public float gamma = 10.10f;
    public float t1 = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // 90deg パルス
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 0;
            GameObject.Find("Canvas").GetComponent<PipulseTextController>().ShowAnimation();
            Time.timeScale = 1;

            transform.RotateAround(
                new Vector3(0, 0, 0),
                new Vector3(0, 0, 1),
                90);
        }
        // 90deg パルス
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.RotateAround(
                new Vector3(0, 0, 0),
                new Vector3(0, 0, 1),
                -180);
        }
    }

    void FixedUpdate()
    {
        GameObject gameMaster = GameObject.Find("Master");
        float omega = 2.0f * Mathf.PI * gamma
            * gameMaster.GetComponent<MasterController>().h0;

        // 歳差運動
        transform.Rotate(
            new Vector3(0, 1, 0) * omega * Time.deltaTime,
            Space.World);

        // 緩和過程
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            Quaternion.Euler(0, 0, 0),
             Time.deltaTime / t1);
    }
}
