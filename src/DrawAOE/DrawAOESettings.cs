using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoeHUD.Plugins;
using PoeHUD.Hud.Settings;
using SharpDX;

namespace DrawAOE
{
    internal class DrawAOESettings : SettingsBase
    {
        public DrawAOESettings()
        {
            //plugin itself
            Enable = false;
            DisplayInTown = false;

            CircleEnable = true;
            CircleSize = new RangeNode<int>(500, 50, 2000);
            LineWidth = new RangeNode<int>(1, 1, 5);
            LineColor = new ColorBGRA(0, 255, 255, 255);

            CircleEnable2 = false;
            CircleSize2 = new RangeNode<int>(500, 50, 2000);
            LineWidth2 = new RangeNode<int>(1, 1, 5);
            LineColor2 = new ColorBGRA(0, 255, 255, 255);

            CircleEnable3 = false;
            CircleSize3 = new RangeNode<int>(500, 50, 2000);
            LineWidth3 = new RangeNode<int>(1, 1, 5);
            LineColor3 = new ColorBGRA(0, 255, 255, 255);

            CircleEnable4 = false;
            CircleSize4 = new RangeNode<int>(500, 50, 2000);
            LineWidth4 = new RangeNode<int>(1, 1, 5);
            LineColor4 = new ColorBGRA(0, 255, 255, 255);

        }

        //Menu


        [Menu("Display in Town", 1)]
        public ToggleNode DisplayInTown { get; set; }

        [Menu("Circle 1", 2)]
        public ToggleNode CircleEnable { get; set; }
        [Menu("Circle Size", 20, 2)]
        public RangeNode<int> CircleSize { get; set; }
        [Menu("Line Width", 21, 2)]
        public RangeNode<int> LineWidth { get; set; }
        [Menu("Line Color", 22, 2)]
        public ColorNode LineColor { get; set; }

        [Menu("Circle 2", 3)]
        public ToggleNode CircleEnable2 { get; set; }
        [Menu("Circle Size", 30, 3)]
        public RangeNode<int> CircleSize2 { get; set; }
        [Menu("Line Width", 31, 3)]
        public RangeNode<int> LineWidth2 { get; set; }
        [Menu("Line Color", 32, 3)]
        public ColorNode LineColor2 { get; set; }

        [Menu("Circle 3", 4)]
        public ToggleNode CircleEnable3 { get; set; }
        [Menu("Circle Size", 40, 4)]
        public RangeNode<int> CircleSize3 { get; set; }
        [Menu("Line Width", 41, 4)]
        public RangeNode<int> LineWidth3 { get; set; }
        [Menu("Line Color", 42, 4)]
        public ColorNode LineColor3 { get; set; }

        [Menu("Circle 4", 5)]
        public ToggleNode CircleEnable4 { get; set; }
        [Menu("Circle Size", 50, 5)]
        public RangeNode<int> CircleSize4 { get; set; }
        [Menu("Line Width", 51, 5)]
        public RangeNode<int> LineWidth4 { get; set; }
        [Menu("Line Color", 52, 5)]
        public ColorNode LineColor4 { get; set; }

    }
}
