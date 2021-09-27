using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public  bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    public bool isDraging = false;
    public Vector2 startTouch, swipeDelta;
    public GameObject Rotor;
    public float swipeDeltaoldz;
    public float swipeDeltaoldy;
    public float grade;
    public bool active;
    public float speed;
    public GameObject trans;
    void Start(){
    tap = swipeDown = swipeUp = swipeLeft = swipeRight = false;}

    IEnumerator TestCoroutine()
    {

    		yield return new WaitForSeconds(1.5f);
    		active = false;
    		 Rotor.transform.rotation = trans.transform.rotation;
    		Debug.Log(Time.deltaTime);

    }
    private void Update()
    {
        if (active){
           Rotor.transform.rotation = Quaternion.Slerp(Rotor.transform.rotation, trans.transform.rotation ,  Time.deltaTime * speed);


        }


        #region ПК-версия
        if (Input.GetMouseButtonDown(0))
        {
 if (!active){

            tap = true;
            isDraging = true;

            startTouch = Input.mousePosition;
        }}
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion
        #region Мобильная версия
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                if (!active){
                tap = true;
                isDraging = true;

                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;

            }
        }
        #endregion

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

    private void Reset()
    {

        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;


                        if (swipeDown){
                        swipeDown = false;
                        trans.transform.rotation = Rotor.transform.rotation;
                         trans.transform.Rotate((int)-90,(int)0, (int)0,Space.World);
                         active = true;

                         }




                       if (swipeLeft){
                       swipeLeft = false;
                       trans.transform.rotation = Rotor.transform.rotation;
                        trans.transform.Rotate((int)0, (int)90, (int)0,Space.World);
                        active = true;
                         }
                        if (swipeRight){
                        swipeRight = false;
                         trans.transform.rotation = Rotor.transform.rotation;
                         trans.transform.Rotate((int)0, (int)-90, (int)0,Space.World);
                         active = true;}
                        if (swipeUp){
                         trans.transform.rotation = Rotor.transform.rotation;
                                                 trans.transform.Rotate((int)90,(int)0, (int)0,Space.World);
                                                 active = true;
                        swipeUp = false;

                         }
StartCoroutine(TestCoroutine());
                }

}