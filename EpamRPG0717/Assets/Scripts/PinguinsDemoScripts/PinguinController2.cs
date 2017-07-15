using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinguinController2 : MonoBehaviour {

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private float rotationSpeed = 180f;


    Rigidbody rigidbody;


// Use this for initialization
    void Start () {

//        Health health = GetComponent<Health>();
//        Timer t = new Timer(gameObject, delegate() {  health.CurrentHP -= 3; }, 0.3f, 10);



        rigidbody = GetComponent<Rigidbody>();

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

        if (Input.GetKey(KeyCode.Space)) {

        }
    } // Fire() //

    private void Move() {

        if (Input.GetKey(KeyCode.LeftArrow)) {
            rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Inverse(Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.up )));
//            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.RightArrow)) {

            rigidbody.MoveRotation(rigidbody.rotation * Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.up ));
//            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.UpArrow)) {
            Vector3 forward = transform.rotation * Vector3.forward;
            rigidbody.MovePosition(transform.position + Time.deltaTime * speed * forward );
        } else if (Input.GetKey(KeyCode.DownArrow)) {
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

