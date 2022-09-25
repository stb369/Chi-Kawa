using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CamRay : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector3 objPosition;
    [SerializeField] GameObject MainCharacter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Camera.main.
                ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0.0f;
            //objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //this.transform.position = objPosition;
            Debug.Log(mousePosition);
            mousePosition = new Vector3(MainCharacter.transform.position.x * (-1),
                            MainCharacter.transform.position.y, MainCharacter.transform.position.z);
            MovetoLocation(MainCharacter, mousePosition);
        }
    }

    public Vector3 GetRayLocation()
    {
        Camera camera = this.GetComponent<Camera>();
        Vector3 origin = camera.transform.position; // 原点
        Vector3 direction = camera.transform.forward; // X軸方向を表すベクトル
        Ray ray = new Ray(origin, direction); // Rayを生成;

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) // もしRayを投射して何らかのコライダーに衝突したら
        {
            direction = hit.transform.position;
        }
        direction = Vector3.zero;
        Debug.Log("押した座標" + direction.ToString());
        return direction;
    }

    public float GetLength(Vector3 a,Vector3 b)
    {
        return Mathf.Sqrt(Mathf.Pow(a.x - b.x,2)+ 
            Mathf.Pow(a.y - b.y, 2)+ Mathf.Pow(a.z - b.z, 2));
    }

    public void MovetoLocation(GameObject character, Vector3 goal)
    {
        //StartCoroutine(MoveCoroutine(character,goal));
        character.transform.DOMove(goal, GetLength
            (character.transform.position, goal));
    }

    public IEnumerator MoveCoroutine(GameObject character, Transform goal , float speed = 10)
    {
        yield return null;
        float time = GetLength
            (character.transform.position,goal.position)/speed;
        float delta = 0;
        while (delta < time)
        {
            delta += Time.deltaTime;
        }

    }

}
