using UnityEngine;

public class StoneScript : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        Health h = other.gameObject.GetComponent<Health>();
        if (h != null) {
            h.ChangeHealthBy(-15);
        }
        Destroy(gameObject);
    }

}