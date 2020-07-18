using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

/// <summary>
/// PropertyAnimator is created to update properties of instances (mostly components)
/// Supported property type:
///     float
///     Vector2Float
///     Vector3Float
///     int
///     Vector2Int
///     Vector3Int
/// Note:
///     Now only support the most basic functions. 
/// </summary>

//TODO: Use resource pool for further optimization
//TODO: Construct thread safety
namespace MyFramework
{
    public class PropertyAnimationManager:Singleton<PropertyAnimationManager>, IManager
    {
        public enum EndPropertyState
        {
            Src,
            Targ,
            Keep
        }

        private List<PropertyUpdater<float>> updatersFloat = new List<PropertyUpdater<float>>();
        private List<PropertyUpdater<Vector2>> updatersVector2 = new List<PropertyUpdater<Vector2>>();
        private List<PropertyUpdater<Vector3>> updatersVector3 = new List<PropertyUpdater<Vector3>>();
        private List<PropertyUpdater<int>> updatersInt = new List<PropertyUpdater<int>>();
        private List<PropertyUpdater<Vector2Int>> updatersVector2Int = new List<PropertyUpdater<Vector2Int>>();
        private List<PropertyUpdater<Vector3Int>> updatersVector3Int = new List<PropertyUpdater<Vector3Int>>();

        public void Awake()
        {
            
        }

        public void Start()
        {
            
        }

        public void FixedUpdate()
        {
            
        }

        public void Update()
        {
            for (int i = updatersFloat.Count - 1; i >= 0; i--)
            {
                updatersFloat[i].Update();
            }
            for (int i = updatersVector2.Count - 1; i >= 0; i--)
            {
                updatersVector2[i].Update();
            }
            for (int i = updatersVector3.Count - 1; i >= 0; i--)
            {
                updatersVector3[i].Update();
            }
            for (int i = updatersInt.Count - 1; i >= 0; i--)
            {
                updatersInt[i].Update();
            }
            for (int i = updatersVector2Int.Count - 1; i >= 0; i--)
            {
                updatersVector2Int[i].Update();
            }
            for (int i = updatersVector3Int.Count - 1; i >= 0; i--)
            {
                updatersVector3Int[i].Update();
            }
        }

        public void LateUpdate()
        {
            
        }

        public void Destroy()
        {
            
        }

        //TODO: 构造 开始，暂停，继续，停止  对应事件

