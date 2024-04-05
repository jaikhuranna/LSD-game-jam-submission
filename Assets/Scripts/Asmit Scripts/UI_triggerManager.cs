using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class UI_triggerManager : MonoBehaviour
{
    public Collider uiTriggerbc;
    
    public GameObject alphabetsPrefab;
    public GameObject alphabetsInstance;
    private Camera mainCamera;
    public Canvas canvasObjective;
    public TextMeshProUGUI objectiveText;
    
    private int counter = 0;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        counter++;
    }

    private void Update()
    {
        if (counter == 2)
        {
            // float letterScale = 0.05f;
            // alphabets.transform.localScale = new Vector3(letterScale, letterScale, letterScale);
            // // Activate the alphabets game object
            // // alphabets.transform.localScale = new Vector3(textSize.x, textSize.y, 1f);
            // canvasObjective.enabled = false;
            //
            // // Calculate the top-left corner of the screen in viewport space
            // Vector3 topLeftCornerViewport = new Vector3(0.05f, 0.92f, 5f); // Adjust the values as needed
            //
            // // Convert the viewport position to world space
            // Vector3 worldPosition = mainCamera.ViewportToWorldPoint(topLeftCornerViewport);
            // // Set the position of the alphabets game object to the calculated world position
            // alphabets.transform.position = worldPosition;

            // Hide the Canvas text
            // canvasObjective.enabled = false;
            
            Vector2 textSize = objectiveText.GetPreferredValues();

            // Get the position of the Canvas text in screen space
            Vector3 screenPos = mainCamera.WorldToScreenPoint(objectiveText.transform.position);

            // Convert screen position to world space
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, mainCamera.nearClipPlane + 1f));

            // Instantiate the 3D text if it doesn't exist
            if (alphabetsInstance == null)
            {
                alphabetsInstance = Instantiate(alphabetsPrefab, worldPos, Quaternion.identity);
            }

            // Set the content of the 3D text to match the Canvas text
            alphabetsInstance.GetComponent<TextMeshPro>().text = objectiveText.text;

            // Set the size of the 3D text to match the Canvas text size
            alphabetsInstance.transform.localScale = new Vector3(textSize.x, textSize.y, 1f);

            // Hide the Canvas text
            canvasObjective.enabled = false;
        }
    }
}