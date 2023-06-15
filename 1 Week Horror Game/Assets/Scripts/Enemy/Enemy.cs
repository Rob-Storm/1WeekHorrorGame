using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform playerTransform;

    public Player player;

    public LayerMask whatIsGround, whatIsPlayer;

    //HardMode
    public float hardModeMult;
    public HardMode hardMode;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public float searchDelay;
    public float patrolSpeed, chaseSpeed;

    //Chasing
    public AudioSource audioSource;
    public AudioClip chaseClip, startClip;
    public bool playing = false, hasStartSound;

    //States
    public float sightRange;
    public bool playerInSightRange;

    private void Awake()
    {
        playerTransform = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = patrolSpeed;
    }

    private void Start()
    {
        if(hardMode.isEnabled)
        {
            sightRange *= hardModeMult;
            Debug.Log("Hardmode is Enabled!");
        }

        if (hasStartSound)
        {
            audioSource.PlayOneShot(startClip);
        }
    }

    private void Update()
    {
        //Check for sight and range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSightRange) Patrolling();
        if (playerInSightRange) ChasePlayer();
    }

    private void Patrolling()
    {
        if(!walkPointSet) Invoke(nameof(SearchWalkPoint), searchDelay);

        if(walkPointSet)
        {
            agent.SetDestination(walkPoint);
            agent.speed = patrolSpeed;
        }
            
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint Reached
        if(distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(playerTransform.position);
        agent.speed = chaseSpeed;

        if(!playing)
        {
            audioSource.PlayOneShot(chaseClip);
            playing = true;
            Invoke(nameof(ResetAudio), 10);
        }
    }

    private void ResetAudio()
    {
        playing = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.Death();
        }
    }

    public void HardMode()
    {
        audioSource.volume = 0f;
        patrolSpeed = 4.95f;
        chaseSpeed = 5.01f;
        sightRange *= 1000.0f;
    }
}