        #region StartAnimatingProperty
        /// <summary>
        /// Begin to animate a property of an object. Assign callbacks for Start, Pause, Resume, End. 
        /// </summary>
        /// <param name="component">Object containing the prop</param>
        /// <param name="strProp">Prop in string</param>
        /// <param name="src">Start value</param>
        /// <param name="targ">End value</param>
        /// <param name="durTime">Duration</param>
        /// <param name="callbacksStart">Callbacks for Start</param>
        /// <param name="callbacksPause">Callbacks for Pause</param>
        /// <param name="callbacksResume">Callbacks for Resume</param>
        /// <param name="callbacksEnd">Callbacks for End</param>
        /// <returns>PropertyUpdater if successful. Null else.</returns>
        public PropertyUpdater<float> StartAnimatingPropertyFloat(object component, string strProp, Action<float> setter, Func<float> getter, float src, float targ, float durTime,
            Action callbacksStart,
            Action callbacksPause,
            Action callbacksResume,
            Action<EndPropertyState> callbacksEnd)
        {
            return StartAnimatingProperty<float>(updatersFloat, component, strProp, setter, getter, src, targ, durTime, PropertyUpdater<float>.GetValAtUpdateFloat, callbacksStart, callbacksPause, callbacksResume, callbacksEnd);
        }
        public PropertyUpdater<Vector2> StartAnimatingPropertyVector2(object component, string strProp, Action<Vector2> setter, Func<Vector2> getter, Vector2 src, Vector2 targ, float durTime,
            Action callbacksStart,
            Action callbacksPause,
            Action callbacksResume,
            Action<EndPropertyState> callbacksEnd)
        {
            return StartAnimatingProperty<Vector2>(updatersVector2, component, strProp, setter, getter, src, targ, durTime, PropertyUpdater<float>.GetValAtUpdateVector2, callbacksStart, callbacksPause, callbacksResume, callbacksEnd);
        }
        public PropertyUpdater<Vector3> StartAnimatingPropertyVector3(object component, string strProp, Action<Vector3> setter, Func<Vector3> getter, Vector3 src, Vector3 targ, float durTime,
            Action callbacksStart,
            Action callbacksPause,
            Action callbacksResume,
            Action<EndPropertyState> callbacksEnd)
        {
            return StartAnimatingProperty<Vector3>(updatersVector3, component, strProp, setter, getter, src, targ, durTime, PropertyUpdater<float>.GetValAtUpdateVector3, callbacksStart, callbacksPause, callbacksResume, callbacksEnd);
        }
        public PropertyUpdater<int> StartAnimatingPropertyInt(object component, string strProp, Action<int> setter, Func<int> getter, int src, int targ, float durTime,
            Action callbacksStart,
            Action callbacksPause,
            Action callbacksResume,
            Action<EndPropertyState> callbacksEnd)
        {
            return StartAnimatingProperty<int>(updatersInt, component, strProp, setter, getter, src, targ, durTime, PropertyUpdater<int>.GetValAtUpdateInt, callbacksStart, callbacksPause, callbacksResume, callbacksEnd);
        }
        public PropertyUpdater<Vector2Int> StartAnimatingPropertyVector2Int(object component, string strProp, Action<Vector2Int> setter, Func<Vector2Int> getter, Vector2Int src, Vector2Int targ, float durTime,
            Action callbacksStart,
            Action callbacksPause,
            Action callbacksResume,
            Action<EndPropertyState> callbacksEnd)
        {
            return StartAnimatingProperty<Vector2Int>(updatersVector2Int, component, strProp, setter, getter, src, targ, durTime, PropertyUpdater<Vector2Int>.GetValAtUpdateVector2Int, callbacksStart, callbacksPause, callbacksResume, callbacksEnd);
        }
        private PropertyUpdater<Vector3Int> StartAnimatingPropertyVector3Int(object component, string strProp, Action<Vector3Int> setter, Func<Vector3Int> getter, Vector3Int src, Vector3Int targ, float durTime,
            Action callbacksStart,
            Action callbacksPause,
            Action callbacksResume,
            Action<EndPropertyState> callbacksEnd)
        {
            return StartAnimatingProperty<Vector3Int>(updatersVector3Int, component, strProp, setter, getter, src, targ, durTime, PropertyUpdater<Vector3Int>.GetValAtUpdateVector3Int, callbacksStart, callbacksPause, callbacksResume, callbacksEnd);
        }
        private PropertyUpdater<T> StartAnimatingProperty<T>(List<PropertyUpdater<T>> updaters, object component, string strProp, Action<T> setter, Func<T> getter, T src, T targ, float durTime,
            PropertyUpdater<T>.GetValAtUpdate getValAtUpdate,
            Action callbacksStart,
            Action callbacksPause,
            Action callbacksResume,
            Action<EndPropertyState> callbacksEnd)
        {
            if (FindAnimatingProperty<T>(updaters, component, strProp) != null)
            {
                Debug.LogWarning("Property is already in animating.");
                return null;
            }
            PropertyWrapper<T> wrapper = new PropertyWrapper<T>(component, strProp, setter, getter);
            PropertyUpdater<T> updater = null;
            callbacksEnd += (x) => { updaters.Remove(updater); };
            updater = new PropertyUpdater<T>(wrapper, src, targ, durTime, getValAtUpdate,
                callbacksStart, callbacksPause, callbacksResume, callbacksEnd);
            updaters.Add(updater);
            updater.Start();
            return updater;
        }

