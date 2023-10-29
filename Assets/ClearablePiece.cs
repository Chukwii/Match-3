using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearablePiece : MonoBehaviour
{
    public AnimationClip clearAnimation;

    private bool isBeingCleard = false;

    public bool IsBeingCleard
    {
        get { return isBeingCleard; }
    }

    protected GamePiece piece;

    private void Awake()
    {
        piece = GetComponent<GamePiece>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Clear()
    {
        piece.GridRef.level.OnPieceCleared(piece);

        isBeingCleard = true;
        StartCoroutine(ClearCouroutine());
    }

    private IEnumerator ClearCouroutine()
    {
        Animator animator = GetComponent<Animator>();

        if (animator)
        {
            animator.Play(clearAnimation.name);

            yield return new WaitForSeconds(clearAnimation.length);
            Destroy(this.gameObject);
        }
    }
}
