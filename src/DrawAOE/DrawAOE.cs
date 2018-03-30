using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoeHUD.Plugins;
using PoeHUD.Controllers;
using PoeHUD.Poe.Components;
using PoeHUD.Poe.RemoteMemoryObjects;
using PoeHUD.Hud.Menu.SettingsDrawers;
using SharpDX;
using ImGuiNET;
using PoeHUD.Hud.UI;

namespace DrawAOE
{
    internal class DrawAOE : BaseSettingsPlugin<DrawAOESettings>
    {
        private bool isTown;

        public override void Initialise()
        {
            PluginName = "DrawAOE";

            OnSettingsToggle();
            Settings.Enable.OnValueChanged += OnSettingsToggle;
        }

        private void OnSettingsToggle()
        {
            try
            {
                if (Settings.Enable.Value)
                {
                    GameController.Area.OnAreaChange += OnAreaChange;
                    GameController.Area.RefreshState();

                    isTown = GameController.Area.CurrentArea.IsTown;


                }
                else
                {
                    return;
                }
            }
            catch (Exception)
            {
            }
        }


        public override void Render()
        {

            if (!Settings.Enable.Value) return;


            if (Settings.CircleEnable.Value)
            {
                if (!Settings.DisplayInTown.Value && isTown)
                {
                    return;
                }
                else
                {
                    var pos = GameController.Game.IngameState.Data.LocalPlayer.GetComponent<Render>().Pos;
                    DrawEllipseToWorld(pos, Settings.CircleSize.Value, 50, Settings.LineWidth.Value, Settings.LineColor.Value);
                }
            }

            if (Settings.CircleEnable2.Value)
            {
                if (!Settings.DisplayInTown.Value && isTown)
                {
                    return;
                }
                else
                {
                    var pos = GameController.Game.IngameState.Data.LocalPlayer.GetComponent<Render>().Pos;
                    DrawEllipseToWorld(pos, Settings.CircleSize2.Value, 50, Settings.LineWidth2.Value, Settings.LineColor2.Value);
                }
            }

            if (Settings.CircleEnable3.Value)
            {
                if (!Settings.DisplayInTown.Value && isTown)
                {
                    return;
                }
                else
                {
                    var pos = GameController.Game.IngameState.Data.LocalPlayer.GetComponent<Render>().Pos;
                    DrawEllipseToWorld(pos, Settings.CircleSize3.Value, 50, Settings.LineWidth3.Value, Settings.LineColor3.Value);
                }
            }

            if (Settings.CircleEnable4.Value)
            {
                if (!Settings.DisplayInTown.Value && isTown)
                {
                    return;
                }
                else
                {
                    var pos = GameController.Game.IngameState.Data.LocalPlayer.GetComponent<Render>().Pos;
                    DrawEllipseToWorld(pos, Settings.CircleSize4.Value, 50, Settings.LineWidth4.Value, Settings.LineColor4.Value);
                }
            }
        }

        private void OnAreaChange(AreaController area)
        {
            if (Settings.Enable.Value)
            {
                isTown = area.CurrentArea.IsTown;
            }
        }


        public void DrawEllipseToWorld(Vector3 vector3Pos, int radius, int points, int lineWidth, Color color)
        {
            var camera = GameController.Game.IngameState.Camera;

            var plottedCirclePoints = new List<Vector3>();
            var slice = 2 * Math.PI / points;
            for (var i = 0; i < points; i++)
            {
                var angle = slice * i;
                var x = (decimal)vector3Pos.X + decimal.Multiply((decimal)radius, (decimal)Math.Cos(angle));
                var y = (decimal)vector3Pos.Y + decimal.Multiply((decimal)radius, (decimal)Math.Sin(angle));
                plottedCirclePoints.Add(new Vector3((float)x, (float)y, vector3Pos.Z));
            }

            var rndEntity = GameController.Entities.FirstOrDefault(x =>
                x.HasComponent<Render>() && GameController.Player.Address != x.Address);

            for (var i = 0; i < plottedCirclePoints.Count; i++)
            {
                if (i >= plottedCirclePoints.Count - 1)
                {
                    var pointEnd1 = camera.WorldToScreen(plottedCirclePoints.Last(), rndEntity);
                    var pointEnd2 = camera.WorldToScreen(plottedCirclePoints[0], rndEntity);
                    Graphics.DrawLine(pointEnd1, pointEnd2, lineWidth, color);
                    return;
                }

                var point1 = camera.WorldToScreen(plottedCirclePoints[i], rndEntity);
                var point2 = camera.WorldToScreen(plottedCirclePoints[i + 1], rndEntity);
                Graphics.DrawLine(point1, point2, lineWidth, color);
            }
        }
    }
}