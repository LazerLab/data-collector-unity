/*
 * Author(s): Isaiah Mann
 * Description: Used for the callback phase when Volunteer Science returns a variable to Unity
 * Usage: [no notes]
 */

namespace VolunteerScience
{
    using UnityEngine;

    public class VariableReceiveHandler : MonoBehaviour
    {
        VariableFetchAction fetcher;

        public void Set(VariableFetchAction fetcher)
        {
            this.fetcher = fetcher;
        }
            
        public void Receive(object value)
        {
            fetcher.RunCallback(value);   
            // Destroys this object:
            fetcher.Complete();
        }

    }

}
