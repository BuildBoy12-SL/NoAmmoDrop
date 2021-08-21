// -----------------------------------------------------------------------
// <copyright file="DropAmmoPatch.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace NoDropAmmo.Patches
{
    using HarmonyLib;
    using InventorySystem;

    [HarmonyPatch(typeof(InventoryExtensions), nameof(InventoryExtensions.ServerDropAmmo))]
    internal static class DropAmmoPatch
    {
        private static bool Prefix() => false;
    }
}