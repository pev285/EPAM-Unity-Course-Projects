using UnityEngine;

public class MagnetoVisualizer : AbstractVisualizer {

    private GameObject magnetPrefab;
    private GameObject caster;
    private Vector3 relativeSpellCastPosition;

    public MagnetoVisualizer(GameObject caster, GameObject prefab, Vector3 relativePosition) {
        this.magnetPrefab = prefab;
        this.caster = caster;
        this.relativeSpellCastPosition = relativePosition;
    }

    public override void Visualize() {
        GameObject magnet = Instantiate(magnetPrefab, relativeSpellCastPosition, Quaternion.identity, caster.transform);


        Timer timer = new Timer(magnet, delegate  {
            Destroy(magnet);
        }, 3.0f);
    }
}