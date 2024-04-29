using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField]
    private float pathTime = 1.0f;

    private Transform player;
    private LevelController levelController;
    private float timeCounter;
    public Color color;
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
        if (this.timeCounter >= this.pathTime)
        {
            this.timeCounter = 0.0f;
            this.levelController.SetDefaultColors();
            var res = this.levelController.findPath(this.transform.position, this.player.position);

            var it = res;
            while (it != null)
            {
                it.gameObject.GetComponent<SpriteRenderer>().color = this.color;
                it = it.getParent();
            }
        }
        else
        {
            this.timeCounter += Time.deltaTime;
        }
        
    }
}
