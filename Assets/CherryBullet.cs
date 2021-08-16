using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryBullet : MonoBehaviour
{
    private float speed = 12;
    private Vector2 dir;

    void Start()
    {
        dir = GameObject.Find("Aim").transform.position;
        transform.position = GameObject.Find("Firepoint").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
    }
}
