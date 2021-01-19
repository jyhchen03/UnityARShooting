using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public GameObject goose;
    public GameObject goose1;
    public GameObject goose2;
    public GameObject goose3;
    public GameObject goose4;
    public GameObject explosion;

    // Start is called before the first frame updates
    void Start()
    {

    }

    // Update is called once per frames
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(newExplosion, 2);


            if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
            {

                GameObject newGoose = Instantiate(goose);
                GameObject newGoose1 = Instantiate(goose1);
                GameObject newGoose2 = Instantiate(goose2);
                GameObject newGoose3 = Instantiate(goose3);
                GameObject newGoose4 = Instantiate(goose4);

            }

            Destroy(gameObject);

        }
    }

}