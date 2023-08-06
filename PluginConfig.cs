using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AutoDoors
{
    public class PluginConfig
    {
        #region Properties - General

        /// <summary>
        /// Disables auto doors inside crypts
        /// </summary>
        public bool ModEnabled { get => modEnabled.Value; }
        public ConfigEntry<bool> modEnabled;

        /// <summary>
        /// Hotkey to toggle mod on and off
        /// </summary>
        public ConfigEntry<KeyboardShortcut> hotKeyToggle;
        private static KeyboardShortcut hotKeyDefault = new KeyboardShortcut((KeyCode)117, Array.Empty<KeyCode>());

        /// <summary>
        /// Minimum interval between updates (s)
        /// </summary>
        public float UpdateInterval { get => updateInterval.Value; }
        ConfigEntry<float> updateInterval;

        /// <summary>
        /// Disables auto doors inside crypts
        /// </summary>
        public bool DisableInCrypt { get => disableInCrypt.Value; }
        ConfigEntry<bool> disableInCrypt;

        /// <summary>
        /// Disables doors auto opening
        /// </summary>
        public bool DisableOpeningDoors { get => disableOpeningDoors.Value; }
        ConfigEntry<bool> disableOpeningDoors;

        #endregion

        #region Methods
        public void Reload()

        {
            if (!AutoDoorPlugin.HasInstance)
                return;

            var config = AutoDoorPlugin.Instance.Config;

            modEnabled = config.Bind("General", "modEnabled", true, "Enable the mod");
            hotKeyToggle = config.Bind("General", "hotkeyToggle", new KeyboardShortcut(KeyCode.U, KeyCode.LeftAlt), "Toggle the mon on/off with this.");
            updateInterval = config.Bind("General", "updateInterval", 1f/16, "Minimum interval between updates (s)");
            disableInCrypt = config.Bind("Crypt Behaviour", "disableInCrypt", true, "Disables auto doors inside crypts");
            disableOpeningDoors = config.Bind("Doors", "Disable Opening Doors", true, "Disables opening doors, will only auto close them.");
        }
        #endregion
    }
}
