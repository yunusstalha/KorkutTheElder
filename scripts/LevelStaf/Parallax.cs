using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght, startPos;
    public float parallaxEffect;

    public GameObject cam;
    void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    void Update()
    {
        float temp = (cam.transform.position.x*(1-parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPos+dist,2.5F,transform.position.z);

        if (temp > startPos + lenght) startPos += lenght;
        else if (temp < startPos - lenght) startPos -= lenght;
    }
}
