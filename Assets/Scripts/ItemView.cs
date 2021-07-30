using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private Button _selecionButton;

    private ItemData _itemData;
    
    public event UnityAction<ItemData> ItemSelected;
    public event UnityAction<ItemView> ItemDisabled;

    private void OnEnable()
    {
        _selecionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        ItemDisabled?.Invoke(this);
        _selecionButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        ItemSelected?.Invoke(_itemData);
    }

    public void Initialize(ItemData itemData)
    {
        _itemData = itemData;
        _image.sprite = itemData.Preview;
        _label.text = itemData.Label;
    }
}