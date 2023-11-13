/*
 * day : 2023-09-13
 * write : phantom
 * email : chho1365@gmail.com
 */

using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Phantom
{
    [RequireComponent(typeof(ScrollRect))]
    [RequireComponent(typeof(EventTrigger))]
    public class UIScroll : UIBehaviour, IDragHandler
    {

        #region Component

        private ScrollRect _scrollRect;
        
        #endregion



        private enum Direction
        {
            Vertical = 1,
            Horizontal = 2
        }
        
        #region Variable
        
        private Direction _direction;

        public bool isFix;

        public bool isScroll;
        
        #endregion
        
        

        #region Lifecycle

        protected override void Start ()
        {
            _scrollRect = GetComponent<ScrollRect>();
            _scrollRect.onValueChanged.AddListener(OnValueChange);
            
            if (!_scrollRect.vertical && _scrollRect.horizontal)
                _direction = Direction.Vertical;
            else if (_scrollRect.vertical && !_scrollRect.horizontal)
                _direction = Direction.Horizontal;
        }

        #endregion



        #region Event

        private void OnValueChange(Vector2 value)
        {
            if (isFix)
            {
                if (_direction == Direction.Vertical)
                {
                    if (value.x > 1)
                        _scrollRect.horizontalNormalizedPosition = 1;
                    else if(value.x < 0)
                        _scrollRect.horizontalNormalizedPosition = 0;
                }
                else
                {
                    if (value.y > 1)
                        _scrollRect.verticalNormalizedPosition = 1;
                    else if (value.y < 0)
                        _scrollRect.verticalNormalizedPosition = 0;   
                }
            }
        }

        #endregion



        #region Callback
        
        public void OnDrag(PointerEventData eventData)
        {
            isScroll = false;
        }

        #endregion

        

        #region Method

        public void AutoScroll()
        {
            StartCoroutine(AutoScrollAsync());
        }

        IEnumerator AutoScrollAsync()
        {
            isScroll = true;
            while (isScroll)
            {
                if (_direction == Direction.Vertical)
                {
                    _scrollRect.horizontalNormalizedPosition += Time.deltaTime * 0.1f;
                    if (_scrollRect.horizontalNormalizedPosition > 1)
                    {
                        isScroll = false;
                    }
                }
                else
                {
                    _scrollRect.verticalNormalizedPosition -= Time.deltaTime * 0.1f;
                    if (_scrollRect.verticalNormalizedPosition <= 0)
                    {
                        isScroll = false;
                    }
                }

                yield return null;
            }
        }

        #endregion
        
    }
}