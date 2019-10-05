using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlock : MonoBehaviour
{
    public GameObject m_prefabBird;
    

    public float m_oneBirdSpawnThickness; // Depend on number of birds

    public float m_baseVelocity;


    //TODO
    public Camera m_camera;

    [HideInInspector]
    public List<Bird> m_birds;
    [HideInInspector]
    public Boundaries m_cameraBoundaries;
    [HideInInspector]
    public Boundaries m_worldBoundaries;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateFlock()
    {
        if(m_birds.Count != 0)
        {
            foreach(Bird bird in m_birds){
                Destroy(bird.gameObject);
            }
            m_birds.Clear();   
        }

        //int randomNumber;
        //Vector3 randomBasePosition = _basePosition;
        //Vector3 randomVelocity;
        //Direction randomDirection;

        //for (int i = 0; i < randomNumber; ++i)
        //{
            

            
        //}
    }

    void CreateBird(Direction _direction, Vector3 _basePosition)
    {
        //GameObject go = Instantiate(m_prefabBird, randomPosition, Quaternion.identity);
        //if (go == null)
        //{
        //    Debug.LogError("Error while instantiating a bird");
        //    return;
        //}

        //Bird bird = go.GetComponent<Bird>();
        //if (bird == null)
        //{
        //    Debug.LogError("Error while instantiating a bird");
        //    return;
        //}

        //bird.m_flock = this;
        //m_birds.Add(bird);
    }
}
