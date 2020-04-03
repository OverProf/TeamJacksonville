using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header ("Stats")]
    public float speed;
    public float stoppingDistance;
    public float nearDistance;
    public float runDistance = 8;
    public float startTimeBtwShots;
    private float timeBtwShots;

    [Header("Refrences")]
    public GameObject shot;
    public Transform player;

    public BoxCollider you;
    public GameObject rival;

    public BoxCollider me;
    const float buffsize = 5f;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < nearDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        else if(Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, player.position) < stoppingDistance && Vector3.Distance(transform.position, player.position) > nearDistance)
        {
            transform.position = this.transform.position;
        }


        if(timeBtwShots <= 0)
        {
            Instantiate(shot, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        if(me.size == new Vector3(buffsize, me.size.y, buffsize))
        {
            nearDistance = runDistance;
        }

    }

    void OnCollisionEnter(Collision you)
    {
        Destroy(rival);
    }
}
