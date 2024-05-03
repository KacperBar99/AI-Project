using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
    [SerializeField]
    private float pathTime = 1.0f;
    private Vector3 forward = new Vector3(0f, 0f, 0f);
    private Transform player;
    private LevelController levelController;
    private float timeCounter;
    private bool triggered = false;
    private float speed = 1.5f;
    private field currentField;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        this.levelController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>();
        this.timeCounter = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered) return;
        this.currentField = this.levelController.getField(this.transform.position);
        if (this.currentField == null) Debug.Log("Hejo");
        if (this.currentField.getWeight() > 1) this.speed = 1.0f;
        else this.speed = 1.5f;
        this.transform.position += this.forward * Time.deltaTime * this.speed;
        if (this.timeCounter >= this.pathTime)
        {
            this.timeCounter = 0.0f;
            var res = this.levelController.findPath(this.transform.position, this.player.position);

            var it = res;
            while (it != null)
            {
                it = it.getParent();
                if (it.getParent().getParent() == null)
                {
                    this.forward = it.getPosition()-this.currentField.getPosition();
                    break;
                }
            }
        }
        else
        {
            this.timeCounter += Time.deltaTime;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !this.triggered)
        {
            this.triggered = true;
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player.isPowerUp())
            {
                player.getPoint(15);
                Destroy(this.gameObject);
            }
            else
            {
                SceneManager.LoadScene("Game", LoadSceneMode.Single);
            }

        }
    }
}