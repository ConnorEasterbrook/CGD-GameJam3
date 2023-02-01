using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RandomRotate : MonoBehaviour
{
    public bool randomize = false;

    private void Update()
    {
        if (randomize)
        RandomizeRotation();
    }

    public void RandomizeRotation()
    {
        transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
    }
}
