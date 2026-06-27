;--------------------------------------------------------------------------------
; ティラノスクリプト テーマプラグイン theme_kopanda_bth_05_red_red
; 作者:こ・ぱんだ
; https://kopacurve.blog.fc2.com/
; https://ko10panda.booth.pm/
;--------------------------------------------------------------------------------

	[iscript]

	// 初期化
	mp.font_color    = mp.font_color    || "0xF5F5F5";
	mp.name_color    = mp.name_color    || "0xF5F5F5";
	mp.frame_opacity = mp.frame_opacity || "255";
	mp.font_color2   = mp.font_color2   || "0xF5F5F5";
	mp.glyph         = mp.glyph         || "on";

	if(TG.config.alreadyReadTextColor != "default"){
		TG.config.alreadyReadTextColor = mp.font_color2;
	}

	[endscript]

;	名前部分のメッセージレイヤ削除
	[free name="chara_name_area" layer="message0"]

;	メッセージウィンドウの設定
	[position layer="message0" width="1100" height="190" top="518" left="90"]
	[position layer="message0" frame="../others/plugin/theme_kopanda_bth_05_red/image/frame_message.png" margint="50" marginl="100" marginr="100" opacity="&mp.frame_opacity" page="fore"]

;	名前枠の設定（名前表示を左揃えにしたいときは align="center"を削除）
	[ptext name="chara_name_area" layer="message0" color="&mp.name_color" size="26" x="160" y="524" width="360" align="center"]
	[chara_config ptext="chara_name_area"]

;	デフォルトのフォントカラー指定
	[font color="&mp.font_color"]
	[deffont color="&mp.font_color"]

; クリック待ちグリフの設定（onにしたときだけ有効）
	[if exp="mp.glyph == 'on'"]
	[glyph line="../../../data/others/plugin/theme_kopanda_bth_05_red/image/system/nextpage.png"]
	[endif]

;=================================================================================

; 機能ボタンを表示するマクロ

;=================================================================================

; 機能ボタンを表示したいシーンで[add_theme_button]と記述してください（消去は[clreafix]タグ）
[macro  name="add_theme_button"]

;	歯車ボタン（メニューボタン）非表示
[hidemenubutton]

[iscript]

	tf.sysbtnImgPath   = '../others/plugin/theme_kopanda_bth_05_red/image/button/';
	tf.sysbtnPosx      = [175, 260, 345, 430, 515, 600, 685, 770, 855, 940, 1025, 1148];
	tf.sysbtnPosy      = [682, 552];

[endscript]

; Q.Save
[button name="role_button" role="quicksave" graphic="&tf.sysbtnImgPath + 'qsave.png'" enterimg="&tf.sysbtnImgPath + 'qsave2.png'" activeimg="&tf.sysbtnImgPath + 'qsave3.png'" x="&tf.sysbtnPosx[0]" y="&tf.sysbtnPosy[0]"]

; Q.Load
[button name="role_button" role="quickload" graphic="&tf.sysbtnImgPath + 'qload.png'" enterimg="&tf.sysbtnImgPath + 'qload2.png'" activeimg="&tf.sysbtnImgPath + 'qload3.png'" x="&tf.sysbtnPosx[1]" y="&tf.sysbtnPosy[0]"]

; Save
[button name="role_button" role="save" graphic="&tf.sysbtnImgPath + 'save.png'" enterimg="&tf.sysbtnImgPath + 'save2.png'" activeimg="&tf.sysbtnImgPath + 'save3.png'" x="&tf.sysbtnPosx[2]" y="&tf.sysbtnPosy[0]"]

; Load
[button name="role_button" role="load" graphic="&tf.sysbtnImgPath + 'load.png'" enterimg="&tf.sysbtnImgPath + 'load2.png'" activeimg="&tf.sysbtnImgPath + 'load3.png'" x="&tf.sysbtnPosx[3]" y="&tf.sysbtnPosy[0]"]

; Auto
[button name="role_button" role="auto" graphic="&tf.sysbtnImgPath + 'auto.png'" enterimg="&tf.sysbtnImgPath + 'auto2.png'" activeimg="&tf.sysbtnImgPath + 'auto3.png'" autoimg="&tf.sysbtnImgPath + 'auto4.png'" x="&tf.sysbtnPosx[4]" y="&tf.sysbtnPosy[0]"]

