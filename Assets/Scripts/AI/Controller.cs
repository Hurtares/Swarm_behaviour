using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MovementState : int {
    ATTACKING,
    MOVING,
    ORGANIZING,
    RUNNING
}

public class Controller : MonoBehaviour {

    private MovementState currentMovementState;
    public MovementState CurrentMovementState {
        get {
            return currentMovementState;
        }
        set {
            currentMovementState = value;
        }
    }

    //bound é o limite para onde as abelhas podem ir a partir do local em que começaram
    
    public LayerMask player;
    public float searchRadius = 10f;
    public float maxRadius = 50f;
    public Transform colmeia;
    public Material green;
    public Material laranja;
    public Material red;
    [SerializeField]
    //segundos de intervalo para chamar o radar
    private float freq = 0.5f;
    private Vector3 bound;
    [SerializeField]
    private FlockController flock;


    // Use this for initialization
    void Start () {
        bound = colmeia.localScale;
        currentMovementState = MovementState.MOVING;
        CalculateNextMovementPoint();
        StartCoroutine("RadarCall", freq);
    }

    void CalculateNextMovementPoint() {

        float posX = Random.Range(colmeia.position.x - bound.x, colmeia.position.x + bound.x);
        float posY = Random.Range(colmeia.position.y - bound.y, colmeia.position.y + bound.y);
        float posZ = Random.Range(colmeia.position.z - bound.z, colmeia.position.z + bound.z);

        transform.position = new Vector3(posX, posY, posZ);
    }
    // Update is called once per frame
    void Update () {
        Debug.Log(currentMovementState);
        if (currentMovementState == MovementState.MOVING) {
            if (Random.Range(0, 200) <= 2)
                CalculateNextMovementPoint();
        }
    }

    //chama o radar scan de tempo a tempo, dependendo da freq
    private IEnumerator RadarCall(float freq) {
        yield return new WaitForSeconds(freq);
        RadarScan();

    }

    //ver se existem paredes ou enimigos nas redondezas
    private void RadarScan() {
        Collider[] detected;
        Collider[] outOfBounds;
        detected = Physics.OverlapSphere(colmeia.transform.position, searchRadius, player);
        outOfBounds = Physics.OverlapSphere(colmeia.transform.position, maxRadius, player);
        if (detected.Length >= 1 && currentMovementState!=MovementState.ATTACKING) {
            currentMovementState = MovementState.ATTACKING;
            MudarMatterial(red);
            
            Debug.Log(currentMovementState);
            //adicionar coisas que fazem com que as abelhas ficam a perceguir
        }
        if(outOfBounds.Length <= 0 && currentMovementState==MovementState.ATTACKING) {
            currentMovementState = MovementState.MOVING;
            transform.position = colmeia.transform.position;
            MudarMatterial(green);
            Debug.Log(currentMovementState);

        }
        if (currentMovementState == MovementState.ATTACKING) {
            foreach (Collider c in outOfBounds) {
                transform.position = c.transform.position;
            }
        }
        
        StartCoroutine("RadarCall", freq);
    }
    void MudarMatterial(Material material) {

        foreach (Flock abelha in flock.flockList) {
            abelha.rend.material = material;
        }
    }
}
