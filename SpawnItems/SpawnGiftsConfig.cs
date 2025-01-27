using System.Collections.Generic;
using PlayerRoles;
using helpers.Configuration;

using static VIPBenefits.SpawnItems.SpawnGiftsManager;

namespace VIPBenefits.SpawnItems {
    public static class SpawnGiftsConfig {

        [ConfigAttribute(Name = "SpawnGifts", Description = $"Settings for Giving items on Player Spawn (group name '{defaultGroupName}' = for all without any role) (min chance is 0.001f)")]
        public static List<SpawnGift> SpawnGifts { get; set; } = [
            #region ClassD Chances
            new(RoleTypeId.ClassD, [
                new("supporter+", [
                    new(15f, ItemType.Flashlight),
                    new(13f, ItemType.Coin),
                    new(10f, ItemType.Radio),
                    new(5f, ItemType.KeycardJanitor),
                    new(3f, ItemType.GrenadeFlash),
                    new(0.5f, ItemType.GunCOM18),
                    new(20f, new([
                        new(ItemType.Medkit),
                        new(ItemType.Adrenaline),
                        new(ItemType.Painkillers),
                    ])),
                    new(10f, new([
                        new(ItemType.Ammo12gauge, 4),
                        new(ItemType.Ammo556x45, 10),
                        new(ItemType.Ammo44cal, 6),
                        new(ItemType.Ammo762x39, 10),
                        new(ItemType.Ammo9x19, 15),
                    ])),
                ]),
                new("supporter", [
                    new(9f, ItemType.Flashlight),
                    new(9f, ItemType.Coin),
                    new(4f, ItemType.Radio),
                    new(2f, ItemType.KeycardJanitor),
                    new(2f, ItemType.GrenadeFlash),
                    new(0.4f, ItemType.GunCOM18),
                    new(10f, new([
                        new(ItemType.Medkit),
                        new(ItemType.Adrenaline),
                        new(ItemType.Painkillers),
                    ])),
                    new(8f, new([
                        new(ItemType.Ammo12gauge, 4),
                        new(ItemType.Ammo556x45, 10),
                        new(ItemType.Ammo44cal, 6),
                        new(ItemType.Ammo762x39, 10),
                        new(ItemType.Ammo9x19, 15),
                    ])),
                ]),
                new(defaultGroupName, [
                    new(5f, ItemType.Flashlight),
                    new(5f, ItemType.Coin),
                    new(4f, ItemType.Radio),
                    new(1f, ItemType.KeycardJanitor),
                    new(1f, ItemType.GrenadeFlash),
                    new(0.3f, ItemType.GunCOM18),
                    new(8f, new([
                        new(ItemType.Medkit),
                        new(ItemType.Adrenaline),
                        new(ItemType.Painkillers),
                    ])),
                    new(5f, new([
                        new(ItemType.Ammo12gauge, 4),
                        new(ItemType.Ammo556x45, 10),
                        new(ItemType.Ammo44cal, 6),
                        new(ItemType.Ammo762x39, 10),
                        new(ItemType.Ammo9x19, 15),
                    ])),
                ]),
            ]),
            #endregion

            #region Scientist Chances
            new(RoleTypeId.Scientist, [
                new("supporter+", [
                    new(15f, ItemType.Flashlight),
                    new(13f, ItemType.Coin),
                    new(10f, ItemType.Radio),
                    new(5f, ItemType.KeycardZoneManager),
                    new(3f, ItemType.GrenadeFlash),
                    new(0.5f, ItemType.GunCOM18),
                    new(20f, new([
                        new(ItemType.Medkit),
                        new(ItemType.Adrenaline),
                        new(ItemType.Painkillers),
                    ])),
                    new(10f, new([
                        new(ItemType.Ammo12gauge, 4),
                        new(ItemType.Ammo556x45, 10),
                        new(ItemType.Ammo44cal, 6),
                        new(ItemType.Ammo762x39, 10),
                        new(ItemType.Ammo9x19, 15),
                    ])),
                ]),
                new("supporter", [
                    new(9f, ItemType.Flashlight),
                    new(9f, ItemType.Coin),
                    new(4f, ItemType.Radio),
                    new(2f, ItemType.KeycardZoneManager),
                    new(2f, ItemType.GrenadeFlash),
                    new(0.4f, ItemType.GunCOM18),
                    new(10f, new([
                        new(ItemType.Medkit),
                        new(ItemType.Adrenaline),
                        new(ItemType.Painkillers),
                    ])),
                    new(8f, new([
                        new(ItemType.Ammo12gauge, 4),
                        new(ItemType.Ammo556x45, 10),
                        new(ItemType.Ammo44cal, 6),
                        new(ItemType.Ammo762x39, 10),
                        new(ItemType.Ammo9x19, 15),
                    ])),
                ]),
                new(defaultGroupName, [
                    new(5f, ItemType.Flashlight),
                    new(5f, ItemType.Coin),
                    new(4f, ItemType.Radio),
                    new(1f, ItemType.KeycardZoneManager),
                    new(1f, ItemType.GrenadeFlash),
                    new(0.3f, ItemType.GunCOM18),
                    new(8f, new([
                        new(ItemType.Medkit),
                        new(ItemType.Adrenaline),
                        new(ItemType.Painkillers),
                    ])),
                    new(5f, new([
                        new(ItemType.Ammo12gauge, 4),
                        new(ItemType.Ammo556x45, 10),
                        new(ItemType.Ammo44cal, 6),
                        new(ItemType.Ammo762x39, 10),
                        new(ItemType.Ammo9x19, 15),
                    ])),
                ]),
            ]),
            #endregion

            #region FacilityGuard Chances
            new(RoleTypeId.FacilityGuard, [
                new("supporter+", [
                    new(15f, ItemType.Coin),
                    new(15f, new([
                        new(ItemType.Medkit),
                        new(ItemType.Adrenaline),
                        new(ItemType.Painkillers),
                    ])),
                    new(50f, ItemType.Ammo9x19, 30),
                ]),
                new("supporter", [
                    new(12f, ItemType.Coin),
                    new(13f, new([
                        new(ItemType.Medkit),
                        new(ItemType.Adrenaline),
                        new(ItemType.Painkillers),
                    ])),
                    new(40f, ItemType.Ammo9x19, 30),
                ]),
                new(defaultGroupName, [
                    new(9f, ItemType.Coin),
                    new(10f, new([
                        new(ItemType.Medkit),
                        new(ItemType.Adrenaline),
                        new(ItemType.Painkillers),
                    ])),
                    new(30f, ItemType.Ammo9x19, 30),
                ]),
            ]),
            #endregion

            #region NtfSpecialist Chances
            new(RoleTypeId.NtfSpecialist, [
                new("supporter+", [
                    new(9f, new([
                        new(ItemType.MicroHID),
                        new(ItemType.ParticleDisruptor),
                        new(ItemType.Jailbird),
                    ])),
                ]),
                new("supporter", [
                    new(6f, new([
                        new(ItemType.MicroHID),
                        new(ItemType.ParticleDisruptor),
                        new(ItemType.Jailbird),
                    ])),
                ]),
                new(defaultGroupName, [
                    new(3f, new([
                        new(ItemType.MicroHID),
                        new(ItemType.ParticleDisruptor),
                        new(ItemType.Jailbird),
                    ])),
                ]),
            ]),
            #endregion

            #region ChaosMarauder Chances
            new(RoleTypeId.ChaosMarauder, [
                new("supporter+", [
                    new(50f, new(ItemType.GrenadeHE)),
                ]),
                new("supporter", [
                    new(40f, new(ItemType.GrenadeHE)),
                ]),
                new(defaultGroupName, [
                    new(30f, new(ItemType.GrenadeHE)),
                ]),
            ]),
            #endregion
        ];
    }
}
