# SaarFFmpeg

一个CSharp的FFmpeg库，可运行在Windows和Android上。

> ### 特性(feature)
> * 音视频解码(audio&video decoder)
> * 音视频编码(audio&video encoder)
> * 音视频重采样(audio&video resampler)
> * 音视频封装(audio&video remuxer)

> ### 需要DLL
> * avutil-55.dll
> * avcodec-57.dll
> * avformat-57.dll
> * swscale-4.dll
> * swresample-2.dll
> 
> 如果是Android要换成so。
> [下载DLL](http://ffmpeg.zeranoe.com/builds/)，下载页面里选择Shared。

***

> ### 示例(examples)
> #### SaarFFmpeg.AudioTest
> 播放音频，需要[Coolest库](https://github.com/ibukisaar/Coolest)。
***
> #### SaarFFmpeg.VideoTest
> 解码视频生成图像。
***
> #### SaarFFmpeg.EncodeAudio
> 解码mp3并编码成mp3。
> * Bug：生成flac没有时间长度信息。
> 
***
> #### SaarFFmpeg.EncodeVideo
> 生成一个空图像的视频。
***
> #### SaarFFmpeg.Remuxer
> 把一个视频转成封装格式的视频(mkv,flv,mp4...)

***

> ### 作者
> Saar, email:rockman.x8@qq.com, QQ:631759794
