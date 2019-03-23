using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    public GameObject nuclearSpinObjPrefab;
    public float h0 = 2;
    float gamma = 10.10f;
    float i_spin = 3.5f;
    float t1 = 0.05f;

    int num_spin = 10;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < num_spin; i++)
        {
            GameObject g = Instantiate(
                nuclearSpinObjPrefab,
                transform);
            g.transform.position = new Vector3(0, 0, 0);
            SpinIController controller = g.GetComponent<SpinIController>();
            controller.gamma = gamma * (1 + (Random.value - 0.5f) / 10);
            controller.i_spin = i_spin;
            controller.t1 = t1;
        }

        GameObject.Find("Main Camera").GetComponent<CameraController>().gamma = gamma;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
