# VSAutoIncrementVersion

Tool to auto increment version in Visual Studio

Auto increment version is not something included by default in visual studio and there's some walkaround in the web but all of them is more complicated and often specific to some scenarios.</br>
VSAutoIncrementVersion use a simple way by storing version into a text file and read value from it and increment it each time there's a rebuild of your application.
</br></br>
All you have to do is :
</br></br>
**step1** :</br>
copy VSAutoIncrementVersion release "[VSAutoIncrementVersion.exe](https://github.com/melharfi/VSAutoIncrementVersion/releases/latest)" in you project root folder
![alt text](https://github.com/melharfi/VSAutoIncrementVersion/blob/master/VSAutoIncrementVersion/vsaiv-1.png)
</br></br>
**step2** :</br>
past these lines to Post-Build
</br></br>
xcopy "$(ProjectDir)*version.txt*" "$(TargetDir)\"
"$(ProjectDir)\"VSAutoIncrementVersion.exe *version.txt* *1.0.0.?*
</br></br>
**step 3** :</br>
use this code to read your version in your project :
</br></br>
Version currentVersion = Version.Parse(File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\version.txt"));
</br></br>
You will need thoses namespaces aswell :</br>
using System.IO;</br>
using System.Reflection;</br>
</br></br>
Explanation:
</br></br>
**step 1** :</br>
you need VSAutoIncrementVersion.exe so it'll be executed each time you rebuild your application and increment version
</br></br>
**step 2 :**</br>
xcopy "$(ProjectDir)version.txt" "$(TargetDir)\"</br>
will copy version.txt file in the same directory of your application so your can read it, you can use other name.</br>
</br></br>
"$(ProjectDir)\"VSAutoIncrementVersion.exe version.txt 1.0.0.?</br>
execute VSAutoIncrementVersion.exe that needs 2 params</br>
first param "version.txt" is the version file to read from</br>
second param "1.0.0.?" is the version with wildcard that will be incremented, you can use other format like 1.0.? or 1.? for (Major, Minor, Build, Revision)
</br></br>
**Step 3 :**</br>
Read version from file</br>
Version currentVersion = Version.Parse(File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\version.txt"));
