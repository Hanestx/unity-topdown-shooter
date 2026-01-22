using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 12f;
    [SerializeField] private float _lifeTime = 2f;
    [SerializeField] private int _damage = 10;

    private Vector3 _direction;
    private float _timer;

    public void Init(Vector3 direction)
    {
        _direction = direction;
        _timer = _lifeTime;
    }

    private void Update()
    {
        transform.position += _direction * (_speed * Time.deltaTime);

        _timer -= Time.deltaTime;
        if (_timer <= 0f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HealthComponent health))
        {
            health.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}