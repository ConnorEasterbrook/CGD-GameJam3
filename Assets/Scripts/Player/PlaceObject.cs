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
    [SerializeField] private bool _isTurret = false;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private ResourceScript _resourceScript;
    private GameObject[] _children;

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

        _children = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            _children[i] = transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        Vector3 lookRotation = Quaternion.LookRotation(ray.direction).eulerAngles;

        if (_resourceScript.woodAmount >= 50 && _resourceScript.ammoAmount >= 100)
        {
            PlaceObjectIfResources(ray, hit, lookRotation);
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

    private void PlaceObjectIfResources(Ray ray, RaycastHit hit, Vector3 lookRotation)
    {
        if (Physics.Raycast(ray, out hit, _placeDistance, _layerMask))
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
                GameObject newGO = new GameObject("Gnome Turret");
                newGO.AddComponent<MeshFilter>().mesh = GetComponent<MeshFilter>().mesh;
                newGO.AddComponent<MeshRenderer>().materials = _materials.ToArray();
                AudioSource _as = newGO.AddComponent<AudioSource>();
                _as.playOnAwake = false;
                _as.spatialBlend = 1;


                if (_isTurret)
                {
                    newGO.AddComponent<SphereCollider>().isTrigger = true;
                    TurretShoot turretShoot = newGO.AddComponent<TurretShoot>();
                    turretShoot.CopyTurret(GetComponent<TurretShoot>());
                }

                newGO.transform.position = pos;
                newGO.transform.rotation = transform.rotation;
                newGO.transform.localScale = transform.localScale;

                for (int i = 0; i < _children.Length; i++)
                {
                    GameObject child = Instantiate(_children[i], newGO.transform);
                    child.transform.localPosition = Vector3.zero;
                }

                _resourceScript.RemoveAmmo(100);
                _resourceScript.RemoveWood(50);
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
