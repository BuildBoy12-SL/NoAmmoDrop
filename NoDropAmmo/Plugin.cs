// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace NoDropAmmo
{
    using System;
    using Exiled.API.Features;
    using HarmonyLib;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private static readonly Plugin InstanceValue = new Plugin();
        private Harmony harmony;

        private Plugin()
        {
        }

        /// <summary>
        /// Gets the only existing instance of the <see cref="Plugin"/> class.
        /// </summary>
        public static Plugin Instance { get; } = InstanceValue;

        /// <inheritdoc />
        public override void OnEnabled()
        {
            harmony = new Harmony($"build.noDropAmmo.{DateTime.UtcNow.Ticks}");
            harmony.PatchAll();
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            harmony?.UnpatchAll();
            harmony = null;
            base.OnDisabled();
        }
    }
}