using System.Security.Permissions;
using Unity.VisualScripting;
using UnityEngine;

[SelectionBase]
public class Gate : MonoBehaviour {
    [SerializeField] bool opening = false; // hello this is my comment for Testing merge conflict...
    [Range(0, 1)] public float howOpen = 0;
    [SerializeField] float speed = 1;
    [SerializeField] float maxRotation = 90;
    [SerializeField] AnimationCurve curve;
    Quaternion initialRot;
    void Awake() {
        initialRot = transform.rotation;
    }
    public void Open() { opening = true; }
    public void Close() { opening = false; }
    void Update() {
        //if (opening) {
        //    howOpen += Time.deltaTime * speed * 1;
        //} else {
        //    howOpen += Time.deltaTime * speed * -1;
        //}
        // print(true ? "it was true" : "it was false");
        howOpen += Time.deltaTime * speed * (opening ? 1 : -1); // ?:
        howOpen = Mathf.Clamp01(howOpen);
        float modifiedHowOpen = Mathf.Clamp01(curve.Evaluate(howOpen));
        var rot = Quaternion.AngleAxis(modifiedHowOpen * maxRotation, Vector3.up);
        transform.rotation = rot * initialRot;
    }
}
