using UnityEngine;

public class ShrinkingAnimator : AbstractDeathVisualizer {

    public override void Visualize() {

        Timer t = new Timer(gameObject, delegate ()
        {
            Vector3 scale = gameObject.transform.localScale;
            float factor = 0.80f;
            transform.localScale = Vector3.Scale(scale, new Vector3(factor, factor, factor));
        }, 0.01f, 10);

    }

}