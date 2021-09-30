using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwipeController : MonoBehaviour
{
    public  bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    public bool isDraging = false;
    public Vector2 startTouch, swipeDelta;
    public GameObject Rotor;
    public float swipeDeltaoldz;
    public float swipeDeltaoldy;
    public float grade;

    public float speed;
    public GameObject player;
    public GameObject button;
    public GameObject trans;
    private bool controled;
    public bool isLabirinth;
    void Start(){
    tap = swipeDown = swipeUp = swipeLeft = swipeRight = false;
    controled = true;}
    IEnumerator TestCoroutine()
    {

    		yield return new WaitForSeconds(1.5f);



    	//	Debug.Log(Time.deltaTime);

    }
    IEnumerator TestCoroutine2()
        {

        		yield return new WaitForSeconds(1.1f);
        		button.GetComponent<Button>().interactable = true;
                 controled = true;

        	//	Debug.Log(Time.deltaTime);

        }
       public void StartIENUM(){
        controled = false;
        StartCoroutine(TestCoroutine2());
       }
    private void Update()
    {

           Rotor.transform.rotation = Quaternion.Slerp(Rotor.transform.rotation, trans.transform.rotation ,  Time.deltaTime * speed);



        #region ПК-версия
        if (Input.GetMouseButtonDown(0))
        {

if (controled){
                Rotor.transform.rotation = trans.transform.rotation;
            tap = true;
            isDraging = true;

            startTouch = Input.mousePosition;}
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion
        #region Мобильная версия
        if (Input.touches.Length > 0)
        {
       if (controled){
                       Rotor.transform.rotation = trans.transform.rotation;
            if (Input.touches[0].phase == TouchPhase.Began)
            {

                tap = true;
                isDraging = true;

                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;

            }}
        }
        #endregion
         if (controled){
        //Просчитать дистанцию
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length < 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        //Проверка на пройденность расстояния
        if (swipeDelta.magnitude > 40)
        {

            //Определение направления
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {

                if (x < 0){
                    swipeLeft = true;



                                     }

                else {


                    swipeRight = true;
            }}
            else
            {

                if (y < 0){
                    swipeDown = true;

                                                                          }
                else{


                    swipeUp = true;}
            }


        }
    }
    }

    private void Reset()
    {

        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;


                        if (swipeDown){

                        swipeDown = false;
                        if (player.GetComponent<Player>().onAir == false){
                                    if (!isLabirinth)
                       Rotor.GetComponent<Generation>().Stop();
                            else
                           Rotor.GetComponent<Generation2>().Stop();

                        trans.transform.rotation = Rotor.transform.rotation;
                         trans.transform.Rotate((int)-90,(int)0, (int)0,Space.World);

                         }}
                       if (swipeLeft){
                           swipeLeft = false;

                        if (player.GetComponent<Player>().onAir == false){
                        if (!isLabirinth)
                        Rotor.GetComponent<Generation>().Stop();
                        else
                        Rotor.GetComponent<Generation2>().Stop();
                        trans.transform.rotation = Rotor.transform.rotation;
                        trans.transform.Rotate((int)0, (int)90, (int)0,Space.World);

                        }
                         }
                        if (swipeRight){
                        swipeRight = false;
                        if (player.GetComponent<Player>().onAir == false){
                        if (!isLabirinth)
                        Rotor.GetComponent<Generation>().Stop();
                            else
                           Rotor.GetComponent<Generation2>().Stop();
                         trans.transform.rotation = Rotor.transform.rotation;
                         trans.transform.Rotate((int)0, (int)-90, (int)0,Space.World);

                         }}
                        if (swipeUp){
                        swipeUp = false;
                         if (player.GetComponent<Player>().onAir == false){
                         if (!isLabirinth)
                        Rotor.GetComponent<Generation>().Stop();
                           else
                           Rotor.GetComponent<Generation2>().Stop();
                         trans.transform.rotation = Rotor.transform.rotation;
                         trans.transform.Rotate((int)90,(int)0, (int)0,Space.World);



}
                         }

StartCoroutine(TestCoroutine());
                }

}