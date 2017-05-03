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

        public StringFetchAction GetString(string key, Action<string> callback)
        {
            return new StringFetchAction(key, callback);
        }

        public FloatFetchAction GetFloat(string key, Action<float> callback)
        {
            return new FloatFetchAction(key, callback);
        }

        public IntFetchAction GetInt(string key, Action<int> callback)
        {
            return new IntFetchAction(key, callback);
        }

        public BoolFetchAction GetBool(string key, Action<bool> callback)
        {
            return new BoolFetchAction(key, callback);
        }

        public VariableListFetchAction GetValueList(string key, Action<string[]> callback)
        {
            return new VariableListFetchAction(key, callback);
        }

        public FloatListFetchAction GetFloatList(string key, Action<float[]> callback)
        {
            return new FloatListFetchAction(key, callback);
        }

        public IntListFetchAction GetIntList(string key, Action<int[]> callback)
        {
            return new IntListFetchAction(key, callback);
        }

        public BoolListFetchAction GetBoolList(string key, Action<bool[]> callback)
        {
            return new BoolListFetchAction(key, callback);
        }

    }
        
}
