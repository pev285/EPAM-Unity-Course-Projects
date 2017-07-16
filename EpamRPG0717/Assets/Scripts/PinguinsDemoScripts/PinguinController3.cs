using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinguinController3 : MonoBehaviour {

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


    private GameObject gun;

// Use this for initialization
    void Start () {

        gun = GameObject.Find("Pinguin_v03/Gun");

    } // Start() //



// Update is called once per frame
    void FixedUpdate () {

        if(Input.anyKey) {
            ChooseWeapon();
            Move();
            Fire();
        }

    } // Update() //


    private void Fire() {

        if (Input.GetKey(KeyCode.Keypad0)) {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);

            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
//            bulletRB.velocity = gun.transform.forward.normalized * bulletInitialVelocity;
            bulletRB.velocity = ((gun.transform.rotation*(Vector3.up)).normalized * bulletInitialVelocity);
        }
    } // Fire() //

    private void Move() {

        if (Input.GetKey(KeyCode.Keypad6)) {

            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Keypad4)) {

            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Keypad8)) {

            transform.position += Time.deltaTime * speed * transform.forward;
        }
        if (Input.GetKey(KeyCode.Keypad2)) {
            transform.position -= Time.deltaTime * speed * transform.forward;
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

