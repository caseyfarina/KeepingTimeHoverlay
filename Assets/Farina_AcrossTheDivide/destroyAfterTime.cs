using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterTime : MonoBehaviour
{

    [Range(0.0f, 10f)]
    public float timeMin = 5f;
    [Range(0.01f, 10f)]
    public float timeeMax = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        float lifetime = Random.RandomRange(timeMin, timeeMax);


        Destroy(transform.gameObject, lifetime);
    }




    // Update is called once per frame
    void Update()
    {

    }

}
