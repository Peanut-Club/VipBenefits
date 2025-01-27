using System.Linq;
using System.Collections.Generic;
using PluginAPI.Events;
using PluginAPI.Core;
using Compendium;
using Compendium.Staff;
using Compendium.Extensions;
using Compendium.Events;
using PlayerRoles;
using InventorySystem.Items;

using static VIPBenefits.SpawnItems.SpawnGiftsConfig;

namespace VIPBenefits.SpawnItems {
    public static class SpawnGiftsManager {
        private static System.Random RandomGenerator = new System.Random();
        internal const string defaultGroupName = "everyone";


        [Event]
        private static void OnPlayerChangeRole(PlayerChangeRoleEvent ev) {
            Calls.NextFrame(delegate {
                if (ev.ChangeReason == RoleChangeReason.None ||
                    ev.ChangeReason == RoleChangeReason.Died ||
                    ev.ChangeReason == RoleChangeReason.RemoteAdmin ||
                    ev.ChangeReason == RoleChangeReason.Destroyed) return;
                GiveRandomSpawnItems(ev.Player);
            });
        }


        private static void GiveRandomSpawnItems(Player player) {
            foreach (var rewardPair in GetRewards(player.ReferenceHub)) {
                if (rewardPair.ItemType.IsAmmo()) {
                    player.AddAmmo(rewardPair.ItemType, rewardPair.Count);
                } else {
                    for (uint i = 0; i < rewardPair.Count; i++)
                        player.ReferenceHub.AddItem<ItemBase>(rewardPair.ItemType);
                }
            }
        }

        public static string[] GetGroups(ReferenceHub hub) {
            if (hub == null || hub.isLocalPlayer || hub.IsHost) {
                return [defaultGroupName];
            }

            string[] groups = null;
            StaffHandler.Members.TryGetValue(hub.UserId(), out groups);
            if (StaffHandler.Members.TryGetValue(hub.UserId(), out var temp_groups)) {
                var length = temp_groups.Length;
                groups = new string[length + 1];
                temp_groups.CopyTo(groups, 0);
                groups[length] = defaultGroupName;
            }

            if (groups == null || groups.Length <= 0) {
                groups = [defaultGroupName];
            }
            return groups;
        }

        public static IEnumerable<SpawnGiftTuple> GetRewards(ReferenceHub hub) {
            var role = hub.roleManager.CurrentRole.RoleTypeId;

            var groups = GetGroups(hub);

            foreach (var gift in SpawnGifts) {
                int max_groups = 1;
                if (!gift.Roles.Contains(role)) continue;
                if (!gift.OnlyHighestGroup) {
                    max_groups = int.MaxValue;
                }

                foreach (var groupChances in gift.ChancesPerGroups) {
                    if (!groupChances.Groups.Any(g => groups.Contains(g))) continue;
                    if (max_groups-- <= 0) break;

                    foreach (var chancePair in groupChances.Chances) {
                        int chanceValue = (int)(chancePair.Chance * 1000f);
                        int randomValue = RandomGenerator.Next(0, 100001);
                        if (chanceValue < randomValue) continue;

                        foreach (var option in chancePair.Option.GetItems()) yield return option;

                        if (groupChances.ChooseOnlyOne) break;
                    }
                }
            }
        }
    }
}
