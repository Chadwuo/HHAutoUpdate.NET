# HHUpdateApp
HHUpdateApp��.NET��������Ӧ�ó������������ɵؽ��Զ���������������ӵ���������Ӧ�ó�����Ŀ�С�


## �������
HHUpdateApp�����ķ��������ذ���������Ϣ��JSON�ļ�����ʹ�ô�JSON�ļ�����ȡ��Ҫ�����µġ�ҵ��Ӧ�ó����й�������°汾����Ϣ���������������°汾�������û�PC�ϵĵ�ǰ����汾����HHUpdateApp�����û���ʾ���¶Ի�������û����¸��°�ť�������������������JSON�ļ����ṩ��URL���ظ����ļ���zip��װ�ļ�����֮��ִ�и����ǰ�װ����Ĺ�����HHUpdateApp�Ὣzip�ļ���������ȡ��Ӧ�ó���Ŀ¼���滻����ԭӦ�ó����ļ���

## ����ѡ��
### HHUpdateApp.exe.config
��������������ʹ����Դ���ȷ���õķ������ϻ�ȡ���ҵ����������Ϣ
```xml
<HHUpdateApp.Properties.Settings>
            <!--HHUpdateApp�����ش˴��ṩ�ĸ�����Ϣ��JSON�ļ�-->
            <setting name="ServerUpdateUrl" serializeAs="String">
                <value>http://localhost:8020/version.json</value>
            </setting>
			<!--����һ���汾�ţ����������汾�ĸ���-->
            <setting name="LocalIgnoreVer" serializeAs="String">
                <value />
            </setting>
			<!--�Ƿ���������-->
            <setting name="SilentUpdate" serializeAs="String">
                <value>False</value>
            </setting>
</HHUpdateApp.Properties.Settings>
```
### Versions.json
���÷������ϰ���������Ϣ��JSON�ļ�
```json
{
  "ApplicationStart": "���º�������Ӧ�ó�����������ļ��� # �ŷָ�",
  "ReleaseDate": "����ʱ��",
  "ReleaseUrl": "������ַ",
  "ReleaseVersion": "�����汾��",
  "UpdateMode": "���·�ʽ��Cover��ʾ����ԭ�ļ����£�NewInstall��ʾɾ��Դ�ļ�ȫ�°�װ",
  "VersionDesc": "��������˵��",
  "IgnoreFile": "���¹����к��Ե��ļ�������ļ��� # �ŷָ�"
}
```

## ҵ��Ӧ�ó�������Ӵ�����ʹ��������
```csharp
    ProcessStartInfo processStartInfo = new ProcessStartInfo()
    {
        FileName = "~\HHUpdateApp.ext",//����:HHUpdateApp����·��
        Arguments = "ҵ��Ӧ�ó��� "//����:������µġ�ҵ��Ӧ�ó�������
    };
    //�����ɰ�������������Ϣ�Ĳ���ָ���Ľ�����Դ����������Դ���µ�System.Diagnostics.Process ���������
    Process proc = Process.Start(processStartInfo);
```

## ʾ��
![����ʾ��](https://github.com/micahh28/HHUpdateApp/blob/master/Images/demo1.png "����ʾ��")
![����ʾ��](https://github.com/micahh28/HHUpdateApp/blob/master/Images/demo2.png "����ʾ��")
![����ʾ��](https://github.com/micahh28/HHUpdateApp/blob/master/Images/demo3.png "����ʾ��")
![����ʾ��](https://github.com/micahh28/HHUpdateApp/blob/master/Images/demo4.png "����ʾ��")
![������Ϣʾ��](https://github.com/micahh28/HHUpdateApp/blob/master/Images/demo5.png "������Ϣʾ��")
![��ʾ��Ϣʾ��](https://github.com/micahh28/HHUpdateApp/blob/master/Images/demo6.png "��ʾ��Ϣʾ��")

>����ʾ����ʹ�õĴ���Ƭ��

```csharp
/// <summary>
/// �����°�ť
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
private void button1_Click(object sender, EventArgs e)
        {
            string _updateAppPath = textBox1.Text;//����������������Ŀ¼

            if (File.Exists(_updateAppPath))//���������Ƿ����
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo()
                {
                    FileName = _updateAppPath,//·��
                    Arguments = "HHUpdate.Test "//����Ҫ������Ӧ�ó�����
                };
                Process proc = Process.Start(processStartInfo);
                if (proc != null)
                {
                    proc.WaitForExit();
                }
            }
        }
```
>����ʾ����ʹ�õ�JSON�ļ�

```json
{
  "ApplicationStart": "HHUpdate.Test.exe",
  "ReleaseDate": "2020520",
  "ReleaseUrl": "http://localhost:8085/UpdateDemo/Debug.zip",
  "ReleaseVersion": "1.0.0.0",
  "UpdateMode": "Cover",
  "VersionDesc": "һ����Ȥ�Ĺ��£����������׼��������ܽ��ʱ�Ѿ�׼���������BUG���޸��������û��ʵװ����Ϊ������ܱ�ȡ���ˡ�\r\n1���޸���һ��BUG�������� - ����ˮ�¡����ٻ��ķ������չ�����ǰ��������ô�������е��չ�������˺���\r\n2��������������ħӡ����ΪĿ��ʩ��һ��ӡ�ǡ�\r\n3����ܽ��������Ĵ�����Ӧ�����ܹ�ѡ�����ĸ���������������Ȥ�����С�",
  "IgnoreFile": ""
}
```
### End