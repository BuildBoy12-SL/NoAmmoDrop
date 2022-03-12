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
        private Harmony harmony;

        /// <inheritdoc />
        public override string Author => "Build";

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

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
            harmony?.UnpatchAll(harmony.Id);
            harmony = null;
            base.OnDisabled();
        }
    }
}