using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienPrototype : MonoBehaviour,ICloneable<AlienPrototype>
{

    public int Speed = 5;

    void Start()
    {
        transform.Rotate(0, 180, 0);
    }


    public AlienPrototype Clone()
    {
        GameObject cloneObject = Instantiate(this.gameObject);
        return cloneObject.GetComponent<AlienPrototype>();
    } 
    
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        if (transform.position.z <= 40)
        {
            Destroy(gameObject);
        }
    }
}