        /// <summary>
        /// Begin to animate a property of an object
        /// </summary>
        /// <param name="component">Object containing the prop</param>
        /// <param name="strProp">Prop in string</param>
        /// <param name="setter"></param>
        /// <param name="getter"></param>
        /// <param name="src">Start value</param>
        /// <param name="targ">End value</param>
        /// <param name="durTime">Duration</param>
        /// <returns>PropertyUpdater if successful. Null else.</returns>
        public PropertyUpdater<float> StartAnimatingPropertyFloat(object component, string strProp, Action<float> setter, Func<float> getter, float src, float targ, float durTime)
        {
            return StartAnimatingProperty<float>(updatersFloat, component, strProp, setter, getter, src, targ, durTime, PropertyUpdater<float>.GetValAtUpdateFloat);
        }
        public PropertyUpdater<Vector2> StartAnimatingPropertyVector2(object component, string strProp, Action<Vector2> setter, Func<Vector2> getter, Vector2 src, Vector2 targ, float durTime)
        {
            return StartAnimatingProperty<Vector2>(updatersVector2, component, strProp, setter, getter, src, targ, durTime, PropertyUpdater<float>.GetValAtUpdateVector2);
        }
        public PropertyUpdater<Vector3> StartAnimatingPropertyVector3(object component, string strProp, Action<Vector3> setter, Func<Vector3> getter, Vector3 src, Vector3 targ, float durTime)
        {
            return StartAnimatingProperty<Vector3>(updatersVector3, component, strProp, setter, getter, src, targ, durTime, PropertyUpdater<float>.GetValAtUpdateVector3);
        }
        public PropertyUpdater<int> StartAnimatingPropertyInt(object component, string strProp, Action<int> setter, Func<int> getter, int src, int targ, float durTime)
        {
            return StartAnimatingProperty<int>(updatersInt, component, strProp, setter, getter, src, targ, durTime, PropertyUpdater<int>.GetValAtUpdateInt);
        }
        public PropertyUpdater<Vector2Int> StartAnimatingPropertyVector2Int(object component, string strProp, Action<Vector2Int> setter, Func<Vector2Int> getter, Vector2Int src, Vector2Int targ, float durTime)
        {
            return StartAnimatingProperty<Vector2Int>(updatersVector2Int, component, strProp, setter, getter, src, targ, durTime, PropertyUpdater<Vector2Int>.GetValAtUpdateVector2Int);
        }
        public PropertyUpdater<Vector3Int> StartAnimatingPropertyVector3Int(object component, string strProp, Action<Vector3Int> setter, Func<Vector3Int> getter, Vector3Int src, Vector3Int targ, float durTime)
        {
            return StartAnimatingProperty<Vector3Int>(updatersVector3Int, component, strProp, setter, getter, src, targ, durTime, PropertyUpdater<Vector3Int>.GetValAtUpdateVector3Int);
        }

        private PropertyUpdater<T> StartAnimatingProperty<T>(List<PropertyUpdater<T>> updaters, object component, string strProp, Action<T> setter, Func<T> getter, T src, T targ, float durTime, PropertyUpdater<T>.GetValAtUpdate getValAtUpdate)
        {
            return StartAnimatingProperty<T>(updaters, component, strProp, setter, getter, src, targ, durTime, getValAtUpdate, null, null, null, null);
        }
        #endregion

        #region PauseAnimatingProperty
        /// <summary>
        /// Pause animating the property
        /// </summary>
        /// <param name="component">Object containing the prop</param>
        /// <param name="strProp">Prop in string</param>
        /// <returns>Is successful?</returns>
        public bool PauseAnimatingPropertyFloat(object component, string strProp)
        {
            return PauseAnimatingProperty<float>(updatersFloat, component, strProp);
        }
        public bool PauseAnimatingPropertyVector2(object component, string strProp)
        {
            return PauseAnimatingProperty<Vector2>(updatersVector2, component, strProp);
        }
        public bool PauseAnimatingPropertyVector3(object component, string strProp)
        {
            return PauseAnimatingProperty<Vector3>(updatersVector3, component, strProp);
        }
        public bool PauseAnimatingPropertyInt(object component, string strProp)
        {
            return PauseAnimatingProperty<int>(updatersInt, component, strProp);
        }
        public bool PauseAnimatingPropertyVector2Int(object component, string strProp)
        {
            return PauseAnimatingProperty<Vector2Int>(updatersVector2Int, component, strProp);
        }
        public bool PauseAnimatingPropertyVector3Int(object component, string strProp)
        {
            return PauseAnimatingProperty<Vector3Int>(updatersVector3Int, component, strProp);
        }

        private bool PauseAnimatingProperty<T>(List<PropertyUpdater<T>> updaters, object component, string strProp)
        {
            PropertyUpdater<T> updater = FindAnimatingProperty<T>(updaters, component, strProp);
            if (updater == null)
                return false;
            updater.Pause();
            return true;
        }
        #endregion

