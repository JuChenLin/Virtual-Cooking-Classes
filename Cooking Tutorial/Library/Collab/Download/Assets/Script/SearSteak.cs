using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearSteak : MonoBehaviour
{
    public Collider[] ingredients;
    //public SphereCollider tColl;
    //public Rigidbody rbPan;
    public GameObject panHeat;
    public float sensingDistance;
    public Material Raw;
    public Material Done;


    float timeleft = 3.0f;
    int ingredientMask;

    // Start is called before the first frame update
    void Start()
    {
        //rbPan = GetComponent<Rigidbody>();
        panHeat = GameObject.FindWithTag("panHeat");
        //Debug.Log("Get GameObject = " + panHeat);
        ingredientMask = LayerMask.NameToLayer("layer_Ingredient");
    }

    // Update is called once per frame
    void Update()
    {

        //tColl = GetComponent<SphereCollider>();
        ingredients = Physics.OverlapSphere(transform.position, sensingDistance, 1 << ingredientMask);
        //Debug.Log("Ingredients Length = " + ingredients.Length);
        
        if (ingredients.Length > 1) {

            timeleft -= Time.deltaTime;
            Debug.Log(timeleft);

            float[] distances = new float[ingredients.Length];

            for( int i = 0; i < ingredients.Length; i++) {

                //private Ray rayToMeat = new Ray(rbPan.position, Vector3 direction);
                distances[i] = (panHeat.transform.position - ingredients[i].transform.position).magnitude;
            }
            Debug.Log("distances[0] = " + distances[0] + ", distances[1] = " + distances[1]);

            if (timeleft < 0)
            {
                if (distances[0] < distances[1])
                {

                    ingredients[0].gameObject.GetComponent<MeshRenderer>().material = Done;
                }
                else
                {
                    ingredients[1].gameObject.GetComponent<MeshRenderer>().material = Done;
                }
            }

        }
    }
}
