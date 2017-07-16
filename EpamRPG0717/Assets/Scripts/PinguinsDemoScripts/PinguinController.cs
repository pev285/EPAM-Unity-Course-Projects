using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinguinController : MonoBehaviour {

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private float rotationSpeed = 180f;


    [SerializeField]
        private GameObject bulletPrefab;

    [SerializeField]
        private float bulletInitialForce = 500f;

	// Use this for initialization
	void Start () {



	} // Start() //



// Update is called once per frame
    void Update () {

        if(Input.anyKey) {
            ChooseWeapon();
            Move();
            Fire();
        }

    } // Update() //


    private void Fire() {

        if (Input.GetKey(KeyCode.Space)) {
            GameObject newBullet = Instantiate(bulletPrefab);
            GameObject respPoint = GameObject.Find("Pinguin_v01/Gun/RespawnPoint");
//            GameObject respPoint = GameObject.Find("Target");
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.MovePosition(respPoint.transform.position);

            GameObject gun = GameObject.Find("Pinguin_v01/Gun");
            bulletRB.AddForce((gun.transform.rotation*(Vector3.up)).normalized * bulletInitialForce);
        }
    } // Fire() //

    private void Move() {

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Time.deltaTime * Vector3.forward * speed);
        } else if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Time.deltaTime * Vector3.back * speed);
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