        #region ResumeAnimatingProperty
        /// <summary>
        /// Resume animating the property
        /// </summary>
        /// <param name="component">Object containing the prop</param>
        /// <param name="strProp">Prop in string</param>
        /// <returns>Is successful?</returns>
        public bool ResumeAnimatingPropertyFloat(object component, string strProp)
        {
            return ResumeAnimatingProperty<float>(updatersFloat, component, strProp);
        }
        public bool ResumeAnimatingPropertyVector2(object component, string strProp)
        {
            return ResumeAnimatingProperty<Vector2>(updatersVector2, component, strProp);
        }
        public bool ResumeAnimatingPropertyVector3(object component, string strProp)
        {
            return ResumeAnimatingProperty<Vector3>(updatersVector3, component, strProp);
        }
        public bool ResumeAnimatingPropertyInt(object component, string strProp)
        {
            return ResumeAnimatingProperty<int>(updatersInt, component, strProp);
        }
        public bool ResumeAnimatingPropertyVector2Int(object component, string strProp)
        {
            return ResumeAnimatingProperty<Vector2Int>(updatersVector2Int, component, strProp);
        }
        public bool ResumeAnimatingPropertyVector3Int(object component, string strProp)
        {
            return ResumeAnimatingProperty<Vector3Int>(updatersVector3Int, component, strProp);
        }

        private bool ResumeAnimatingProperty<T>(List<PropertyUpdater<T>> updaters, object component, string strProp)
        {
            PropertyUpdater<T> updater = FindAnimatingProperty<T>(updaters, component, strProp);
            if (updater == null)
                return false;
            updater.Resume();
            return true;
        }
        #endregion

        #region EndAnimatingProperty
        /// <summary>
        /// 
        /// </summary>
        /// <param name="component">Object containing the prop</param>
        /// <param name="strProp">Prop in string</param>
        /// <param name="endState">Set the state of property value when animating ended</param>
        /// <returns>Is successful?</returns>
        public bool EndAnimatingPropertyFloat(object component, string strProp, EndPropertyState endState)
        {
            return EndAnimatingProperty<float>(updatersFloat, component, strProp, endState);
        }
        public bool EndAnimatingPropertyVector2(object component, string strProp, EndPropertyState endState)
        {
            return EndAnimatingProperty<Vector2>(updatersVector2, component, strProp, endState);
        }
        public bool EndAnimatingPropertyVector3(object component, string strProp, EndPropertyState endState)
        {
            return EndAnimatingProperty<Vector3>(updatersVector3, component, strProp, endState);
        }
        public bool EndAnimatingPropertyInt(object component, string strProp, EndPropertyState endState)
        {
            return EndAnimatingProperty<int>(updatersInt, component, strProp, endState);
        }
        public bool EndAnimatingPropertyVector2Int(object component, string strProp, EndPropertyState endState)
        {
            return EndAnimatingProperty<Vector2Int>(updatersVector2Int, component, strProp, endState);
        }
        public bool EndAnimatingPropertyVector3Int(object component, string strProp, EndPropertyState endState)
        {
            return EndAnimatingProperty<Vector3Int>(updatersVector3Int, component, strProp, endState);
        }

        private bool EndAnimatingProperty<T>(List<PropertyUpdater<T>> updaters, object component, string strProp, EndPropertyState endState)
        {
            PropertyUpdater<T> updater = FindAnimatingProperty<T>(updaters, component, strProp);
            if (updater == null)
                return false;
            updaters.Remove(updater);
            updater.End(endState);
            return true;
        }
        #endregion


        private PropertyUpdater<T> FindAnimatingProperty<T>(List<PropertyUpdater<T>> updaters, object component, string strProp)
        {
            return updaters.Find(delegate (PropertyUpdater<T> updater)
            {
                return updater.prop.Component == component && updater.prop.StrProp == strProp;
            });
        }

        
    }

    public class PropertyUpdater<T>
    {
        public PropertyWrapper<T> prop;
        public T src;
        public T targ;
        public float durTime;
        protected float time = 0f;
        private bool isChanging = false;
        public bool IsChanging { get => isChanging; protected set => isChanging = value; }
        public delegate T GetValAtUpdate(T src, T targ, float time, float durTime);
        protected GetValAtUpdate getValAtUpdate;

