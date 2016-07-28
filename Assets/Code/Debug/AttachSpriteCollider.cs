using UnityEngine;
using System.Collections;

public class AttachSpriteCollider : MonoBehaviour {

    public enum Dimension {LANDSCAPE, PORTRAIT, SQUARE };

    public Dimension dimension;

    void Awake()
    {
        BoxCollider bc = this.gameObject.AddComponent<BoxCollider>();

        bc.isTrigger = true;

        switch(dimension)
        {
            case Dimension.LANDSCAPE:
                bc.size = new Vector3(2.56f, 1.28f, 0.1f);
                bc.center = new Vector3(0.0f, 0.32f, 0.0f);
                break;
            case Dimension.PORTRAIT:
                bc.size = new Vector3(1.28f, 2.56f, 0.1f);
                bc.center = new Vector3(0.0f, 0.64f, 0.0f);
                break;
            case Dimension.SQUARE:
                bc.size = new Vector3(2.56f, 2.56f, 0.1f);
                bc.center = new Vector3(0.0f, 0.64f, 0.0f);
                break;
        }
    }
}
