using UnityEngine;
using UnityEngine.UI;

public class RayShooter : MonoBehaviour
{

    private Camera _camera;
    private AudioSource source;
    private float volLow = 0.25f;
    private float volHigh = 0.3f;
    private UIController _controller;


    public AudioClip shootSound;
    public float range = 200f;
    public Text _score;
    public GameObject _UI;
    public GameObject bulletHole;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        _controller = _UI.GetComponent<UIController>();
    }
    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.visible = false;
        _controller.ResetScore();
    }

    void Update()
    {
        if (Time.deltaTime == 0f)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range))
            {
                Debug.Log("Hit " + hit.transform.name);

                if(hit.collider!=null)
                {
                    Instantiate(bulletHole, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                }
                if (hit.transform.name == "Shortest")
                {
                    _controller.UpdateScore(10);
                }

                if (hit.transform.name == "Shorter")
                {
                    _controller.UpdateScore(6);
                }

                if (hit.transform.tag == "Target")
                {
                    _controller.UpdateScore(2);
                }

                if (hit.transform.tag == "EnemyFast")
                {
                    _controller.UpdateScore(10);
                }

                if (hit.transform.tag == "EnemyNormal")
                {
                    _controller.UpdateScore(6);
                }

                if (hit.transform.tag == "EnemySlow")
                {
                    _controller.UpdateScore(2);
                }

                if (hit.transform.name == "Switch")
                {
                    hit.transform.gameObject.layer = 2;
                    hit.transform.GetComponent<SphereSpawn>().Spawn();
                }

                if (hit.transform.tag == "SphereTarget")
                {
                    Destroy(hit.transform.gameObject);
                    _controller.UpdateScore(20);
                }

                if (hit.transform.name == "Up")
                {
                    hit.transform.GetComponent<IncreaseNumber>().IncreaseTargetNumber();
                }

                if (hit.transform.name == "Down")
                {
                    hit.transform.GetComponent<DecreaseNumber>().DecreaseTargetNumber();
                }

                if (hit.transform.name == "ResetSwitch")
                {
                    _controller.ResetScore();
                }

            }
            float vol = Random.Range(volLow, volHigh);
            source.PlayOneShot(shootSound, vol);
        }
    }
    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY,size, size), "*");
    }
}
