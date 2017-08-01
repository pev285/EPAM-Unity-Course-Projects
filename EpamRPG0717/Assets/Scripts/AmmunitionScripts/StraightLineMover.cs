using UnityEngine;

public class StraightLineMover : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 40f;

    [SerializeField]
    private Vector3 moveDirection = new Vector3(0, 0, 1);

    void Update() {

        transform.Translate(Time.deltaTime * moveSpeed * moveDirection);
    }

}