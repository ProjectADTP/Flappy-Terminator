using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] protected Bullet Bullet;
    [SerializeField] protected SceneReferences SceneRefs;
    [SerializeField] protected Front Face;
    [SerializeField] protected Vision Vision;

    protected Quaternion _tilt = Quaternion.Euler(0, 0, 90);

    protected void Shoot()
    {
        Bullet bullet = Instantiate(Bullet, Face.transform.position, _tilt, SceneRefs.Bullets);

        if (bullet.TryGetComponent(out BulletMover mover))
        {
            mover.SetDirection(Vision);
        }
    }
}
