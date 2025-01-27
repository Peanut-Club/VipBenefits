using Compendium.Features;

namespace VIPBenefits
{
    public class VIPBenefitsFeature : ConfigFeatureBase {

        public override string Name => "VIPBenefits";
        public override bool CanBeShared { get; } = true;
        public override bool IsPatch => false;

        public override void Load() {
            base.Load();
            FLog.Info($"{Name} loading!");
        }
    }
}
