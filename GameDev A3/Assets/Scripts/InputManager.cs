using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject pacman;
    private Tweener tweener;
    private Vector3 PosA;
    private Vector3 PosB;
    private Vector3 PosC;
    private Vector3 PosD;
    void Start()
    {
        PosA = new Vector3(1.0f, 13.0f, -1.0f);
        PosB = new Vector3(12.0f, 13.0f, -1.0f);
        PosC = new Vector3(1.0f, 9.0f, -1.0f);
        PosD = new Vector3(12.0f, 9.0f, -1.0f);

        tweener = GetComponent<Tweener>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(pacman.transform.position, PosA) <= 0.1f)
        {
            tweener.AddTween(pacman.transform, pacman.transform.position, PosB, 2.0f);
            pacman.transform.rotation = Quaternion.identity;
            pacman.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else if (Vector3.Distance(pacman.transform.position, PosB) <= 0.1f)
        {
            tweener.AddTween(pacman.transform, pacman.transform.position, PosD, 1.0f);
            pacman.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
            pacman.transform.localScale = new Vector3(-1.0f, -1.0f, 0.0f);
        }

        else if (Vector3.Distance(pacman.transform.position, PosD) <= 0.1f)
        {
            tweener.AddTween(pacman.transform, pacman.transform.position, PosC, 2.0f);
            pacman.transform.rotation = Quaternion.identity;
            pacman.transform.localScale = new Vector3(-1.0f, 1.0f, 0.0f);
        }

        else if (Vector3.Distance(pacman.transform.position, PosC) <= 0.1f)
        {
            tweener.AddTween(pacman.transform, pacman.transform.position, PosA, 1.0f);
            pacman.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
            pacman.transform.localScale = new Vector3(1.0f, -1.0f, 0.0f);
        }
    }
}
