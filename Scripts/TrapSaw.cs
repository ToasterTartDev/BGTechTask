using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// saw script
public class TrapSaw : MonoBehaviour
{
    [SerializeField]
    private GameObject trapSaw;
    [SerializeField]
    private GameObject rotateSaw;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float pointA;
    [SerializeField]
    private float pointB;


    bool moveA = true;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 2) == 0)
        {
            trapSaw.transform.localPosition = new Vector3(pointA, 0f, 0f);
        }
        else
        {
            trapSaw.transform.localPosition = new Vector3(pointB, 0f, 0f);
        }
    }

    // move saw between pointA and pointB positions
    // Update is called once per frame
    void Update()
    {
        rotateSaw.transform.Rotate(Vector3.forward * speed * 100f * Time.deltaTime);

        if(moveA)
        {
            if (trapSaw.transform.localPosition.x > pointA)
                trapSaw.transform.Translate(-Vector3.right * speed * Time.deltaTime);
            else
                moveA = false;
        }
        else
        {
            if (trapSaw.transform.localPosition.x < pointB)
                trapSaw.transform.Translate(Vector3.right * speed * Time.deltaTime);
            else
                moveA = true;
        }
    }
}
