using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MoleState { UnderGround = 0, OnGround, MoveUp, MoveDown}

public class MoleFSM : MonoBehaviour
{
   [SerializeField]
   private float waitTimeOnGround;// 지면에 올라와서 내려가기까지 기다리는 시간

   [SerializeField]
   private float limitMinY;

   [SerializeField]
   private float limitMaxY;

   public MoveMent3D movement3D;  // 위 아래 이동을 위한 Movement 3D

// 두더지의 현재 상태(set은 MoleFSM 클래스 내부에서만)
   public MoleState MoleState {private set; get;}

   private void Awake() 
   {
       movement3D = GetComponent<MoveMent3D>();

       ChangeState(MoleState.UnderGround);   

   }

   public void ChangeState(MoleState newState){
       // 열거형 변수를 ToString() 메소드를 이용해 문자열로 변환하면
       // "UnderGround"와 같이 열거형 요소 이름 변환

       //이전에 재생중이던 상태 종료
       StopCoroutine(MoleState.ToString());

       //상태 변경
       MoleState = newState;

       //새로운 상태 재생
       StartCoroutine(MoleState.ToString());

   }

   // 두더지가 바닥에서 대기하는 상태로 최초에 바닥 위치로 두더지 위치 설정

   private IEnumerator UnderGround()
   {
       // 정지
       movement3D.MoveTo(Vector3.zero);

       transform.position = new Vector3(transform.position.x, limitMinY, transform.position.z);
       
       yield return null;

   }

   // 두더지가 홀 밖으로 나와있는 상태로 waitTimeonGround동안 대기
   private IEnumerator OnGround()
   {
       movement3D.MoveTo(Vector3.zero);
       //두더지의 y위치를 홀에 숨어 있는 limitMinY 위치로 설정
       transform.position = new Vector3(transform.position.x, limitMaxY, transform.position.z);

       //waitTimeOnGround 시간동안 대기
       yield return new WaitForSeconds(waitTimeOnGround);

       //두더지 상태를 MoveDown으로 변경
       ChangeState(MoleState.MoveDown);
   }


   //두더지가 밖으로 나오는 상태
   private IEnumerator MoveUp()
   {
       //이동방향 : y = 1로 [위]
       movement3D.MoveTo(Vector3.up);

       while (true)
       {
           //두더지의 y위치가 limitMaxY에 도달하면 상태 변경
           if (transform.position.y >= limitMaxY){

               //onGround 상태로 변경
               ChangeState(MoleState.OnGround);
           }
           yield return null;
       }

   }

   //두더지가 홀로 들어가는 상태
    private IEnumerator MoveDown()
   {
       //이동방향 : y = 1로 [위]
       movement3D.MoveTo(Vector3.down);

       while (true)
       {
           //두더지의 y위치가 limitMinY에 도달하면 반복문 중지
           if (transform.position.y <= limitMinY){

               //onGround 상태로 변경
               ChangeState(MoleState.UnderGround);
           }
           yield return null;
       }

   }




}
