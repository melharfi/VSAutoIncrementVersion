using System;

namespace VSAutoIncrementVersion
{
    public static class VersionExtension
    {
        public static Version IncrementRevision(this Version version) => AddVersion(version, 0, 0, 0, 1);
        public static Version IncrementBuild(this Version version) => IncrementBuild(version, true);
        public static Version IncrementBuild(this Version version, bool resetLowerNumbers) => AddVersion(version, 0, 0, 1, resetLowerNumbers ? -version.Revision : 0);
        public static Version IncrementMinor(this Version version) => IncrementMinor(version, true);
        public static Version IncrementMinor(this Version version, bool resetLowerNumbers) => AddVersion(version, 0, 1, resetLowerNumbers ? -version.Build : 0, resetLowerNumbers ? -version.Revision : 0);
        public static Version IncrementMajor(this Version version) => IncrementMajor(version, true);
        public static Version IncrementMajor(this Version version, bool resetLowerNumbers) => AddVersion(version, 1, resetLowerNumbers ? -version.Minor : 0, resetLowerNumbers ? -version.Build : 0, resetLowerNumbers ? -version.Revision : 0);
        public static Version AddVersion(this Version version, string addVersion) => AddVersion(version, new Version(addVersion));
        public static Version AddVersion(this Version version, Version addVersion) => AddVersion(version, addVersion.Major, addVersion.Minor, addVersion.Build, addVersion.Revision);
        public static Version AddVersion(this Version version, int major, int minor, int build, int revision) => SetVersion(version, version.Major + major, version.Minor + minor, version.Build + build, version.Revision + revision);
        public static Version SetVersion(this Version version, int major, int minor, int build, int revision) => new Version(major, minor, build, revision);
    }
}
