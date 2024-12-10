using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageSlideshow : MonoBehaviour
{
    [SerializeField] private Image displayImage;
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Sprite[] images;
    [SerializeField] private bool enableLooping = false;
    [SerializeField] private float buttonScaleEffect = 0.9f;
    
    private int currentImageIndex = 0;
    private Vector3 originalButtonScale;

    private void Start()
    {
        // Initialize buttons
        previousButton.onClick.AddListener(ShowPreviousImage);
        nextButton.onClick.AddListener(ShowNextImage);
        
        // Store original button scale
        originalButtonScale = previousButton.transform.localScale;
        
        // Add button press effects
        AddButtonEffects(previousButton);
        AddButtonEffects(nextButton);
        
        // Show first image
        if (images.Length > 0)
        {
            displayImage.sprite = images[0];
        }
        
        UpdateButtonStates();
    }

    private void AddButtonEffects(Button button)
    {
        EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();
        
        // Down effect
        EventTrigger.Entry pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener((data) => {
            button.transform.localScale = originalButtonScale * buttonScaleEffect;
        });
        trigger.triggers.Add(pointerDown);
        
        // Up effect
        EventTrigger.Entry pointerUp = new EventTrigger.Entry();
        pointerUp.eventID = EventTriggerType.PointerUp;
        pointerUp.callback.AddListener((data) => {
            button.transform.localScale = originalButtonScale;
        });
        trigger.triggers.Add(pointerUp);
    }

    private void ShowNextImage()
    {
        if (currentImageIndex < images.Length - 1)
        {
            currentImageIndex++;
        }
        else if (enableLooping)
        {
            currentImageIndex = 0;
        }
        
        displayImage.sprite = images[currentImageIndex];
        UpdateButtonStates();
    }

    private void ShowPreviousImage()
    {
        if (currentImageIndex > 0)
        {
            currentImageIndex--;
        }
        else if (enableLooping)
        {
            currentImageIndex = images.Length - 1;
        }
        
        displayImage.sprite = images[currentImageIndex];
        UpdateButtonStates();
    }

    private void UpdateButtonStates()
    {
        if (enableLooping)
        {
            previousButton.interactable = true;
            nextButton.interactable = true;
        }
        else
        {
            previousButton.interactable = currentImageIndex > 0;
            nextButton.interactable = currentImageIndex < images.Length - 1;
        }
    }
}