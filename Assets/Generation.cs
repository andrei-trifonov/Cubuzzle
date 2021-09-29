using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class Generation : MonoBehaviour
{
    public GameObject SpawnPoint;
    public GameObject Spawn;
    private Block[]  Spawn_cells;
    public GameObject Player;
    public GameObject[] go2;
    public List <GameObject> go;
    public int seed;
    public int finalx;
    public int finaly;
    public int finalz;
    public GameObject next1;
    public GameObject next2;
    public GameObject next3;
    public GameObject next4;
    public GameObject next5;
    public GameObject next6;
    public List <GameObject> randlist;


    // Start is called before the first frame update
    void Start()
    {
    /*
        GameObject[] go=GameObject.FindGameObjectsWithTag("Finish");
        for(int i = 0; i< go.Length; i++)
            {
                //Check if it contains area
               go[i].name = "x" + go[i].transform.position.x +  "_y" + go[i].transform.position.y + "_z" + go[i].transform.position.z;
               Block component = go[i].AddComponent<Block>();

               */
    seed = Random.Range (0,9999);
    Random.InitState(seed);
    Spawn_cells = Spawn.GetComponentsInChildren<Block>();

    SpawnPoint = Spawn_cells [Random.Range(0, Spawn_cells.Length)].gameObject;
    SpawnPoint.GetComponent<Block>().actual_spawn = true;


    next1 = Generate_next (SpawnPoint);

    next2 = Generate_next (next1);

    next3 = Generate_next (next2);

    next4 = Generate_next (next3);

    next5 = Generate_next (next4);









    go2=GameObject.FindGameObjectsWithTag("Blocks");
         for(int i = 0; i< go2.Length; i++)
             {
                 //Check if it contains area
               if (go2[i].GetComponent<Block>().placed==false){
                 go2[i].SetActive(false);
               }
               else {

               go2[i].SetActive(true);
               }

    }
    Player.transform.position = SpawnPoint.gameObject.transform.position;
     }
    GameObject Generate_next(GameObject Point)
    {
        go.Clear();

        int i1 = (int)(Point.name[1])+1-48;

        for (int i= i1; i< 9; i++)
        {

            string new_name = ("x" + i + "_y" + Point.name[4] + "_z" + Point.name[7]);

            go.Add(GameObject.Find (new_name));
        }
        for (int i= 1; i<  i1-1; i++)
        {

            string new_name = ("x" + i + "_y" + Point.name[4] + "_z" + Point.name[7]);

            go.Add(GameObject.Find (new_name));
        }
       i1 = (int)(Point.name[4])+1-48;

        for (int i= i1; i< 9; i++)
        {

            string new_name = ("x" + Point.name[1] + "_y" + i + "_z" + Point.name[7]);

            go.Add(GameObject.Find (new_name));
        }
        for (int i= 1; i<  i1-1; i++)
        {

            string new_name = ("x" + Point.name[1] + "_y" + i + "_z" + Point.name[7]);

            go.Add(GameObject.Find (new_name));
        }
       i1 = (int)(Point.name[7])+1-48;
        Debug.Log( "Используется" + i1);
        for (int i= i1; i< 9; i++)
        {
            Debug.Log(i);
            string new_name = ("x" + Point.name[1] + "_y" + Point.name[4] + "_z" + i);

            go.Add(GameObject.Find (new_name));
        }
        for (int i= 1; i<  i1; i++)
        {

            string new_name = ("x" + Point.name[1] + "_y" + Point.name[4] + "_z" + i );

            go.Add(GameObject.Find (new_name));
        }

                        for (int i= 0; i<  go.Count; i++){

                                    if (go[i] == null){
                                    go.Remove(null);
                                    }}
/*
                  Debug.Log("x"+((int)(Point.name[1])+1-48) + "_y" + Point.name[4] + "_z" + Point.name[7]);

                        Debug.Log("x"+((int)(Point.name[1])-1-48) + "_y" + Point.name[4] + "_z" + Point.name[7]);

                       Debug.Log("x"+Point.name[1] + "_y" +((int)(Point.name[4])-1-48)  + "_z" + Point.name[7]);

                        Debug.Log("x"+Point.name[1] + "_y" +((int)(Point.name[4])+1-48)  + "_z" + Point.name[7]);

                      Debug.Log("x"+Point.name[1] + "_y" + Point.name[4]  + "_z" + ((int)((Point.name[7])-1-48)));

                        Debug.Log("x"+Point.name[1] + "_y" + Point.name[4]  + "_z" + ((int)((Point.name[7])+1-48)));
*/
            if(GameObject.Find("x"+((int)(Point.name[1])+1-48) + "_y" + Point.name[4] + "_z" + Point.name[7]) != null)
            GameObject.Find("x"+((int)(Point.name[1])+1-48) + "_y" + Point.name[4] + "_z" + Point.name[7]).GetComponent<Block>().protect = true;
            if(GameObject.Find("x"+((int)(Point.name[1])-1-48) + "_y" + Point.name[4] + "_z" + Point.name[7]) != null)
            GameObject.Find("x"+((int)(Point.name[1])-1-48) + "_y" + Point.name[4] + "_z" + Point.name[7]).GetComponent<Block>().protect = true;
            if(GameObject.Find("x"+Point.name[1] + "_y" +((int)(Point.name[4])-1-48)  + "_z" + Point.name[7]) != null)
            GameObject.Find("x"+Point.name[1] + "_y" +((int)(Point.name[4])-1-48)  + "_z" + Point.name[7]).GetComponent<Block>().protect = true;
            if(GameObject.Find("x"+Point.name[1] + "_y" +((int)(Point.name[4])+1-48)  + "_z" + Point.name[7]) != null)
            GameObject.Find("x"+Point.name[1] + "_y" +((int)(Point.name[4])+1-48)  + "_z" + Point.name[7]).GetComponent<Block>().protect = true;
            if(GameObject.Find("x"+Point.name[1] + "_y" + Point.name[4]  + "_z" + ((int)((Point.name[7])-1-48))) !=null)
            GameObject.Find("x"+Point.name[1] + "_y" + Point.name[4]  + "_z" + ((int)((Point.name[7])-1-48))).GetComponent<Block>().protect = true;
            if(GameObject.Find("x"+Point.name[1] + "_y" + Point.name[4]  + "_z" + ((int)((Point.name[7])+1-48))) !=null)
            GameObject.Find("x"+Point.name[1] + "_y" + Point.name[4]  + "_z" + ((int)((Point.name[7])+1-48))).GetComponent<Block>().protect = true;
            if(GameObject.Find("x"+Point.name[1] + "_y" + Point.name[4]  + "_z" + + Point.name[7]) !=null)
            GameObject.Find("x"+Point.name[1] + "_y" + Point.name[4]  + "_z" + + Point.name[7]).GetComponent<Block>().protect = true;

                                  for (int i= 0; i<  go.Count; i++){

                                                              if (go[i] == null){
                                                              go.Remove(null);
                                                              }}
           for (int i=0; i< go.Count; i++){
           if (go[i].GetComponent<Block>().protect == true){
          // Debug.Log ("removed" + go[i]);
                       go[i]=null;
                         }
            }
                                    for (int i= 0; i<  go.Count; i++){

                                                if (go[i] == null){
                                                go.Remove(null);
                                                }}


           for (int i=0; i< go.Count; i++){
           //Debug.Log("Вошли");
           if (go[i])
            if (go[i].GetComponent<Block>() != null){
           //  Debug.Log("Получили");
                if (go[i].GetComponent<Block>().placed == true){
                // Debug.Log("removed" + go[i]);
                        go[i]=null;

                          }
                }}

                for (int i= 0; i<  go.Count; i++){

                            if (go[i] == null){
                            go.RemoveAt(i);
                            }
                            }
                for (int i=0; i< go.Count; i++){
                if (go[i])
                       go[i].GetComponent<Block>().protect = true;
                }

        randlist.Clear();
        for (int i= 0; i<  go.Count; i++){

                    if (go[i]){
                    randlist.Add(go[i]);
                    }
                    }
        int rand =  Random.Range(0, randlist.Count-1);



        randlist[rand].GetComponent<Block>().placed = true;
         if (Point.name[1] != randlist[rand].name[1])
          {
           if  ((int)Point.name[1]-(int)randlist[rand].name[1] < 0){
                finalx = randlist[rand].name[1] - 49;
           }
           else {
                finalx = randlist[rand].name[1] - 47;
           }
          }
         else{
         finalx = randlist[rand].name[1]-48;
         }
          if (Point.name[4] != randlist[rand].name[4])
           {
            if  ((int)Point.name[4]-(int)randlist[rand].name[4] < 0){
                 finaly = randlist[rand].name[4] - 49;
            }
            else {
                 finaly = randlist[rand].name[4] - 47;
            }
           }
          else{
          finaly = randlist[rand].name[4]-48;
          }
           if (Point.name[7] != randlist[rand].name[7])
            {
             if  ((int)Point.name[7]-(int)randlist[rand].name[7] < 0){
                  finalz = randlist[rand].name[7] - 49;
             }
             else {
                  finalz = randlist[rand].name[7] - 47;
             }
            }
           else{
           finalz = randlist[rand].name[7]-48;
           }
       // Debug.Log(("x" + finalx + "_y" + finaly + "_z" + finalz));
        return GameObject.Find ("x" + finalx + "_y" + finaly + "_z" + finalz);



    }
    public void Stop(){
                 Player.GetComponent<Rigidbody>().useGravity = false;
                        Player.GetComponent<BoxCollider>().isTrigger=true;
                }
    public void Go(){
            Player.GetComponent<Rigidbody>().useGravity = true;
            Player.GetComponent<BoxCollider>().isTrigger = false;
            }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (Input.GetKeyDown(KeyCode.Z)){
        Player.GetComponent<Rigidbody>().useGravity = true;
        Player.GetComponent<BoxCollider>().isTrigger = false;
        }
        if (Input.GetKeyDown(KeyCode.X)){
        Player.GetComponent<Rigidbody>().useGravity = false;
        Player.GetComponent<BoxCollider>().isTrigger=true;}
    }
}
