using UnityEngine;
using UnityEngine.Playables;

public class PlayerCam : MonoBehaviour
{

    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    public Transform theCamera;

    public GameObject player;
    public GameObject playerUI;

    public GameObject cutsceneTransition;
    public PlayableDirector playCutscene;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    public void PlayCutscene()
    {
        player.SetActive(false);
        playerUI.SetActive(false);
        cutsceneTransition.SetActive(true);
    }

    public void StopCutscene()
    {
        player.SetActive(true);
        playerUI.SetActive(true);
        cutsceneTransition.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;

        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        transform.position = theCamera.position;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopCutscene();
            playCutscene.Stop();
        }

    }
}
