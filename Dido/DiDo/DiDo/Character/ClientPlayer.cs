using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace DiDo.Character
{
    public abstract class ClientPlayer : Player
    {
        public ClientPlayer(string name, float x, float y) : base(name, x, y)
        {

        }
    }
}