; Skip
[button name="role_button" role="skip" graphic="&tf.sysbtnImgPath + 'skip.png'" enterimg="&tf.sysbtnImgPath + 'skip2.png'" activeimg="&tf.sysbtnImgPath + 'skip3.png'" skipimg="&tf.sysbtnImgPath + 'skip4.png'" x="&tf.sysbtnPosx[5]" y="&tf.sysbtnPosy[0]"]

; Backlog
[button name="role_button" role="backlog" graphic="&tf.sysbtnImgPath + 'log.png'" enterimg="&tf.sysbtnImgPath + 'log2.png'" activeimg="&tf.sysbtnImgPath + 'log3.png'" x="&tf.sysbtnPosx[6]" y="&tf.sysbtnPosy[0]"]

; Screen
[button name="role_button" role="fullscreen" graphic="&tf.sysbtnImgPath + 'screen.png'" enterimg="&tf.sysbtnImgPath + 'screen2.png'" activeimg="&tf.sysbtnImgPath + 'screen3.png'" x="&tf.sysbtnPosx[7]" y="&tf.sysbtnPosy[0]"]

; Menu
[button name="role_button" role="menu" graphic="&tf.sysbtnImgPath + 'menu.png'" enterimg="&tf.sysbtnImgPath + 'menu2.png'" activeimg="&tf.sysbtnImgPath + 'menu3.png'" x="&tf.sysbtnPosx[8]" y="&tf.sysbtnPosy[0]"]

; Config（※sleepgame を使用して config.ks を呼び出しています）
[button name="role_button" role="sleepgame" graphic="&tf.sysbtnImgPath + 'sleep.png'" enterimg="&tf.sysbtnImgPath + 'sleep2.png'" activeimg="&tf.sysbtnImgPath + 'sleep3.png'" storage="../others/plugin/theme_kopanda_bth_05_red/config.ks" x="&tf.sysbtnPosx[9]" y="&tf.sysbtnPosy[0]"]

; Title
[button name="role_button" role="title" graphic="&tf.sysbtnImgPath + 'title.png'" enterimg="&tf.sysbtnImgPath + 'title2.png'" activeimg="&tf.sysbtnImgPath + 'title3.png'" x="&tf.sysbtnPosx[10]" y="&tf.sysbtnPosy[0]"]

; Close
[button name="role_button" role="window" graphic="&tf.sysbtnImgPath + 'close.png'" enterimg="&tf.sysbtnImgPath + 'close2.png'" activeimg="&tf.sysbtnImgPath + 'close3.png'" x="&tf.sysbtnPosx[11]" y="&tf.sysbtnPosy[1]"]

[endmacro]

;=================================================================================

; システムで利用するHTML,CSSの設定

;=================================================================================

;	セーブ画面
[sysview type="save" storage="./data/others/plugin/theme_kopanda_bth_05_red/html/save.html"]

;	ロード画面
[sysview type="load" storage="./data/others/plugin/theme_kopanda_bth_05_red/html/load.html"]

;	バックログ画面
[sysview type="backlog" storage="./data/others/plugin/theme_kopanda_bth_05_red/html/backlog.html"]

;	メニュー画面
[sysview type="menu" storage="./data/others/plugin/theme_kopanda_bth_05_red/html/menu.html"]

;	CSS
[loadcss file="./data/others/plugin/theme_kopanda_bth_05_red/css/bth05_red.css"]
[loadcss file="./data/others/plugin/theme_kopanda_bth_05_red/css/bth05_anim.css"]

[loadjs storage="plugin/theme_kopanda_bth_05_red/setting.js"]
;=================================================================================

; テストメッセージ出力プラグインの読み込み

;=================================================================================
[loadjs storage="plugin/theme_kopanda_bth_05_red/testMessagePlus/gMessageTester.js"]
[loadcss file="./data/others/plugin/theme_kopanda_bth_05_red/testMessagePlus/style.css"]

[macro name="test_message_start"]
	[eval exp="gMessageTester.create()"]
[endmacro]

[macro name="test_message_end"]
	[eval exp="gMessageTester.destroy()"]
[endmacro]

[macro name="test_message_reset"]
	[eval exp="gMessageTester.currentTextNumber=0;gMessageTester.next(true)"]
[endmacro]

[return]
