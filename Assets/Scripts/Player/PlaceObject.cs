using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    private Collider _collider;
    private MeshRenderer _meshRenderer;
    private List<Color> _originalColor;
    [SerializeField] private List<Material> _materials;
    [SerializeField] private float _placeDistance = 5f;
    private Vector3 _originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider>();
        _collider.enabled = false;

        _meshRenderer = GetComponent<MeshRenderer>();
        _materials = new List<Material>();
        _originalColor = new List<Color>();

        foreach (Material material in _meshRenderer.materials)
        {
            Material newMaterial = new Material(material);
            _materials.Add(newMaterial);
            _originalColor.Add(newMaterial.color);
        }

        _originalRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 lookRotation = Quaternion.LookRotation(ray.direction).eulerAngles;

        if (Physics.Raycast(ray, out hit, _placeDistance))
        {
            Vector3 pos = new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z);

            // Quaternion to face direction of player but same x and y rotation
            Quaternion rot = Quaternion.Euler(_originalRotation.x, lookRotation.y, _originalRotation.z);

            transform.position = pos;
            transform.rotation = rot;

            for (int i = 0; i < _materials.Count; i++)
            {
                GetComponent<MeshRenderer>().materials[i].color = _originalColor[i];
                // _materials[i].color = _originalColor[i];
            }

            if (Input.GetMouseButtonDown(0))
            {
                GameObject gameObject = new GameObject();
                gameObject.AddComponent<MeshFilter>().mesh = GetComponent<MeshFilter>().mesh;
                gameObject.AddComponent<MeshRenderer>().materials = _materials.ToArray();
                gameObject.AddComponent<BoxCollider>();

                gameObject.transform.position = pos;
                gameObject.transform.rotation = transform.rotation;
                gameObject.transform.localScale = transform.localScale;
            }
        }
        else
        {
            transform.position = ray.origin + ray.direction * (_placeDistance - 0.5f);
            transform.rotation = Quaternion.Euler(_originalRotation.x, lookRotation.y, _originalRotation.z);

            for (int i = 0; i < _materials.Count; i++)
            {
                GetComponent<MeshRenderer>().materials[i].color = Color.red;
            }
        }
    }
}
