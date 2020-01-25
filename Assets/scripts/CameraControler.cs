using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

    public GameObject target;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}