        public event Action eventStart;
        public event Action eventPause;
        public event Action eventResume;
        public event Action<PropertyAnimationManager.EndPropertyState> eventEnd;

        public PropertyUpdater(PropertyWrapper<T> prop, T src, T targ, float durTime, GetValAtUpdate getValAtUpdate,
            Action actionStart,
            Action actionPause,
            Action actionResume,
            Action<PropertyAnimationManager.EndPropertyState> actionEnd): this(prop, src, targ, durTime, getValAtUpdate)
        {
            eventStart += actionStart;
            eventPause += actionPause;
            eventResume += actionResume;
            eventEnd += actionEnd;
        }

        public PropertyUpdater(PropertyWrapper<T> prop, T src, T targ, float durTime, GetValAtUpdate getValAtUpdate)
        {
            this.prop = prop;
            this.src = src;
            this.targ = targ;
            this.durTime = durTime;
            this.getValAtUpdate = getValAtUpdate;
        }

        /// <summary>
        /// Update property value. Called in Update in MonoBehaviour
        /// </summary>
        /// <returns>Is update done?</returns>
        public virtual bool Update()
        {
            if (IsChanging && time <= durTime)
            {
                time += Time.deltaTime;
                var inter = getValAtUpdate(src, targ, time, durTime);
                prop.Value = inter;
                return false;
            }
            else
            {
                if (time < durTime)
                {
                    //Paused
                    Pause();
                    return false;
                }
                else
                {
                    //End
                    End(PropertyAnimationManager.EndPropertyState.Targ);
                    SetEndVal();
                    return true;
                }
            }
        }

        public virtual void Start()
        {
            time = 0f;
            SetStartVal();
            IsChanging = true;
            eventStart?.Invoke();
        }

        public virtual void End(PropertyAnimationManager.EndPropertyState state)
        {
            IsChanging = false;
            switch (state)
            {
                case PropertyAnimationManager.EndPropertyState.Src:
                    SetStartVal();
                    break;
                case PropertyAnimationManager.EndPropertyState.Targ:
                    SetEndVal();
                    break;
                case PropertyAnimationManager.EndPropertyState.Keep:
                    break;
            }
            eventEnd?.Invoke(state);
        }

        public virtual void SetStartVal()
        {
            prop.Value = src;
        }

        public virtual void SetEndVal()
        {
            prop.Value = targ;
        }

        public virtual void Pause()
        {
            IsChanging = false;
            eventPause?.Invoke();
        }

        public virtual void Resume()
        {
            IsChanging = true;
            eventResume?.Invoke();
        }

        // Static methods for init the delegate
        public static float GetValAtUpdateFloat(float src, float targ, float time, float durTime) { return Mathf.Lerp(src, targ, time / durTime); }
        public static Vector2 GetValAtUpdateVector2(Vector2 src, Vector2 targ, float time, float durTime) { return Vector2.Lerp(src, targ, time / durTime); }
        public static Vector3 GetValAtUpdateVector3(Vector3 src, Vector3 targ, float time, float durTime) { return Vector3.Lerp(src, targ, time / durTime); }
        public static int GetValAtUpdateInt(int src, int targ, float time, float durTime) { return Mathf.FloorToInt(Mathf.Lerp(src, targ, time / durTime)); }
        public static Vector2Int GetValAtUpdateVector2Int(Vector2Int src, Vector2Int targ, float time, float durTime) { return Vector2Int.FloorToInt(Vector2.Lerp(src, targ, time / durTime)); }
        public static Vector3Int GetValAtUpdateVector3Int(Vector3Int src, Vector3Int targ, float time, float durTime) { return Vector3Int.FloorToInt(Vector3.Lerp(src, targ, time / durTime)); }
    }

    public class PropertyWrapper<T>
    {
        public PropertyWrapper(object component, string strProp, Action<T> setter, Func<T> getter)
        {
            this.Component = component;
            this.StrProp = strProp;
            this.setter = setter;
            this.getter = getter;
        }

        private object component;
        public object Component { get => component; protected set => component = value; }
        private string strProp;
        public string StrProp { get => strProp; protected set => strProp = value; }
        private Action<T> setter;
        private Func<T> getter;

        public virtual T Value
        {
            set { setter(value); }
            get { return getter(); }
        }
    }
}

