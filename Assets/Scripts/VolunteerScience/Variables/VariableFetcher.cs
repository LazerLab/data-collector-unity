/*
 * Author(s): Isaiah Mann
 * Description: Fetches variables from the Volunteer Science environment via external JavaScript calls
 * Usage: [no notes]
 */

namespace VolunteerScience
{
    using System;
    using System.Collections.Generic;

    using UnityEngine;

    public class VariableFetcher : Singleton<VariableFetcher>
    {
        public VariableFetchAction GetValue(string key, Action<object> callback)
        {
            return new VariableFetchAction(key, callback);
        }

        public VariableFetchAction GetString(string key, Action<string> callback)
        {
            return new StringFetchAction(key, callback);
        }

        public VariableFetchAction GetFloat(string key, Action<float> callback)
        {
            return new FloatFetchAction(key, callback);
        }

        public VariableFetchAction GetInt(string key, Action<int> callback)
        {
            return new IntFetchAction(key, callback);
        }

        public VariableFetchAction GetBool(string key, Action<bool> callback)
        {
            return new BoolFetchAction(key, callback);
        }

        public VariableFetchAction GetValueList(string key, Action<string[]> callback)
        {
            return new VariableListFetchAction(key, callback);
        }

        public VariableFetchAction GetFloatList(string key, Action<float[]> callback)
        {
            return new FloatListFetchAction(key, callback);
        }

        public VariableFetchAction GetIntList(string key, Action<int[]> callback)
        {
            return new IntListFetchAction(key, callback);
        }

        public VariableFetchAction GetBoolList(string key, Action<bool[]> callback)
        {
            return new BoolListFetchAction(key, callback);
        }
    }
        
}
