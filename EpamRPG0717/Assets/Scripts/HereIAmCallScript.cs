using UnityEngine;

public class HereIAmCallScript : MonoBehaviour {

    void Start() {
        GameManager.Instance.HereIAm(gameObject);

        print("HereIAm: Starting " + gameObject.name);
    }
}
