# VSAutoIncrementVersion

Tool to auto increment version in Visual Studio

Auto increment version is not something included by default and there's some walkaround in the web but all of them is more complicated and othen specific to some scenarios.
VSAutoIncrementVersion use a simple way by storing version into a text file and read value from it and increment it each time there's a rebuild of your application.

All you have to do is :
step1 : copy VSAutoIncrementVersion release "VSAutoIncrementVersion.exe" in project root folder

step2 : past these lines to Post-Build
xcopy "$(ProjectDir)version.txt" "$(TargetDir)\"
"$(ProjectDir)\"VSAutoIncrementVersion.exe version.txt 1.0.0.?

step 3 : use this code to read your version in your project :
Version currentVersion = Version.Parse(File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\version.txt"));
and add thses usings
using System.IO;
using System.Reflection;

Explanation:
step 1 : you need VSAutoIncrementVersion.exe so it'll be executed each time you rebuild your application and increment version

step 2 :
xcopy "$(ProjectDir)version.txt" "$(TargetDir)\"
will copy version.txt file in the same directory of your application so your can read it, you can use other name.

"$(ProjectDir)\"VSAutoIncrementVersion.exe version.txt 1.0.0.?
execute VSAutoIncrementVersion.exe that needs 2 params
first param is the file to read from
second param is the version with wildcard that will be incremented, you can use other format like 1.0.? or 1.? for (Major, Minor, Build, Revision)

Step 3 : Read version from file
Version currentVersion = Version.Parse(File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\version.txt"));
