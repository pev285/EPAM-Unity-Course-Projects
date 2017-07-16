using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinguinController2 : MonoBehaviour {

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private float rotationSpeed = 180f;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private GameObject bulletSpawnPoint;

    [SerializeField]
    private float bulletInitialVelocity = 30f;

    Rigidbody rigidbody;

    //[SerializeField]
    private Camera pinguinCam;

    private GameObject gun;

// Use this for initialization
    void Start () {


        rigidbody = GetComponent<Rigidbody>();

        pinguinCam = GameObject.Find("Pinguin2Camera").GetComponent<Camera>();
        pinguinCam.enabled = false;


        gun = GameObject.Find("Pinguin_v02/Gun");


    } // Start() //



// Update is called once per frame
    void FixedUpdate () {

        if(Input.anyKey) {
            ChooseCamera();
            ChooseWeapon();
            Move();
            Fire();
        }

    } // Update() //


    private void ChooseCamera() {
        if (Input.GetKey(KeyCode.Alpha0)) {
            pinguinCam.enabled = !pinguinCam.enabled;
        }
    }


    private void Fire() {

        if (Input.GetKey(KeyCode.RightControl)) {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);

            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.velocity = ((gun.transform.rotation*(Vector3.up)).normalized * bulletInitialVelocity);
        }
    } // Fire() //

    private void Move() {

        if (Input.GetKey(KeyCode.LeftArrow)) {
            rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Inverse(Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.up )));
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            rigidbody.MoveRotation(rigidbody.rotation * Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.up ));
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            Vector3 forward = transform.rotation * Vector3.forward;
            rigidbody.MovePosition(transform.position + Time.deltaTime * speed * forward );
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            Vector3 backward = transform.rotation * Vector3.back;
            rigidbody.MovePosition(transform.position + Time.deltaTime * speed * backward);
        }

    } // Move() //


    private void ChooseWeapon() {

        if (Input.GetKey(KeyCode.Alpha1)) {
// Choose weapon 1
        } else if (Input.GetKey(KeyCode.Alpha2)) {
// Coose weapon 2
        }


    } // ChooseWeapon() //



} // End Of Class

