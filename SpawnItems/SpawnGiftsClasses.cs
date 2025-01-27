using PlayerRoles;
using System.Collections.Generic;

namespace VIPBenefits.SpawnItems {
    public class SpawnGift {
        public List<RoleTypeId> Roles { get; set; }
        public bool OnlyHighestGroup { get; set; } = true;
        public List<SpawnGiftGroup> ChancesPerGroups { get; set; }

        public SpawnGift() { }

        public SpawnGift(RoleTypeId role, List<SpawnGiftGroup> chancesPerGroups) {
            Roles = new() { role };
            ChancesPerGroups = new(chancesPerGroups);
        }

        public SpawnGift(List<RoleTypeId> roles, List<SpawnGiftGroup> chancesPerGroups) {
            Roles = new(roles);
            ChancesPerGroups = new(chancesPerGroups);
        }

        public SpawnGift(RoleTypeId role, List<SpawnGiftGroup> chancesPerGroups, bool onlyHighestGroup)
            : this(role, chancesPerGroups) {
            OnlyHighestGroup = onlyHighestGroup;
        }

        public SpawnGift(List<RoleTypeId> roles, List<SpawnGiftGroup> chancesPerGroups, bool onlyHighestGroup)
            : this(roles, chancesPerGroups) {
            OnlyHighestGroup = onlyHighestGroup;
        }
    }



    public class SpawnGiftGroup {
        public List<string> Groups { get; set; }
        public bool ChooseOnlyOne { get; set; } = false;
        public List<SpawnGiftChance> Chances { get; set; }

        public SpawnGiftGroup() { }

        public SpawnGiftGroup(string group, List<SpawnGiftChance> chances) {
            Groups = new() { group };
            Chances = new(chances);
        }

        public SpawnGiftGroup(List<string> groups, List<SpawnGiftChance> chances) {
            Groups = new(groups);
            Chances = new(chances);
        }

        public SpawnGiftGroup(string group, List<SpawnGiftChance> chances, bool chooseOnlyOne)
            : this(group, chances) {
            ChooseOnlyOne = chooseOnlyOne;
        }

        public SpawnGiftGroup(List<string> groups, List<SpawnGiftChance> chances, bool chooseOnlyOne)
            : this(groups, chances) {
            ChooseOnlyOne = chooseOnlyOne;
        }
    }



    public class SpawnGiftChance {
        public float Chance { get; set; }
        public SpawnGiftOption Option { get; set; }

        public SpawnGiftChance() { }

        public SpawnGiftChance(float chance, SpawnGiftOption option) {
            Chance = chance;
            Option = option;
        }

        public SpawnGiftChance(float chance, ItemType itemType, ushort count = 1) {
            Chance = chance;
            Option = new SpawnGiftOption(itemType, count);
        }
    }



    public class SpawnGiftOption {
        public bool ChooseOnlyOne { get; set; } = true;
        public List<SpawnGiftTuple> OptionsWithCount { get; set; }

        public SpawnGiftOption() { }

        public SpawnGiftOption(ItemType type, ushort count = 1, bool chooseOnlyOne = true) {
            OptionsWithCount = new() { new(type, count) };
            ChooseOnlyOne = chooseOnlyOne;
        }

        public SpawnGiftOption(List<SpawnGiftTuple> optionsWithCount) {
            OptionsWithCount = new(optionsWithCount);
        }

        public SpawnGiftOption(List<SpawnGiftTuple> optionsWithCount, bool chooseOnlyOne)
            : this(optionsWithCount) {
            ChooseOnlyOne = chooseOnlyOne;
        }

        public IEnumerable<SpawnGiftTuple> GetItems() {

            if (ChooseOnlyOne) {
                yield return OptionsWithCount.RandomItem();
                yield break;
            }

            foreach (var item in OptionsWithCount) {
                yield return item;
            }
        }
    }



    public class SpawnGiftTuple {
        public ItemType ItemType { get; set; }
        public ushort Count { get; set; }

        public SpawnGiftTuple() { }

        public SpawnGiftTuple(ItemType itemType, ushort count = 1) {
            ItemType = itemType;
            Count = count;
        }
    }
}
