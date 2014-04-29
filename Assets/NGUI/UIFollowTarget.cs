//--------------------------------------------
//            NGUI: HUD Text
// Copyright © 2012 Tasharen Entertainment
//--------------------------------------------

using UnityEngine;

/// <summary>
/// Attaching this script to an object will make it visibly follow another object, even if the two are using different cameras to draw them.
/// </summary>

//[AddComponentMenu("NGUI/Examples/Follow Target")]
public class UIFollowTarget : MonoBehaviour
{
    /// <summary>
    /// 3D target that this object will be positioned above.
    /// </summary>

    public Transform target;

    /// <summary>
    /// Whether the children will be disabled when this object is no longer visible.
    /// </summary>

    public bool disableIfInvisible = true;

    Transform mTrans;
    Camera mGameCamera;
    Camera mUICamera;
    bool mIsVisible = false;

    /// <summary>
    /// Cache the transform;
    /// </summary>

    void Awake () { mTrans = transform; }

    /// <summary>
    /// Find both the UI camera and the game camera so they can be used for the position calculations
    /// </summary>

    void Start()
    {
        if (target != null)
        {
            //mGameCamera = NGUITools.FindCameraForLayer(target.gameObject.layer);
            mGameCamera = Camera.main;
            mUICamera = NGUITools.FindCameraForLayer(gameObject.layer);
            SetVisible(false);
        }
        else
        {
            Debug.LogError("Expected to have 'target' set to a valid transform", this);
            enabled = false;
        }
    }

    /// <summary>
    /// Enable or disable child objects.
    /// </summary>

    void SetVisible (bool val)
    {
        mIsVisible = val;

        // FIXME 
        //for (int i = 0, imax = mTrans.childCount; i < imax; ++i)
        //{
        //    NGUITools.SetActive(mTrans.GetChild(i).gameObject, val);
        //}
    }

    /// <summary>
    /// Update the position of the HUD object every frame such that is position correctly over top of its real world object.
    /// </summary>

    void Update ()
    {
        Vector3 pos = Vector3.zero;

//        if (target.tag == "NPC" || target.tag == "Player") {
//            Vector3 tempPos;
//            if (SmoothFollow.getInstance().mode == SmoothFollow.CAMERA_MODE.ZOOM) {
//                tempPos = new Vector3(target.transform.position.x, target.transform.position.y + target.GetComponent<CapsuleCollider>().height * 1.1f, target.transform.position.z);
//            } else {
//                tempPos = new Vector3(target.transform.position.x, target.transform.position.y + target.GetComponent<CapsuleCollider>().height * 1.45f, target.transform.position.z);
//            }
//            pos = mGameCamera.WorldToViewportPoint(tempPos);
//        }
        //Vector3 pos = mGameCamera.WorldToViewportPoint(target.position);
        
        // Determine the visibility and the target alpha
        bool isVisible = (pos.z > 0f && pos.x > 0f && pos.x < 1f && pos.y > 0f && pos.y < 1f);

        // Update the visibility flag
        if (disableIfInvisible && mIsVisible != isVisible) SetVisible(isVisible);

        // If visible, update the position
        if (isVisible)
        {
            transform.position = Vector3.Lerp(transform.position, mUICamera.ViewportToWorldPoint(pos), 0.8f);
            //transform.position = mUICamera.ViewportToWorldPoint(pos);
            pos = mTrans.localPosition;
            pos.x = Mathf.RoundToInt(pos.x);
            pos.y = Mathf.RoundToInt(pos.y);
            pos.z = 0f;
            //mTrans.localPosition = pos;

            //mTrans.localPosition = Vector3.Lerp(mTrans.localPosition, pos, 0.2f);
        }
    }
}
