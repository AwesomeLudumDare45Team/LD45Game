using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.position += new Vector3 (0, Mathf.Cos(Time.time) * 0.005f, 0);
		transform.localEulerAngles += new Vector3(0, 1, 0);
    }
}
