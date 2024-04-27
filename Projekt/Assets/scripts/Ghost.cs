using UnityEngine;

public class Ghost : MonoBehaviour
{
    private Transform player;
    private LevelController levelController;
    private bool did = false;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        this.levelController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>();


    }

    // Update is called once per frame
    void Update()
    {
        if (did) return;
        var res = this.levelController.findPath(this.transform.position, this.player.position);
        
        did = true;

        var it = res;
        while (it != null)
        {
            it.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            it = it.getParent();
        }
    }
}
