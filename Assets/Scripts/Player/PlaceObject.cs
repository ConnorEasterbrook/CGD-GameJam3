using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    private Collider _collider;
    private MeshRenderer _meshRenderer;
    private Color _originalColor;
    [SerializeField] private Material _material;
    [SerializeField] private float _placeDistance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider>();
        _collider.enabled = false;

        _meshRenderer = GetComponent<MeshRenderer>();
        _originalColor = _meshRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _placeDistance))
        {
            Vector3 pos = new Vector3(hit.point.x, hit.point.y + (transform.localScale.y / 2), hit.point.z);

            transform.position = pos;
            _meshRenderer.material.color = _originalColor;

            if (Input.GetMouseButtonDown(0))
            {
                GameObject gameObject = new GameObject();
                gameObject.AddComponent<MeshFilter>().mesh = GetComponent<MeshFilter>().mesh;
                gameObject.AddComponent<MeshRenderer>().material = _material;
                gameObject.AddComponent<BoxCollider>();
                
                gameObject.transform.position = pos;
                gameObject.transform.rotation = transform.rotation;
                gameObject.transform.localScale = transform.localScale;
            }
        }
        else
        {
            transform.position = ray.origin + ray.direction * (_placeDistance - 0.5f);
            _meshRenderer.material.color = Color.red;
        }
    }
}
