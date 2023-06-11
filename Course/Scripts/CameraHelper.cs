using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHelper : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            gameObject.transform.position += new Vector3 (gameObject.transform.forward.x, 0,gameObject.transform.forward.z) * speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            gameObject.transform.position -= new Vector3(gameObject.transform.right.x, 0, gameObject.transform.right.z) * speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            gameObject.transform.position -= new Vector3(gameObject.transform.forward.x, 0, gameObject.transform.forward.z) * speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            gameObject.transform.position += new Vector3(gameObject.transform.right.x, 0, gameObject.transform.right.z) * speed * Time.deltaTime;
        }
    }
}
