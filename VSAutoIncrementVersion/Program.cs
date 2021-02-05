using System;
using System.IO;

namespace VSAutoIncrementVersion
{
    class Program
    {
        enum VersionSection
        {
            Major = 0,
            Minor = 1,
            Build = 2,
            Revision = 3
        }
        static void Main(string[] args)
        {
            if (args.Length <= 1)
                throw new NotImplementedException("You need to pass two params, first for xml config file path like version.cfg, second for version with wildcard like 1.0.0.? or 1.0.? or 1.? where ? will be incremented");

            string path = args[0];
            string versionMask = args[1];

            if (!File.Exists(path))
            {
                using (StreamWriter w = File.AppendText(path))
                {
                    ;
                }

                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine(versionMask.Replace('?', '0'));
                }
            }
            else
            {

                string readText = File.ReadAllText(path);
                if (!Version.TryParse(readText.Replace('?', '0'), out Version currentVersion))
                {
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        writer.WriteLine(versionMask.Replace('?', '0'));
                    }
                }
                else
                {
                    VersionSection versionSection;
                    // detect what section of version needs to be incremented using wildcard
                    int? wildcardIndex = null;
                    for (int i = 0; i < versionMask.Split('.').Length; i++)
                    {
                        if (versionMask.Split('.')[i] == "?")
                        {
                            wildcardIndex = i;
                            break;
                        }
                    }

                    if (wildcardIndex is null)
                        versionSection = VersionSection.Revision;
                    else
                        versionSection = (VersionSection)wildcardIndex;

                    Version newVersion;
                    switch (versionSection)
                    {
                        case VersionSection.Major:
                            newVersion = VersionExtension.IncrementMajor(currentVersion);
                            break;
                        case VersionSection.Minor:
                            newVersion = VersionExtension.IncrementMinor(currentVersion);
                            break;
                        case VersionSection.Build:
                            newVersion = VersionExtension.IncrementBuild(currentVersion);
                            break;
                        case VersionSection.Revision:
                            newVersion = VersionExtension.IncrementRevision(currentVersion);
                            break;
                        default:
                            newVersion = VersionExtension.IncrementRevision(currentVersion);
                            break;
                    }

                    File.WriteAllText(path, newVersion.ToString());
                }

            }

        }
    }
}
