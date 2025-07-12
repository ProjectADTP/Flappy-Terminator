public class PlayerBullet : Bullet
{
    protected override void Death(IInteractable interactable)
    {
        Destroy(gameObject);
    }
}
