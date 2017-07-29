using UnityEngine;

public class YzeroDeathVisualizer : AbstractDeathVisualizer {

    public override void Visualize() {


        Timer t = new Timer(gameObject, delegate ()
        {
            Vector3 scale = gameObject.transform.localScale;
            float factor = 0.50f;
            Vector3 vectorFactor = new Vector3(1, factor, 1);
            transform.localScale = Vector3.Scale(scale, vectorFactor);
//            transform.position = Vector3.Scale(transform.position, vectorFactor);
        }, 0.1f, 10);

    }
}