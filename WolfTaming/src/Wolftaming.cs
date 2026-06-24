using System;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using Vintagestory.GameContent;

namespace WolfTaming
{
    public class Wolftaming : ModSystem
    {
        public override void Start(ICoreAPI api)
        {
            base.Start(api);

            AiTaskRegistry.Register<AiTaskPlayFetch>("playfetch");
            AiTaskRegistry.Register<AiTaskStayCloseToShepherd>("stayclosetoshepherd");
        }
    }
}
