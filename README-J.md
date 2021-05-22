[View in English](README.md)
# ClientStarter-2.1.0-beta
## AIWolf.NETエージェント用クライアントスターター

1. ダウンロード

    * ClientStarter with runtime:
      * [Linux 64bit](https://github.com/AIWolfSharp/ClientStarter/raw/v2/ClientStarter-2.1.0-linux-x64.tgz)
      * [macOS 64bit](https://github.com/AIWolfSharp/ClientStarter/raw/v2/ClientStarter-2.1.0-osx-64.zip)
      * [Windows 64bit](https://github.com/AIWolfSharp/ClientStarter/raw/v2/ClientStarter-2.1.0-win-x64.zip)

1. 使用法

       ClientStarter [-h host] [-p port] -c clientClass dllName [-r roleRequest] [-n name] [-t timeout] [-d] [-v]
            -h host : サーバを指定
            -p port : 接続ポートを指定
            -c clientClass dllName : クラス名とdllファイルを指定
            -r roleRequest : 希望する役職を指定
            -n name : 名前を指定
            -t timeour : 応答制限時間を指定
            -d : ダミープレイヤーを使用
            -v : バージョンを出力

1. 履歴と[変更点](CHANGES-J.md)

    * 2.1.0: このバージョンからClientStarter単独でのリリースとなりました．過去のリリースは[こちら](https://github.com/AIWolfSharp/AIWolf_NET)を参照してください．

---
このソフトウェアは[Apache License 2.0](LICENSE.md)のもとで公開されています．
