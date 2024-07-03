using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserBeam : MonoBehaviour
{
    Vector2 pos, dir;

    GameObject laserObj;
    LineRenderer laser;
    List<Vector2> laserIndices = new List<Vector2>();

    public bool a;

    public ParticleSystem explosion;

    public List<GameObject> reflections;

    public LaserBeam(Vector2 pos , Vector2 dir , Material material)
    {
        laser = new LineRenderer();
        laserObj = new GameObject();
        laserObj.name = "Laser Beam";
        this.pos = pos;
        this.dir = dir;

        laser = laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        laser.startWidth = 0.1f;
        laser.endWidth = 0.1f;
        laser.numCornerVertices = 15;
        laser.material = material;
        laser.startColor = Color.green;
        laser.endColor = Color.green;

        explosion = GameObject.Find("EndStar").transform.GetChild(10).GetComponent<ParticleSystem>();

        CastRay(pos , dir , laser);
    }

    void CastRay(Vector2 pos , Vector2 dir , LineRenderer laser)
    {
        laserIndices.Add(pos);

        Ray ray = new Ray(pos, dir);
        RaycastHit hit;

        if(Physics.Raycast(ray , out hit, 30, 1))
        {
            CheckHit(hit , dir ,laser);
        }
        else
        {
            laserIndices.Add(ray.GetPoint(30));
            UpdateLaser();
        }
    }

    void UpdateLaser()
    {
        int count = 0;
        laser.positionCount = laserIndices.Count;

        foreach (Vector2 idx in laserIndices)
        {
            laser.SetPosition(count, idx);
            count++;
        }
    }
    void CheckHit(RaycastHit hitInfo , Vector2 direction , LineRenderer laser)
    {
        if(hitInfo.collider.gameObject.tag == "Mirror")
        {
            Vector2 pos = hitInfo.point;
            Vector2 dir = Vector2.Reflect(direction, hitInfo.normal);

            CastRay(pos, dir, laser);
        }
        else
        {
            laserIndices.Add(hitInfo.point);
            UpdateLaser();
        }
        if(hitInfo.collider.gameObject.tag == "Finish")
        {
            GameObject.Find("GameManager").GetComponent<GM>().ActiveReflector.GetComponent<ReflectorObj>().clicked = false;
            hitInfo.collider.gameObject.transform.parent.GetComponent<SpriteRenderer>().color = Color.green;
            if(FindObjectOfType<GM>().NextLvlCanvas.activeSelf == false)
            {
                GameObject.Find("PauseButton").GetComponent<PlayOneShotSound>().PlayOneShotWin();
                explosion.Play();
                GameObject.Find("Circle").transform.GetChild(0).GetComponent<Laser>().Finish();
            }
        }
    }
}