# CloudMusicGear

Unblock Cloud Music Windows Desktop Client / UWP Client.

Current build status: [![Build status](https://ci.appveyor.com/api/projects/status/i33kph8k1bj5r912?svg=true)](https://ci.appveyor.com/project/EraserKing/cloudmusicgear)

A total rewrite to Unblock163MusicClient [https://github.com/EraserKing/Unblock163MusicClient/releases] :)

## Usage (Windows Desktop Client)

1. Launch, select a port (default 3412), and start.
2. Open Windows client, set proxy to IP 127.0.0.1, port 3412.
3. Save and restart the desktop client.
4. Enjoy!

## Usage (UWP Client)

As it's not possible to assign a proxy for a single UWP client, a PAC is required to hijack the traffic.

1. Launch, select a port (default 3412), select a PAC port (default 3413), and start.
2. Set your Internet Explorer proxy to `http://localhost:3413/pac/`
3. To test, you can access http://localhost:3413/pac/ and you should see something like this `function FindProxyForURL(url, host) { if (host == "music.163.com") return "PROXY 127.0.0.1:3412"; else return "DIRECT"; }`, and you can still access any website as usual. This is proving a tiny HTTP server providing PAC file is working.
4. Open the UWP client.
5. Enjoy!

Notes:

1. **Before first use, you must enable lookback access for the client** 
`checknetisolation loopbackexempt -a -n=1F8B0F94.122165AE053F_j2p0p5q0044a6` (Run as administration, for current version), or download a GUI program here [https://loopback.codeplex.com/] and enables the UWP client.

2. After you have set PAC properly, you may let the desktop client use Internet Explorer's proxy settings, and it should also be working fine.

3. The PAC file only redirects the traffic to cloud music servers and does not hijack any other traffic. Your credit card information and bank password is still unknown to me :)

4. If you have something other program which sets system proxy by PAC, or you need PAC set to access Internet, you should not replace the PAC settings simply.

Instead, you should edit your PAC file and try to insert `if (host == "music.163.com") { return "PROXY 127.0.0.1:3412"; }` into `function FindProxyForURL`.

For example, a typical PAC file:
```
function FindProxyForURL(url, host) {
    var suffix;
    var pos = host.lastIndexOf('.');
    pos = host.lastIndexOf('.', pos - 1);
(omitted...)
```

You should modify it to 
```
function FindProxyForURL(url, host) {
    if (host == "music.163.com") { return "PROXY 127.0.0.1:3412"; }
    var suffix;
    var pos = host.lastIndexOf('.');
    pos = host.lastIndexOf('.', pos - 1);
(omitted...)
```



## Settings

1. Port: The HTTP proxy port.
2. Override playback quality: **Recommended**. It takes higher priority than the settings in the client and setting it here prevents some potential issues.
3. Override download quality: **Recommended**. It takes higher priority than the settings in the client and setting it here prevents some potential issues.
4. Override server IP: Enable it when you get a wrong IP address for the server. This is often happening for oversea users. Also, you can use it when you're redirected to a wrong CDN server.
6. Enable PAC: Enable a tiny HTTP server to store PAC file for browsers.
7. PAC port: Set the HTTP server port for PAC file.
8. Proxy: Set upstream HTTP proxy. Example:`127.0.0.1:1080`

## Download

See [https://github.com/EraserKing/CloudMusicGear/releases]

## Known issues

1. Download is working, but if you just specify download quality to 320k, you may find during downloading the quality returns to 128k. This cannot be solved, but it's **strongly recommended to override the download bitrate to a fixed value!**
2. The settings playback music quality won't take effect immediately after you change them; instead it will only be switched properly after it meets a normal song (not disabled). **strongly recommended to override the playback bitrate to a fixed value!**

## Open issues

Please report the following information:

* Operating system
* Song / Album / Playlist name (how I can locate to that song)
* Whether the issue happens on specific songs, or all songs
* Whether it can be reproduced on web client for the same song

## Building

Need the following packages:

FiddlerCore 4 [http://www.telerik.com/fiddler/fiddlercore]

Newtonsoft.Json 8.0.2 [https://github.com/JamesNK/Newtonsoft.Json]

Under Visual Studio 2015.

## Thanks

Thanks yanunon for his API analysis! [https://github.com/yanunon/NeteaseCloudMusic]