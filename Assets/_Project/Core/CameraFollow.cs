using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset = new(0f, 20f, -10f);
    [SerializeField] private float _smoothSpeed = 10f;


    private void LateUpdate()
    {
        if (_target == null)
            return;

        Vector3 desiredPosition = _target.position + _offset;
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            Time.deltaTime * _smoothSpeed
        );
    }


    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
