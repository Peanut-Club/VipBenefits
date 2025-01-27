using BetterCommands;

using static VIPBenefits.SpawnItems.SpawnGiftsManager;
using static VIPBenefits.SpawnItems.SpawnGiftsConfig;
using helpers.Pooling.Pools;
using helpers;
using System.Linq;
using System.Web;

namespace VIPBenefits.SpawnItems {
    public static class SpawnGiftsCommands {
        [Command("mygiftchances", CommandType.PlayerConsole, CommandType.RemoteAdmin)]
        public static string MyGiftChancesCommand(ReferenceHub hub) {
            return PrintChancesForGroups(GetGroups(hub));
        }

        [Command("viewgiftchances", CommandType.PlayerConsole, CommandType.RemoteAdmin)]
        public static string ViewGiftChancesCommand(ReferenceHub hub, string group) {
            return PrintChancesForGroups(group);
        }

        [Command("allgiftchances", CommandType.PlayerConsole, CommandType.RemoteAdmin)]
        public static string AllGiftChancesCommand(ReferenceHub _) {
            return PrintChancesForGroups([]);
        }

        public static string PrintChancesForGroups(params string[] groups) {
            if (groups == null) groups = [];
            bool checkRoles = groups.Length >= 1;

            var sb = StringBuilderPool.Pool.Get();

            sb.AppendLine("Search groups: " + string.Join(",", groups));

            int index = 0;
            foreach (var spawnGift in SpawnGifts) {
                index++;
                sb.AppendLine("");
                sb.AppendLine($"Rule index {index}:");
                sb.AppendLine($"- For roles: {string.Join(", ", spawnGift.Roles)}");
                if (!checkRoles) {
                    sb.AppendLine($"- {(spawnGift.OnlyHighestGroup ? "For only FIRST valid group" : "For EVERY valid group")}");
                }
                sb.AppendLine($"- Group sets:");
                bool pickedSet = false;
                foreach (var group in spawnGift.ChancesPerGroups) {
                    if (checkRoles && spawnGift.OnlyHighestGroup && pickedSet) {
                        break;
                    }
                    if (checkRoles && !group.Groups.Any(g => groups.Contains(g))) {
                        continue;
                    }

                    pickedSet = true;
                    sb.AppendLine($"  - For groups: {string.Join(", ", group.Groups)}");
                    if (group.Chances.Count > 1) {
                        sb.AppendLine($"    # Can give {(group.ChooseOnlyOne ? "only ONE set of items" : "MORE sets of items")} from:");
                    }
                    foreach (var chance in group.Chances) {
                        if (chance.Option.OptionsWithCount.Count <= 0) {
                            sb.AppendLine($"    # No items specified, skipping");
                            continue;
                        } else if (chance.Option.OptionsWithCount.Count == 1) {
                            var option = chance.Option.OptionsWithCount[0];
                            sb.AppendLine($"    - Chance: {chance.Chance:0.000}%; For item: {option.ItemType}{(option.Count != 1 ? $"; Count: {option.Count}" : "")}");
                        } else {
                            sb.AppendLine($"    - Chance: {chance.Chance:0.000}%; Chooses {(chance.Option.ChooseOnlyOne ? "only ONE" : "ALL")} from:");
                            foreach (var option in chance.Option.OptionsWithCount) {
                                sb.AppendLine($"      - {option.ItemType}{(option.Count != 1 ? $"; Count: {option.Count}" : "")}");
                            }
                        }
                    }
                }
            }

            return StringBuilderPool.Pool.PushReturn(sb);
        }
    }
}
