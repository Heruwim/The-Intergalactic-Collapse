using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private int _damage = 1;


    private void Update()
    {
        MoveTo();
    }

    public void MoveTo()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime, Space.World);
    }
}
