using UnityEngine;

public class MagnetoVisualizer : AbstractVisualizer {

    private GameObject magnetPrefab;
    private GameObject caster;
    private Vector3 spellCastPosition;

    public MagnetoVisualizer(GameObject caster, GameObject prefab, Vector3 relativePosition) {
        this.magnetPrefab = prefab;
        this.caster = caster;
        this.spellCastPosition = relativePosition;

    }

    public override void Visualize() {

        GameObject magnet = Instantiate(magnetPrefab, spellCastPosition, Quaternion.identity);

        Timer timer = new Timer(magnet, delegate  {
            Destroy(magnet);
        }, 1.5f);
    }
}