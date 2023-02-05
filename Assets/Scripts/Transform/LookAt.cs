using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LookAt : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private bool _invert;

    // Update is called once per frame
    void Update()
    {
        if (_invert)
        {
            Quaternion rotation = Quaternion.LookRotation(transform.position - _target.position);
            transform.rotation = rotation;
        }
        else
        {
            transform.LookAt(_target);
        }
    }
}
