using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json.Serialization;

#nullable enable

namespace OpenTabletDriver.Desktop.Profiles
{
    public class ProfileCollection : ObservableCollection<Profile>
    {
        [JsonConstructor]
        public ProfileCollection()
        {
        }

        public ProfileCollection(IEnumerable<Profile> profiles)
            : base(profiles)
        {
        }

        public Profile? this[InputDevice tablet]
        {
            set => SetProfile(tablet, value);
            get => GetProfile(tablet);
        }

        private void SetProfile(InputDevice tablet, Profile? profile)
        {
            if (profile == null)
                return;

            if (this.FirstOrDefault(t => t.Tablet == tablet.Properties.Name) is Profile oldProfile)
            {
                Remove(oldProfile);
            }

            Add(profile);
        }

        private Profile? GetProfile(InputDevice tablet)
        {
            return this.FirstOrDefault(t => t.Tablet == tablet.Properties.Name);
        }

        public Profile GetOrSetDefaults(IServiceProvider serviceProvider, InputDevice inputDevice)
        {
            if (GetProfile(inputDevice) is Profile existingProfile)
                return existingProfile;

            var profile = Profile.GetDefaults(serviceProvider, inputDevice);
            SetProfile(inputDevice, profile);
            return profile;
        }
    }
}
