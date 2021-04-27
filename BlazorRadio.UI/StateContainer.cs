using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRadio.UI
{
    public class StateContainer
    {
        string _tag;

        public StateContainer(string defaultTag)
        {
            _tag = defaultTag;
        }
        
        public string SelectedTag
        {
            get
            {
                return _tag;
            }
            set
            {
                _tag = value;
                NotifySelectedTagChange();
            }
        }

        public event Action OnSelectedTagChanged;

        private void NotifySelectedTagChange() => OnSelectedTagChanged?.Invoke();
    }
}
