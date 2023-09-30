using UnityEngine ;
using UnityEngine.UI ;
using DG.Tweening ;

public class SwitchToggle : MonoBehaviour 
{
   [SerializeField] private RectTransform uiHandleRectTransform;
   [SerializeField] private Color backgroundActiveColor;
   [SerializeField] private Color backgroundInactiveColor;
   [SerializeField] private Color handleActiveColor;
   [SerializeField] private Color handleInactiveColor;

   private Image backgroundImage, handleImage;

   private Toggle toggle;

   private Vector2 handlePosition;

   private void Awake ( ) 
   {
     toggle = GetComponent <Toggle> ( );

     handlePosition = uiHandleRectTransform.anchoredPosition;

     backgroundImage = uiHandleRectTransform.parent.GetComponent <Image> ( );
     handleImage = uiHandleRectTransform.GetComponent <Image> ( );

     toggle.onValueChanged.AddListener (OnSwitch);

     if (toggle.isOn)
        OnSwitch (true);
   }

   private void OnSwitch (bool on) 
   {
      //uiHandleRectTransform.anchoredPosition = on ? handlePosition * -1 : handlePosition ; // no anim
      uiHandleRectTransform.DOAnchorPos (on ? handlePosition * -1 : handlePosition, .4f).SetEase (Ease.InOutBack).SetUpdate(UpdateType.Normal, true);

      //backgroundImage.color = on ? backgroundActiveColor : backgroundInactiveColor ; // no anim
      backgroundImage.DOColor (on ? backgroundActiveColor : backgroundInactiveColor, .6f).SetUpdate(UpdateType.Normal, true);

      //handleImage.color = on ? handleActiveColor : handleInactiveColor ; // no anim
      handleImage.DOColor (on ? handleActiveColor : handleInactiveColor, .4f).SetUpdate(UpdateType.Normal, true);
   }

   private void OnDestroy ( ) 
   {
     toggle.onValueChanged.RemoveListener (OnSwitch);
   }
}
