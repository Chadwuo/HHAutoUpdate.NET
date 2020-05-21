# HHUpdateApp
[![GitHub stars](https://img.shields.io/badge/Star-%E2%98%85%E2%98%85%E2%98%85%E2%98%85%E2%98%86-green)](https://github.com/micahh28/HHUpdateApp/stargazers)

HHUpdateApp是.NET程序桌面应用程序。她可以轻松地将自动更新升级功能添加到经典桌面应用程序项目中。可能是西宋区域（我滴老噶）最具影响力的自动升级方式（恩，我们村应该就我一个）。


## 如何运作
HHUpdateApp从您的服务器下载包含更新信息的JSON文件。它使用此JSON文件来获取需要检测更新的PC上【业务应用程序】有关最新版本的信息。如果服务器上该【业务应用程序】的最新版本大于在用户PC上的当前版本，则HHUpdateApp将向用户显示更新对话框。如果用户按下更新按钮来更新软件，则它将从JSON文件中提供的URL下载更新文件（zip安装文件）。之后执行更新是安装程序的工作，HHUpdateApp会将zip文件的内容提取到应用程序目录中替换升级原应用程序文件。

## 如何使用
拒绝复杂头疼的设置，直接点击【HHUpdateApp.exe】，只需要填写您的【业务应用程序名称】（例如LOLClient）即可轻松的为您的LOLClient.exe应用程序检查更新。
![调用示例](https://github.com/micahh28/HHUpdateApp/blob/master/Images/demo1.png "调用示例")

## 开发者使用
### 1，配置HHUpdateApp.exe.config
配置升级程序，以使其可以从正确配置的服务器上获取相关业务程序更新信息
```xml
<HHUpdateApp.Properties.Settings>
            <!--HHUpdateApp将下载此处提供的更新信息的JSON文件-->
            <setting name="ServerUpdateUrl" serializeAs="String">
                <value>http://localhost:8020/version.json</value>
            </setting>
			<!--设置一个版本号：则忽略这个版本的更新-->
            <setting name="LocalIgnoreVer" serializeAs="String">
                <value />
            </setting>
			<!--应用程序名称：更新时，根据这个值关闭对应的进程-->
			<setting name="LaunchAppName" serializeAs="String">
                <value />
            </setting>
			<!--是否静悄悄升级：true,更新过程中不显示界面；false,显示更新界面-->
            <setting name="SilentUpdate" serializeAs="String">
                <value>False</value>
            </setting>
</HHUpdateApp.Properties.Settings>
```
### 2，在您的【应用程序】中添加代码以使其对HHUpdateApp发起调用
```csharp
    ProcessStartInfo processStartInfo = new ProcessStartInfo()
    {
        FileName = "~\HHUpdateApp.ext",//参数:HHUpdateApp程序路径
        Arguments = "LaunchAppName CheckMode"//参数:【LaunchAppName】:发起更新的名称（例如，LOLClient）；【CheckMode】：检查更新模式：0,自动更新；1，手动检查（区别就是，自动更新的状态下，如果有新版本更新，才会显示提示框）
    };
    //启动由包含进程启动信息的参数指定的进程资源，并将该资源与新的System.Diagnostics.Process 组件关联。
    Process proc = Process.Start(processStartInfo);
```

###  Versions.json
无论使用何种方式，配置服务器上包含更新信息的JSON文件都是必须的。将次配置文件放在应用程序可访问的服务器或远程电脑上。
```json
{
  "ApplicationStart": "更新后启动的应用程序名，多个文件用 # 号分割",
  "ReleaseDate": "发布时间",
  "ReleaseUrl": "zip更新包发布地址",
  "ReleaseVersion": "发布版本号",
  "UpdateMode": "更新方式：Cover表示覆盖原文件更新，NewInstall表示删除源文件全新安装",
  "VersionDesc": "更新描述说明",
  "IgnoreFile": "更新过程中忽略的文件，多个文件用 # 号分割"
}
```

## 示例
![更新示例](https://github.com/micahh28/HHUpdateApp/blob/master/Images/demo2.png "更新示例")
![更新示例](https://github.com/micahh28/HHUpdateApp/blob/master/Images/demo3.png "更新示例")
![更新示例](https://github.com/micahh28/HHUpdateApp/blob/master/Images/demo4.png "更新示例")
![更新示例](https://github.com/micahh28/HHUpdateApp/blob/master/Images/demo5.png "更新示例")
![错误消息示例](https://github.com/micahh28/HHUpdateApp/blob/master/Images/demo6.png "错误消息示例")
![提示消息示例](https://github.com/micahh28/HHUpdateApp/blob/master/Images/demo7.png "提示消息示例")

>上面示例中使用的代码片段

```csharp
/// <summary>
/// 检查更新按钮
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
private void button1_Click(object sender, EventArgs e)
        {
            string _updateAppPath = textBox1.Text;//输入升级程序所在目录

            if (File.Exists(_updateAppPath))//升级程序是否存在
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo()
                {
                    FileName = _updateAppPath,//路径
                    Arguments = "LOLClient 1"//此需要升级的应用程序名
                };
                Process proc = Process.Start(processStartInfo);
                if (proc != null)
                {
                    proc.WaitForExit();
                }
            }
        }
```
>上面示例中使用的JSON文件

```json
{
  "ApplicationStart": "HHUpdate.Test.exe",
  "ReleaseDate": "2020520",
  "ReleaseUrl": "http://localhost:8085/UpdateDemo/Debug.zip",
  "ReleaseVersion": "1.0.0.1",
  "UpdateMode": "Cover",
  "VersionDesc": "一个有趣的故事，当我们最初准备重做乐芙兰时已经准备好了这个BUG的修复，但最后并没有实装，因为这个技能被取代了。\r\n1，修复了一个BUG，【被动 - 镜花水月】所召唤的分身在普攻命中前阵亡，那么她所进行的普攻会造成伤害。\r\n2，新增：【恶意魔印】将为目标施加一个印记。\r\n3，乐芙兰重做后的大招理应让她能够选择复制哪个技能来做出更有趣的连招。",
  "IgnoreFile": ""
}
```
### End
