<h1 align="center">
  <a href="https://github.com/cjhdevact/UsefulControl">UsefulControl - 实用工具集合小工具</a>
</h1>

## 关于本项目

这是一个为大屏类电脑（如希沃）编写的实用工具，可以理解为一堆工具的整合包。本软件可以安装在大屏上（例如教学大屏），也可以安装在普通电脑上。

## 功能

本程序支持的功能有：

- [x] 系统操作（睡眠，休眠，锁定，关闭屏幕，调节音量，强制重启，强制关机）
- [x] 小工具系列（时钟锁屏屏保，公告栏，图片展示，一键关闭课件）
- [x] 模拟界面系列（模拟希沃联想关机界面，模拟系统关机界面，模拟黑屏）
- [x] 支持通过组策略配置策略
- [x] 支持保存你的设置
- [x] 适配DPI缩放（适配高分屏）

## 下载

转到[发布页](https://github.com/cjhdevact/UsefulControl/releases/latest)下载程序或源代码。

早期版本的源代码也在发布页里。

## 数字签名

本程序使用了自签证书进行了签名

证书信息：
```
Name: CJH Root Certificate
Create: ‎2024‎年‎12‎月‎27‎日 20:42:16
Expires: ‎2150‎年‎12‎月‎31‎日 0:00:003e5
MD5: 0bc507db70947e57ddd81bec63b581d9
SHA256: d2d67c8ebea3cc954c7ee0e94f5f45537dde7709053ca9e89f352fda60283
Key fingerprint (SHA1): 73b80a8d0ba3f662b575f2fc0b78612469e22e59
KeyID: d929e453f645017190dac5001a736a4d
Certificate SerialNumber: dbde77418068d5a34b2064626a12ecde
Key Type: md5RSA
```

你可以在[这里](Src/UsefulControl/files/rootcert.cer)下载证书来验证程序完整性。

## 程序截图

### 工具栏界面

横向：

![工具栏界面（横向深色）](Assets/ui1.png)      ![工具栏界面（横向浅色）](Assets/ui1light.png)

纵向：

![工具栏界面（纵向深色）](Assets/ui2.png)      ![工具栏界面（纵向浅色）](Assets/ui2light.png)

### 主程序界面

![主程序界面（浅色）](Assets/uimain.png)

### 设置界面

![设置界面](Assets/uisetting.png)

## 开源说明

在修改和由本仓库代码衍生的代码中需要说明“基于 UsefulControl 开发”。

## 相关项目

[TDocKiller](https://github.com/cjhdevact/TDocKiller) - 一键关闭课件小工具

[LockTime](https://github.com/cjhdevact/LockTime) - 时钟锁屏小工具

[IBoard](https://github.com/cjhdevact/IBoard) - 图片展示小工具

## License

本程序基于`GPL-3.0`协议授权。