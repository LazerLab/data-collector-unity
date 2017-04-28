/*
 * Author(s): Isaiah Mann
 * Description: Fetches variables from the Volunteer Science environment via external JavaScript calls
 * Usage: [no notes]
 */

namespace VolunteerScience
{
    using UnityEngine;

    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class VariableFetcher : Singleton<VariableFetcher>
    {
        public VariableFetchAction GetValue(string key, Action<object> callback)
        {
            return new VariableFetchAction(key, callback);
        }
         
        public VariableFetchAction GetValue<T>(string key, Action<T> callback) where T : class
        {
            return new VariableFetchAction<T>(key, callback);
        }

    }

    public class VariableFetchAction 
    {
        const string RECEIVE_FUNC = "Receive";
        const string FETCH_FUNC = "fetch";

        Action<object> callback;
        string key;
        GameObject callbackObj;

        internal VariableFetchAction(string key, Action<object> callback)
        {
            this.key = key;
            this.callback = callback;
            run();
        }

        protected VariableFetchAction(string key)
        {
            this.key = key;
            run();
        }

        public void RunCallback(object value)
        {
            callback(value);
        }

        void run()
        {
            // Setup GameObject to receiver
            this.callbackObj = createObject();
            string jsCall = getJSCall(this.key, this.callbackObj);
            Application.ExternalEval(jsCall);
        }

        /*
         * Should generate a call in the following format
         * SendMessage([GameObject Name], 'Receive', variables['key']);
         */
        string getJSCall(string key, GameObject receiver)
        {
            return string.Format("{0}('{1}', '{2}', '{3}');", 
                FETCH_FUNC,
                key,
                receiver.name,
                RECEIVE_FUNC);
        }

        GameObject createObject()
        {
            GameObject receiverObj = new GameObject();
            // Create a random ID for this GO:
            receiverObj.name = Guid.NewGuid().ToString();
            // Hide this so it doesn't crowd the scene
            receiverObj.hideFlags = HideFlags.HideInHierarchy;
            receiverObj.AddComponent<VariableReceiveHandler>().Set(this);
            return receiverObj;
        }

    }

    public class VariableFetchAction<T> : VariableFetchAction where T : class
    {
        Action<T> callback;

        internal VariableFetchAction(string key, Action<T> callback) : base(key)
        {
            this.callback = callback;
        }

        public void RunCallback(T value)
        {
            callback(value);
        }

    }
     
    public class VariableReceiveHandler : MonoBehaviour
    {
        VariableFetchAction fetcher;

        public void Set(VariableFetchAction fetcher)
        {
            this.fetcher = fetcher;
        }

        public virtual void Receive(object value)
        {
            fetcher.RunCallback(value);   
        }

    }

    public class VariableReceiveHandler<T> : VariableReceiveHandler where T : class
    {
        const string PARSE_METHOD_NAME = "Parse";

        VariableFetchAction<T> fetcher;

        public void Set(VariableFetchAction<T> fetcher)
        {
            this.fetcher = fetcher;
        }

        public override void Receive(object value)
        {
            if(typeof(T) == typeof(string))
            {
                fetcher.RunCallback(value.ToString());
            }
            else
            {
                try
                {
                    MethodInfo parseMethod = typeof(T).GetMethod(PARSE_METHOD_NAME);
                    T convertedValue = default(T);
                    parseMethod.Invoke(convertedValue, new object[]{value.ToString()});
                    fetcher.RunCallback(convertedValue);
                }
                catch
                {
                    try
                    {
                        fetcher.RunCallback((T) value);
                    }
                    catch
                    {
                        Debug.LogErrorFormat("Unable to convert {0} to type {1}", value, typeof(T));
                    }
                }
            }
        }
    }
}
