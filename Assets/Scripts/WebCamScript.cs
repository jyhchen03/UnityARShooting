using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamScript : MonoBehaviour
{   
    // Start is called before the first frame update
    public GameObject webCameraPlane;
    public Button fireButton;
    public GameObject bullet;
    public GameObject goose;
    void Start()
    {
        if (Application.isMobilePlatform)
        {
            GameObject cameraParent = new GameObject("camParent");
            cameraParent.transform.position = this.transform.position;
            cameraParent.transform.Rotate(Vector3.right, 90);
        }
        Input.gyro.enabled = true;

        WebCamTexture webCameraTexture = new WebCamTexture(); //assign texture to the plane
        webCameraPlane.GetComponent<MeshRenderer>().material.mainTexture = webCameraTexture;
        webCameraTexture.Play();

        fireButton.onClick.AddListener(OnButtonDown);

        goose.SpawnGoose(); //randomly spawn geese
    }

    void SpawnGoose() //TODO spawn goose random xy pos, fix z rotation
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject newgoose = goose;
            Vector3 randpos = new Vector3(Random.Range(0.0f, 5.0f), Random.Range(0.0f, 5.0f), 0.0f);
            Instantiate(newgoose);
        }
    }

    void OnButtonDown()
    {

        Vector3 bulletDirection = Camera.main.transform.position;
        Quaternion bulletRotation = Camera.main.transform.rotation * Quaternion.Euler(90, 0, 0);

        GameObject newBullet = Instantiate(bullet, bulletDirection, bulletRotation);

        Vector3 bulletFireDirection = Camera.main.transform.forward;
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        rb.AddForce(bulletFireDirection * 500f);
        Destroy(newBullet, 3);
        GetComponent<AudioSource>().Play();

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion cameraRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        this.transform.localRotation = cameraRotation;
    }
}
