using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChange : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objects;
    private int _index = 0;
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _rotationSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangePosition());
    }

    // Update is called once per frame
    void Update()
    {
        if (_index >= _objects.Count)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().disablePlayer = false;
            StopCoroutine(ChangePosition());
            gameObject.SetActive(false);
        }
    }

    private IEnumerator ChangePosition()
    {
        while (_index < _objects.Count)
        {
            if (transform.position != _objects[_index].transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, _objects[_index].transform.position, _moveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, _objects[_index].transform.rotation, _rotationSpeed * Time.deltaTime);
            }
            else if (transform.position == _objects[_index].transform.position)
            {
                _index++;
            }
            yield return null;
        }
    }
}
