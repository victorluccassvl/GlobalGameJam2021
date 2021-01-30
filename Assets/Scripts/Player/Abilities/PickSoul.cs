using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSoul : MonoBehaviour
{
    [SerializeField]
    private float _soulRotationSpeed = 100f;
    [SerializeField]
    private float _soulFluctuationAmplitude = 0.5f;
    [SerializeField]
    private float _soulFluctuationRadialSpeed = 4f;
    [SerializeField]
    private float _orbitCenterHeight = 1f;
    [SerializeField]
    private float _orbitRadius = 0.7f;

    private Transform _pickedSoul = null;

    public bool HasSoul
    {
        get => _pickedSoul != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + Vector3.up * _orbitCenterHeight, 0.7f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Soul")
        {
            _pickedSoul = other.transform;
            _pickedSoul.parent = transform;
            if (_pickedSoul.position.x < transform.position.x)
                _pickedSoul.localPosition = _orbitRadius * Vector3.left + _orbitCenterHeight * Vector3.up;
            else
                _pickedSoul.localPosition = _orbitRadius * Vector3.right + _orbitCenterHeight * Vector3.up;

            other.enabled = false;
        }
    }

    private void Update()
    {
        if (HasSoul)
        {
            _pickedSoul.RotateAround(transform.position, Vector3.up, Time.deltaTime * _soulRotationSpeed);

            Vector3 newPosition;
            newPosition.x = _pickedSoul.position.x;
            newPosition.y = transform.position.y + _orbitCenterHeight + _soulFluctuationAmplitude * Mathf.Sin(Time.time * _soulFluctuationRadialSpeed) / 2;
            newPosition.z = _pickedSoul.position.z;
        }
    }
}
