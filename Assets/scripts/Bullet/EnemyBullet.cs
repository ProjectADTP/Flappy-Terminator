public class EnemyBullet : Bullet
{
    protected override void Death(IInteractable interactable)
    {
        if (interactable is Enemy)
        {
            return;
        }

        Destroy(gameObject);
    }
}
