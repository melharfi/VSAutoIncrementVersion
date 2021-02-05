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
"$(ProjectDir)\\"VSAutoIncrementVersion.exe *version.txt* *1.0.0.?*</br>
xcopy /y $(ProjectDir)*version.txt*  $(ProjectDir)$(OutDir)</br>
![alt text](https://github.com/melharfi/VSAutoIncrementVersion/blob/master/VSAutoIncrementVersion/vsaiv-2.png)
</br></br>
**step 3** :</br>
use this code to read your version in your project :
</br></br>
Version currentVersion = Version.Parse(File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\version.txt"));
</br></br>
You will need thoses namespaces aswell :</br>
using System.IO;</br>
using System.Reflection;</br>
