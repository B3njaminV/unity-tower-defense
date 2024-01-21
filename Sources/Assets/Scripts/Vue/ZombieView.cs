using UnityEngine;

public class ZombieView
{
    private Rigidbody2D _rb;
    private Animator _animator;

    public ZombieView(
            Rigidbody2D rb, Animator animator
        )
    {
        _rb = rb;
        _animator = animator;
    }

    public void UpdateMotion(float knockbackForce, float maxSpeed, bool canMove)
    {
        float veloc = - _rb.velocity.x;
        if (veloc < -knockbackForce)
        {
            _rb.velocity = new Vector2(-knockbackForce, 0f);
            veloc = -knockbackForce;
        }

        _animator.SetFloat("Speed", veloc);
        if (canMove && veloc < maxSpeed)
        {
            _rb.AddForce(Vector2.left);
        }
    }

    public void Damages()
    {
        _animator.SetTrigger("Damages");
        _rb.velocity = Vector2.zero;
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
    }

    public void Death()
    {
        _animator.SetTrigger("Death");
    }

}
