using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public bool isMoving = false;
    Hero hero;
    public List<Image> path;
    private int totalSteps;
    private int currentStep;
    Vector3 targetPos;
    float speedOfAnim = 2f;
    internal bool lookingToTheRight = true;
    SpriteRenderer heroSprite;

    private void Start()
    {
        hero = GetComponent<Hero>();
        heroSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isMoving)
        {
            HeroIsMoving();
        }
    }

    public void StartsMoving()
    {
        currentStep = 0;
        totalSteps = path.Count - 1;
        isMoving = true;
        hero.GetComponent<Animator>().SetBool("IsMoving", true);
        ResetTargetPos();
    }

    void ResetTargetPos()
    {
        targetPos = new Vector3(path[currentStep].transform.position.x, path[currentStep].transform.position.y, transform.position.z);
    }

    void HeroIsMoving()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speedOfAnim * Time.deltaTime);
        ManageSteps();
    }

    void ManageSteps()
    {
        if (Vector3.Distance(transform.position, targetPos) < 0.1f && currentStep < totalSteps)
        {
            currentStep++;
            ResetTargetPos();
        }
        else if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            StopMoving();
        }
    }

    void StopMoving()
    {
        isMoving = !isMoving;
        hero.GetComponent<Animator>().SetBool("IsMoving", false);
    }

    internal void ControlDirection(Vector3 targetPos)
    {
        if (transform.position.x > targetPos.x && lookingToTheRight || transform.position.x < targetPos.x && !lookingToTheRight)
        {
            heroSprite.flipX = !heroSprite.flipX;
            lookingToTheRight = !lookingToTheRight;
        }
    }
}
