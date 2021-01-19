using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame updates
    void Start()
    {
        StartCoroutine("Move");
    }

    // Update is called once per frames
    void Update()
    {
        transform.Translate(Vector3.forward * 3f * Time.deltaTime);
    }

    IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            transform.eulerAngles += new Vector3(0, 180f, 0);
        }
    }
}