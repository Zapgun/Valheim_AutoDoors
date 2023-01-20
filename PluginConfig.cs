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

        #endregion

        #region Methods
        public void Reload()

        {
            if (!AutoDoorPlugin.HasInstance)
                return;

            var config = AutoDoorPlugin.Instance.Config;

            modEnabled = config.Bind("General", "modEnabled", true, "Enable the mod");
            hotKeyToggle = config.Bind("General", "hotkeyToggle", new KeyboardShortcut(KeyCode.U), "Toggle the mon on/off with this key");
            updateInterval = config.Bind("General", "updateInterval", 1f/16, "Minimum interval between updates (s)");
            disableInCrypt = config.Bind("Crypt Behaviour", "disableInCrypt", true, "Disables auto doors inside crypts");
        }
        #endregion
    }
}
